using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using AnkapurBAL;
using MahApps.Metro.Controls;
using AnkapurDAL;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Diagnostics;


//using MahApps.Metro.Controls;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);

        public CoreDAL _objdal = new CoreDAL();
        string connStr = "";
        private OrdersBal _objbal = new OrdersBal();
        OrderProperties opr = new OrderProperties();
        //string connStr = "Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";
        string qtyStr = "1";
        string CustCode = "";


        //       // string localizedMessage = (string)Application.Current.FindResource("restCode");
        //       Application.Current.Properties["orderId"] = lblOrderID.Content.ToString();

        //  Application.Current.Properties["custPhone"] = lblOrderID.Content.ToString();
        //Application.Current.Properties["EmpCode"] = lblOrderID.Content.ToString();
        //Application.Current.Properties["UserType"] = lblOrderID.Content.ToString();

        //Application.Current.Properties["orderId"] = "".ToString();
        //Application.Current.Properties["restcode"] = dt.Rows[0][8].ToString();
        ////Application.Current.Properties["custPhone"] = lblOrderID.Content.ToString();
        //Application.Current.Properties["EmpCode"] = dt.Rows[0][3].ToString();
        //Application.Current.Properties["UserType"] = dt.Rows[0][6].ToString();

        public NewOrder()
        {
            InitializeComponent();
            connStr = _objdal.constring().ToString();
            // fillNotAvailable();
            fillRestNames();
            fillCustomer();
            fillEmployee();
            lblCustAddr.Focus();
            FillAgentOrders();
            dtDelivery.Value = DateTime.Now;

            Bindchanneldtls(Cbochannel);
            svitems.ScrollToHome();

        }

        //private void fillCustomer()
        //{


        //    if (Application.Current.Properties["custPhone"] == null || Application.Current.Properties["custPhone"].ToString().Length == 0)
        //    { CustCode = Application.Current.Properties["Mobile1"].ToString(); }
        //    /*{ Application.Current.Properties["custPhone"] = "111111"; }*/
        //    else
        //    { CustCode = Application.Current.Properties["custPhone"].ToString(); }

        //    // CustCode = "3333333";
        //    SqlConnection connection;
        //    connection = new SqlConnection(connStr);
        //    if (connection.State.ToString() == "open") { connection.Close(); }
        //    connection.Open();
        //    SqlCommand cmd = new SqlCommand("searchCustomerByPhone", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("customerphone", CustCode));
        //    //  @Categorytype = N'Break Fast'
        //    SqlDataAdapter dAd = new SqlDataAdapter(cmd);
        //    DataTable dSet = new DataTable();
        //    dAd.Fill(dSet); //lblCustName lblCustPhone  lblCustAddr
        //    if (connection.State.ToString() == "open") { connection.Close(); }

        //    if (dSet.Rows.Count > 0 && dSet.Rows[0][0].ToString() != "Customer Does not Exists")
        //    {
        //        lblCustName.Content = dSet.Rows[0][0].ToString() + "  " + dSet.Rows[0][1].ToString();
        //        lblCustPhone.Content = dSet.Rows[0][4].ToString();
        //        //+ " Type : " + dSet.Rows[0][2].ToString()
        //        lblCustAddr.Text = dSet.Rows[0][3].ToString();
        //    }
        //    else
        //    {

        //        lblCustName.Content = "Self Restaurant ";
        //        lblCustPhone.Content = CustCode;
        //        lblCustAddr.Text = "Rest Address";
        //    }


        //}
        private void fillCustomer()
        {


            if (Application.Current.Properties["custPhone"] == null || Application.Current.Properties["custPhone"].ToString().Length == 0)
            { CustCode = Application.Current.Properties["Mobile1"].ToString(); }
            /*{ Application.Current.Properties["custPhone"] = "111111"; }*/
            else
            { CustCode = Application.Current.Properties["custPhone"].ToString(); }

            // CustCode = "3333333";
            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("searchCustomerByPhone", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("customerphone", CustCode));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataSet dSet = new DataSet();
            dAd.Fill(dSet); //lblCustName lblCustPhone  lblCustAddr
            if (connection.State.ToString() == "open") { connection.Close(); }

            if (dSet.Tables[0].Rows.Count > 0 && dSet.Tables[0].Rows[0][0].ToString() != "Customer Does not Exists")
            {
                lblCustName.Content = dSet.Tables[0].Rows[0][0].ToString() + "  " + dSet.Tables[0].Rows[0][1].ToString();
                lblCustPhone.Content = dSet.Tables[0].Rows[0][4].ToString();
                //+ " Type : " + dSet.Rows[0][2].ToString()

                lblCustAddr.Text = dSet.Tables[0].Rows[0][3].ToString();
                if (dSet.Tables[1].Rows[0][0].ToString() == null)
                {
                    lblCustorders.Content = 0;
                }
                else
                {
                    lblCustorders.Content = "Orders:" + dSet.Tables[1].Rows[0][0].ToString();
                }
            }
            else
            {

                lblCustName.Content = "Self Restaurant ";
                lblCustPhone.Content = CustCode;
                lblCustAddr.Text = "Rest Address";
            }


        }

        private void fillEmployee()
        {
            string empCode = "";
            if (Application.Current.Properties["EmpCode"] == null) { Application.Current.Properties["EmpCode"] = "CA102"; }
            else

            { empCode = Application.Current.Properties["EmpCode"].ToString(); }



            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("spGetEmpdetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("EmpCode", empCode));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dSet); //lblCustName lblCustPhone  lblCustAddr
            if (connection.State.ToString() == "open") { connection.Close(); }
            if (dSet.Rows.Count > 0)
            {

                lblEmpName.Content = dSet.Rows[0][1].ToString() + " " + dSet.Rows[0][2].ToString();
                lblEmpCode.Content = dSet.Rows[0][0].ToString();
                lblEmpType.Content = dSet.Rows[0][5].ToString();
            }

        }

        private void fillRestNames()
        {
            //Filling dynamically the Restuarants in radio buttons

            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }

            string CmdString = string.Empty;
            if (Application.Current.Properties["UserType"].ToString().ToUpper() == "CA" || Application.Current.Properties["UserType"].ToString().ToUpper() == "AD") { CmdString = " select restcode from tblRestuarant where  tblRestuarant.restcode <>'zz' "; }
            else { CmdString = " select restcode from tblRestuarant where  tblRestuarant.restcode ='" + Application.Current.Properties["restcode"].ToString() + "'"; }

            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("rest");
            sda.Fill(dt);

            if (connection.State.ToString() == "open") { connection.Close(); }
            radioBtns(dt);


        }
        public void radioBtns(DataTable dt)
        {
            //Filling dynamically the Restuarants in radio buttons
            DataTable dt1 = new DataTable();
            dt1 = dt;

            string restCode;
            if (Application.Current.Properties["restcode"].ToString().Length > 0)
            {
                restCode = Application.Current.Properties["restcode"].ToString().Trim();
            }
            else
            { restCode = ""; }

            foreach (DataRow row in dt.Rows)
            {


                RadioButton rd = new RadioButton();
                rd.GroupName = "Rest";
                rd.Name = "rdbtn" + row.ItemArray[0].ToString().Trim();
                rd.Content = row.ItemArray[0].ToString();

                var toReg1 = (RadioButton)this.FindName(rd.Name);
                if (toReg1 == null)
                {
                    this.RegisterName(rd.Name, rd);
                }
                if (row.ItemArray[0].ToString().Trim() == restCode)
                { rd.IsChecked = true; rd.IsEnabled = true; }
                else
                {
                    if (restCode != "ZZ")
                    { rd.IsEnabled = true; }
                    else { rd.IsEnabled = true; }

                }
                stkRadio.Children.Add(rd);
            }

        }

        private void getMenu(string bf)
        {
            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }

            connection.Open();
            // SqlCommand cmd = new SqlCommand("getMenuByCategory", connection);
            SqlCommand cmd = new SqlCommand("availgetMenuByCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Categorytype", bf));
            //  @Categorytype = N'Break Fast'

            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dSet);
            fillMenu(dSet);
            if (connection.State.ToString() == "open") { connection.Close(); }
        }

        // Main panel 
        private void fillMenu(DataTable dSet)
        {
            //Main panel where menu is displayed in buttons and price and qty
            wrpPanel.Children.Clear();
            DataTable dt = new DataTable();
            dt = dSet;
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                Button btn = new Button();
                StackPanel stP = new StackPanel();
                Image img = new Image();
                Separator sp = new Separator();
                TextBlock txtBlk = new TextBlock();
                TextBlock txtBlk1 = new TextBlock();

                string price = null;

                btn.Name = "btnMn" + row.ItemArray[0].ToString().Trim();
                btn.Content = row.ItemArray[1].ToString().Trim();
                btn.Height = 150;
                btn.Width = 100;
                btn.Margin = new Thickness(5);
                btn.Click += ShowDishDetails_Click;
                //Register Main button
                var toRegMain = (Button)this.FindName(btn.Name);
                if (toRegMain == null)
                {
                    this.RegisterName(btn.Name, btn);
                }
                else
                {
                    this.UnregisterName(btn.Name);
                    this.RegisterName(btn.Name, btn);
                }

                stP.Orientation = Orientation.Vertical;
                if (row.ItemArray[7].ToString().Length == 0 || row.ItemArray[7].ToString() == null)
                {
                    img.Source = new BitmapImage(new Uri(@"/Images/dishtype.png", UriKind.Relative));
                }
                else
                {
                    string base64 = Convert.ToBase64String((Byte[])((row.ItemArray[7])));
                    byte[] binaryData = Convert.FromBase64String(base64);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(binaryData);
                    bi.EndInit();
                    img.Source = bi;
                }



                txtBlk.FontSize = 20;

                price = row.ItemArray[3].ToString().Trim();

                txtBlk.Text = price; ;//price

                txtBlk1.FontSize = 10;
                txtBlk1.Text = row.ItemArray[1].ToString().Trim();
                //  stP.Children.Add(btn);
                stP.Children.Add(img);
                stP.Children.Add(txtBlk);
                stP.Children.Add(txtBlk1);
                stP.Children.Add(sp);

                btn.Content = stP;
                wrpPanel.Children.Add(btn);

                //adding quantity and up down arrow
                Button btnUp = new Button();
                Button btnDn = new Button();
                StackPanel stkqty = new StackPanel();


                Label lblQty = new Label();

                lblQty.Content = row.ItemArray[1].ToString().Trim();
                lblQty.FontSize = 15;
                lblQty.HorizontalAlignment = HorizontalAlignment.Center;
                lblQty.Foreground = System.Windows.Media.Brushes.Red;
                lblQty.Width = 100;
                lblQty.Visibility = Visibility.Hidden;

                btnUp.Name = "btnUP" + row.ItemArray[0].ToString().Trim();
                btnDn.Name = "btnDn" + row.ItemArray[0].ToString().Trim();
                lblQty.Name = "lblqt" + row.ItemArray[0].ToString().Trim();
                //using lblQty for Product Name - Need to change

                Label lblQtyText = new Label();

                //Registering lblqty
                var toReg = (Label)this.FindName(lblQty.Name);
                if (toReg == null)
                {
                    this.RegisterName(lblQty.Name, lblQty);
                }

                btnUp.Content = "UP";
                btnDn.Content = "DN";

                //adding event to up button
                btnUp.Click += button_Click;
                //adding event to down button
                btnDn.Click += button_Click;

                var toRegUp = (Button)this.FindName(btnUp.Name);
                if (toRegUp == null)
                {
                    this.RegisterName(btnUp.Name, btnUp);
                }
                else
                {
                    this.UnregisterName(btnUp.Name);
                    this.RegisterName(btnUp.Name, btnUp);
                }


                Separator sp1 = new Separator();
                Separator sp2 = new Separator();
                //Add "Add to cart button"

                Button btnAddtoCart = new Button();
                btnAddtoCart.Content = "Add to Cart";
                btnAddtoCart.Name = "btnAC" + row.ItemArray[0].ToString().Trim();
                btnAddtoCart.ToolTip = row.ItemArray[1].ToString().Trim() + "@" + row.ItemArray[3].ToString().Trim(); ;
                btnAddtoCart.Click += addtoCartEvent_Click;


                //Registering Add to cart button
                var toReg1 = (Button)this.FindName(btnAddtoCart.Name);
                if (toReg1 == null)
                {
                    this.RegisterName(btnAddtoCart.Name, btnAddtoCart);
                }

                //Adding the product name
                TextBlock txtDishName = new TextBlock();
                txtDishName.Name = "txtDishName" + row.ItemArray[0].ToString().Trim();
                txtDishName.Text = row.ItemArray[1].ToString().Trim();
                txtDishName.Width = 100;
                txtDishName.TextWrapping = TextWrapping.Wrap;
                txtDishName.FontWeight = FontWeights.UltraBold;
                txtDishName.Foreground = Brushes.Navy;

                txtDishName.FontFamily = new FontFamily("Century Gothic");

                //adding to Stack panel
                stkqty.Name = "stkqt" + row.ItemArray[0].ToString().Trim();
                stkqty.Children.Add(sp2);
                stkqty.Children.Add(txtDishName);
                stkqty.Children.Add(lblQty);
                stkqty.Children.Add(btnUp);
                stkqty.Children.Add(btnDn);
                stkqty.Children.Add(sp1);
                stkqty.Children.Add(btnAddtoCart);
                wrpPanel.Children.Add(stkqty);

            }

        }

        private void ShowDishDetails_Click(object sender, RoutedEventArgs e)
        {
            //Display the Dish details in the message box on click of Dish image
            Button clicked = (Button)sender;

            string productid;
            productid = clicked.Name.ToString().Trim().ToUpper().Substring(5, clicked.Name.Length - 5);
            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            string CmdString = string.Empty;
            CmdString = "  SELECT        ProductID, ProductName, ShortDescription, LongDescription, cast(Price as int) as Price, Remarks FROM tblProductMaster";
            CmdString = CmdString + "  where ProductID='" + productid + "'";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Dish");
            sda.Fill(dt);
            //  CmdString = dt.Rows[0][1].ToString();
            CmdString = dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString();
            CmdString += Environment.NewLine + "Price : " + dt.Rows[0][4].ToString() + Environment.NewLine + dt.Rows[0][3].ToString() + Environment.NewLine + dt.Rows[0][5].ToString();
            MessageBox.Show(CmdString, "Dish Details", MessageBoxButton.OK, MessageBoxImage.Information);
            if (connection.State.ToString() == "open") { connection.Close(); }
        }

        void addtoCartEvent_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            //find main button for price and code
            var btnAddCart = (Button)this.FindName(clicked.Name);
            string[] Name_code;
            Name_code = btnAddCart.ToolTip.ToString().Split('@');
            string Ncode, Nproduct, Nprice, Nqty;
            int Ntotal;
            string RestCode;
            RestCode = restSearch();
            if (RestCode.Length == 0)
            {
                MessageBox.Show("Please select restaurant", "Rest Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                if (lblNewDish.Content.ToString().ToUpper().Trim() == Name_code[0].ToUpper().Trim())
                {
                    Ncode = clicked.Name.ToString().Trim().ToUpper().Substring(5, clicked.Name.Length - 5);
                    Nproduct = Name_code[0];
                    Nprice = Name_code[1];
                    Nqty = (lblNewQTY.Content.ToString());
                    if (Nqty == "") { Nqty = "1"; }
                    Ntotal = Convert.ToInt32(Nprice) * Convert.ToInt32(Nqty);
                }
                else
                {
                    Ncode = clicked.Name.ToString().Trim().ToUpper().Substring(5, clicked.Name.Length - 5);
                    lblNewDish.Content = Name_code[0];
                    Nproduct = Name_code[0];
                    Nprice = Name_code[1];
                    lblNewQTY.Content = "1";
                    Nqty = "1";
                    if (Nqty == "") { Nqty = "1"; }
                    Ntotal = Convert.ToInt32(Nprice) * Convert.ToInt32(Nqty);

                }


                //Insert into the List view
                string[] row = { Ncode, Nproduct, Nprice, Nqty, Ntotal.ToString() };
                //  lvOrders.Items.Add(row);
                if (Convert.ToInt32(Nqty) > 0) { lvOrders.Items.Add(new Orders() { code = Ncode, product = Nproduct, price = Nprice, qty = Nqty, total = Ntotal }); }
                if (Convert.ToInt32(Nqty) == 0)
                { MessageBox.Show("Item quantity is 0"); }

                getGrandTotal();

            }
        }

        private void getGrandTotal()
        {
            //calculate the grand total and display in the label
            lblTotalLable.Content = "0";
            if (lvOrders.Items.Count > 0)
            {

                foreach (object item in lvOrders.Items)
                {

                    lblTotalLable.Content = Convert.ToInt32(lblTotalLable.Content) + ((Anakapur.NewOrder.Orders)item).total;

                }
            }
            //lblTotalLable.Content = "Grand Total :  Rs " + lblTotalLable.Content;
        }

        public class Orders
        {
            public string code { get; set; }

            public string product { get; set; }

            public string price { get; set; }
            public string qty { get; set; }
            public int total { get; set; }
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            string code;
            code = clicked.Name.ToString().Trim().ToUpper().Substring(5, clicked.Name.Length - 5);


            string lblName;
            //To get the Dish name : need to change lblqt, naming convention is wrong
            lblName = "lblqt" + clicked.Name.ToString().Trim().ToUpper().Substring(5, clicked.Name.Length - 5);

            var lblQty = (Label)this.FindName(lblName);


            lblNewDish.Content = lblQty.Content;

            if (clicked.Name.ToString().Trim().ToUpper().Substring(0, 5) == "btnup".ToUpper())
            {
                if (qtyStr == code)
                {
                    lblNewQTY.Content = Convert.ToInt32(lblNewQTY.Content) + 1;
                }
                else
                {
                    lblNewQTY.Content = 1;
                    qtyStr = code;
                }
            }
            if (clicked.Name.ToString().Trim().ToUpper().Substring(0, 5) == "btnDn".ToUpper())
            {
                if (qtyStr == code)
                {
                    if (Convert.ToInt32(lblNewQTY.Content) > 0) { lblNewQTY.Content = Convert.ToInt32(lblNewQTY.Content) - 1; }
                }
                else
                {
                    lblNewQTY.Content = 1;
                    qtyStr = code;
                }
            }
        }
        private void btnBreakfast_Click(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();
            getMenu("Break fast");
            lblMenutype.Content = "Break Fast";
            lblNewDish.Content = "";
        }
        private void btnLunch_Click(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();
            getMenu("Lunch and Dinner");
            lblMenutype.Content = "Lunch and Dinner";
            lblNewDish.Content = "";
        }

        private void btnCombo_Click(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();
            getMenu("Addons");
            lblMenutype.Content = "Addons";
            lblNewDish.Content = "";
        }

        private void btnFamily_Click(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();
            getMenu("MealCombos");
            lblMenutype.Content = "MealCombos";
            lblNewDish.Content = "";
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            //gets all the list row data
            var curItem = ((ListBoxItem)lvOrders.ContainerFromElement((Button)sender)).Content;

            var sel = lvOrders.SelectedItem;
            var curNew = lvOrders.ContainerFromElement((Button)sender);

        }

        private void lvOrders_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int nn = lvOrders.SelectedIndex;
            if (nn >= 0)
            {
                lvOrders.Items.RemoveAt(nn);
                getGrandTotal();
            }

        }

        private void btnAllMenu_Click(object sender, RoutedEventArgs e)
        {
            getMenu("");
            lblMenutype.Content = "Full Menu";
            lblNewDish.Content = "";
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            // checkrestaurants();
            //try
            //{
                string RestCode;
                RestCode = restSearch();
                if (txtdelchrges.Text.Length == 0 || txtdelchrges.Text == null) { MessageBox.Show("Please Enter the Delivery charges"); txtdelchrges.Focus(); }
                else
                {
                    if (RestCode.Length == 0)
                    {
                        MessageBox.Show("Please select restaurant", "Restaurant", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        if (lvOrders.Items.Count > 0)
                        {

                            SqlConnection connection;
                            connection = new SqlConnection(connStr);
                            if (connection.State.ToString() == "open") { connection.Close(); }
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("[dbo].[spinsertNewOrderDT]", connection);


                            int TypeOfOrderId;
                            string EmpCode;
                            string CustPhoneNumber;
                            decimal actamt = decimal.Parse(lblTotalLable.Content.ToString());
                            int delamount = Convert.ToInt32(txtdelchrges.Text);
                            decimal totalbill = actamt + delamount;

                        //    int hun = Int32.Parse("100");
                        //    Decimal divp = Decimal.Parse("2.5".Replace(".", "."));
                        //// Decimal amt = hun * divp;
                        //decimal cgstcharges = (actamt) / hun * divp;
                        //decimal sgstcharges = (actamt) / hun * divp;
                        decimal cgstcharges = Decimal.Parse("0.0".Replace(".", "."));
                        decimal sgstcharges = Decimal.Parse("0.0".Replace(".", "."));
                        decimal totalbillaftergst = (totalbill + (cgstcharges) + (sgstcharges));
                            string CustRequest = txtCustInstructions.Text.ToString();
                            string DeliveryBoyCode = "";
                            string channelid = Cbochannel.SelectedValue.ToString();
                            DateTime tobedeliver = Convert.ToDateTime(dtDelivery.Value.ToString());
                            if (tobedeliver != System.DateTime.Now)
                            {
                                tobedeliver = tobedeliver.AddMinutes(60);
                            }
                            else
                            {
                                tobedeliver = Convert.ToDateTime(dtDelivery.Value.ToString());
                            }

                            TypeOfOrderId = Convert.ToInt32(((ComboBoxItem)this.CboTypeOfOrder.SelectedValue).Tag.ToString());
                            EmpCode = lblEmpCode.Content.ToString();
                            CustPhoneNumber = lblCustPhone.Content.ToString();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@typeoforderid", TypeOfOrderId));
                            cmd.Parameters.Add(new SqlParameter("@employecode", EmpCode));
                            cmd.Parameters.Add(new SqlParameter("@customerphone", CustCode));
                            cmd.Parameters.Add(new SqlParameter("@restcode", RestCode.Trim().ToString()));
                            cmd.Parameters.Add(new SqlParameter("@CustRequest", CustRequest));
                            cmd.Parameters.Add(new SqlParameter("@DeliveryBoyCode", DeliveryBoyCode));
                            cmd.Parameters.Add(new SqlParameter("@channelid", channelid));
                            cmd.Parameters.Add(new SqlParameter("@orderdelivtime", Convert.ToDateTime(DateTime.Now.ToString())));
                            cmd.Parameters.Add(new SqlParameter("@tobedelivered", tobedeliver));
                            cmd.Parameters.Add(new SqlParameter("@deliveryamount", delamount.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@cgstcharges", (cgstcharges)));
                        cmd.Parameters.Add(new SqlParameter("@sgstcharges", (sgstcharges)));
                        SqlParameter outputIdParam = new SqlParameter("@NewId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(outputIdParam);


                            cmd.ExecuteNonQuery();
                            string idFromString = (outputIdParam.Value.ToString());
                            int m = System.DateTime.Now.Month;
                            int d = System.DateTime.Now.Day;
                            int y = System.DateTime.Now.Year;
                            ///Insesrting order details from the list box
                            if (idFromString.Length == 0) { idFromString = "1"; }
                            idFromString = RestCode.ToString().Trim() + d.ToString() + m.ToString() + y.ToString() + "-" + idFromString;
                            for (int i = lvOrders.Items.Count - 1; i >= 0; --i)
                            {
                                var item = lvOrders.Items[i];

                                cmd = new SqlCommand("insertNewOrdreDetailsBasedOnId", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("OrderId", idFromString));
                                cmd.Parameters.Add(new SqlParameter("quantity", Convert.ToInt32(((Anakapur.NewOrder.Orders)item).qty)));
                                cmd.Parameters.Add(new SqlParameter("productid", (((Anakapur.NewOrder.Orders)item).code).Trim()));
                                cmd.ExecuteNonQuery();

                            }

                            MessageBox.Show("New Order Saved : " + idFromString.ToString(), "Save Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtdelchrges.Text = "";


                            //Uri uri = new Uri("http://inventory.ankapurchicken.com/");

                            //Ping ping = new Ping();
                            //PingReply pingReply = ping.Send(uri.Host);

                            //int Out;
                            //if (pingReply.Status == IPStatus.Success)
                            //{
                            //if (InternetGetConnectedState(out Out, 0) == true)
                            //{
                            try
                            {
                                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to send SMS?", "SMS", System.Windows.MessageBoxButton.YesNo);
                                if (messageBoxResult == MessageBoxResult.Yes)
                                {
                                    SMSCAPI.ServiceSoapClient obj1 = new SMSCAPI.ServiceSoapClient();
                                    SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
                                    string strPostResponse;
                                    string strPostResponse1;
                                    //9000754777
                                     strPostResponse = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "9000754777", "Order Received!!!        Order id:" + idFromString.ToString() + "                       " + "Grand Total Rs:" + totalbillaftergst.ToString() + "              " + "Name: " + lblCustName.Content.ToString() + "              " + "Customer Phone: " + lblCustPhone.Content.ToString() + "           " + "Items:" + lvOrders.Items.Count.ToString(), "ANKPUR"); //hn
                                 //     strPostResponse = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "9494942342", "Order Received!!!        Order id:" + idFromString.ToString() + "                       " + "Grand Total Rs:" + totalbillaftergst.ToString() + "              " + "Name: " + lblCustName.Content.ToString() + "              " + "Customer Phone: " + lblCustPhone.Content.ToString() + "           " + "Items:" + lvOrders.Items.Count.ToString(), "ANKPUR"); //asrao
                                //  strPostResponse = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "7032925185", "Order Received!!!        Order id:" + idFromString.ToString() + "                       " + "Grand Total Rs:" + totalbillaftergst.ToString() + "              " + "Name: " + lblCustName.Content.ToString() + "              " + "Customer Phone: " + lblCustPhone.Content.ToString() + "           " + "Items:" + lvOrders.Items.Count.ToString(), "ANKPUR"); //kp
                                    strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", lblCustPhone.Content.ToString(), "Thank you for ordering with Ankapur Chicken your  Order id:" + idFromString.ToString() + "   " + "Grand Total Rs:" + totalbillaftergst.ToString() + "(incl GST and delivery charges)", "ANKPUR");

                                    string delReport;
                                    string delReport1;
                                    delReport = obj1.Getbalance("ankapurchicken", "ankapur6900");
                                    delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Please Check the internet Connection!!! Messages Cannot be sent at the moment", "Internet Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Please Check the internet Connection!!! Messages Cannot be sent at the moment", "Internet Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            //}
                            //}
                            //else
                            //{ MessageBox.Show("Please Check the internet Connection!!! Messages Cannot be sent at the moment", "Internet Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
                            connection.Close();
                            lblOrderID.Content = idFromString.ToString();
                            lvOrders.Items.Clear();
                            lblCustAddr.Text = "";
                            lblCustName.Content = "";
                            lblCustPhone.Content = "";
                            Application.Current.Properties["custPhone"] = "";
                            lblTotalLable.Content = "Total : ";
                            wrpPanel.Visibility = Visibility.Hidden;
                            wrpPanel.Children.Clear();
                            FillAgentOrders();

                        }
                        else
                        { MessageBox.Show("No items to Save", "Save Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
                    }
                }
           // }
            //catch (Exception)
            //{
            //    MessageBox.Show("Order is not saved please place the order again");
            //}
        }

        private void FillAgentOrders()
        {
            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("TodayOrdersByEmpCode", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@empcode", lblEmpCode.Content.ToString().Trim()));
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dSet);
            //TotalNoOfOrders,CompletedOrders,NotCompletedOrders 
            if (dSet.Rows.Count > 0) { lblTotalOrders.Content = "Total orders : " + dSet.Rows[0][1].ToString() + " Completed : " + dSet.Rows[0][2].ToString() + " Incomplete " + dSet.Rows[0][3].ToString(); }
            if (connection.State.ToString() == "open") { connection.Close(); }
        }

        private string restSearch()
        {
            string returnRest = "";
            foreach (RadioButton element in stkRadio.Children)
            {
                var restButton = element.Name;
                RadioButton rd = new RadioButton();

                rd = (RadioButton)this.FindName(restButton.ToString());
                if (rd.IsChecked == true)
                {
                    returnRest = rd.Content.ToString();
                }
            }

            return returnRest;
        }

        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {

            if (lblOrderID.Content.ToString().Length > 0)
            {
                Application.Current.Properties["orderId"] = lblOrderID.Content.ToString();
                var newWindow = new LastOrderView();

                newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                newWindow.Show();
            }
            else { MessageBox.Show("Sorry there was no last order", "Last order", MessageBoxButton.OK, MessageBoxImage.Error); }

        }
        public void checkrestaurants()
        {
            RadioButton rd = new RadioButton();
            if (rd.IsChecked == false)
            {
                MessageBox.Show("Please select the restaurant");
            }
        }


        private void charValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void Bindchanneldtls(ComboBox cmbchanl)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _objbal.Getchanneldtls();
                cmbchanl.ItemsSource = ds.Tables[0].DefaultView;
                cmbchanl.DisplayMemberPath = ds.Tables[0].Columns["ChannelName"].ToString();
                cmbchanl.SelectedValuePath = ds.Tables[0].Columns["ChannelId"].ToString();
                this.Cbochannel.SelectedValue = ds.Tables[0].Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnpartycmb_Click(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();
            getMenu("PartyCombos");
            lblMenutype.Content = "PartyCombos";
            lblNewDish.Content = "";
        }

        private void btnansp_Click(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();
            getMenu("AcSpslCombos");
            lblMenutype.Content = "AcSpslCombos";
            lblNewDish.Content = "";
        }
        private void btndishnotavail_Click(object sender, RoutedEventArgs e)
        {
            DishesNotAvailable dn = new DishesNotAvailable();
            dn.ShowDialog();
        }
        public void vkb()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System)
                + System.IO.Path.DirectorySeparatorChar + "osk.exe");
        }

        private void txtCustInstructions_GotFocus(object sender, RoutedEventArgs e)
        {
            // vkb();
        }

        private void txtCustInstructions_LostFocus(object sender, RoutedEventArgs e)
        {
            //foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            //{
            //    process.Kill();
            //}
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("SearchCustomer.xaml", UriKind.Relative));
        }
    }
}
