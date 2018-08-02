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
using AnkapurBAL;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using AnkapurDAL;
using System.IO;
using System.Globalization;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {

        decimal PriceSum ,TotalPrice,Deliverycharges, cgstcharges, sgstcharges, revenue, tips, discounts;

        public CoreDAL _objdal = new CoreDAL();
        private TicketsBal _objbal = new TicketsBal();
        private Reportsbal rpbal = new Reportsbal();
        string connStr = "";
        public ReportsPage()
        {
            InitializeComponent();
            connStr = _objdal.constring().ToString();
            GetreportDetails();
            dtpicker.Text = System.DateTime.Now.ToString();
        }
        public void GetreportDetails()
        {
            //try
            //{
            //    DataTable dt = new DataTable();

            //    dt = _objbal.getrestaurants();

            //    radioBtns(dt);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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
            //{
            //    //Filling dynamically the Restuarants in radio buttons
            //    DataTable dt1 = new DataTable();
            //    dt1 = dt;
            //    foreach (DataRow row in dt1.Rows)
            //    {
            //        RadioButton rd = new RadioButton();
            //        rd.GroupName = "Rest";
            //        rd.Name = "rdbtn" + row.ItemArray[0].ToString().Trim();
            //        rd.Content = row.ItemArray[0].ToString();
            //        var toReg1 = (RadioButton)this.FindName(rd.Name);
            //        if (toReg1 == null)
            //        {
            //            this.RegisterName(rd.Name, rd);
            //        }
            //        if (row.ItemArray[0].ToString().Trim() == "HN") { rd.IsChecked = true; }
            //        else if (row.ItemArray[0].ToString().Trim() == "ZZ") { rd.Visibility = Visibility.Hidden; }
            //        stkRadioBtn.Children.Add(rd);
            //    }
            //}
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
                    { rd.IsEnabled = false; }
                    else { rd.IsEnabled = true; }

                }

                stkRadioBtn.Children.Add(rd);
            }
        }
        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            string orderid = clicked.Content.ToString();
            if (orderid.Length > 0)
            {
                Application.Current.Properties["orderId"] = orderid;
                var newWindow = new LastOrderView();

                newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                newWindow.Show();
            }
            else { MessageBox.Show("Sorry there was no last order", "Last order", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            PriceSum = 0; 
            TotalPrice = 0;
            Deliverycharges = 0;
            cgstcharges = 0;
            sgstcharges = 0; 
            revenue = 0; 
            tips = 0; 
            discounts = 0; 
            string restCode = "";
            DateTime selDate;
            int reportstatus = 0;
            foreach (RadioButton element in stkRadioBtn.Children)
            {
                var restButton = element.Name;
                RadioButton rd = new RadioButton();
                rd = (RadioButton)this.FindName(restButton.ToString());
                if (rd.IsChecked == true)
                {
                    restCode = (rd.Content.ToString());
                }
            }
            if (cboreports.SelectionBoxItem.ToString().Trim() == "Daily")
            {
                reportstatus = Convert.ToInt32(((ComboBoxItem)this.cboreports.SelectedValue).Tag.ToString());
                if (restCode.Length > 0)
                {
                    selDate = Convert.ToDateTime(dtpicker.Text.ToString());
                    selDate = Convert.ToDateTime(String.Format("{0:dd-MM-yyyy}", selDate));
                    DataSet ds = new DataSet();
                    ds = rpbal.getdailyreports(selDate);

                    DataTable result = ds.Tables[0];
                                       
                    List<DataRow> list = result.AsEnumerable().ToList();

                   var data = (from DataRow row in result.Rows
                                        select new repo()
                                        {
                                            OrderId = row["OrderId"].ToString(),
                                            amountPaid = row["amountPaid"].ToString(),
                                            TotalPrice = row["TotalPrice"].ToString(),
                                            cgstcharges = row["cgstcharges"].ToString(),
                                            sgstcharges = row["sgstcharges"].ToString(),
                                            Deliverycharges = row["Deliverycharges"].ToString(),
                                            status = row["statusid"].ToString(),
                                            Tip = row["Tip"].ToString(),
                                            Discount = row["Discount"].ToString(),
                                            
                                        }).ToList();

                    foreach (var item in data)
                    {

                        string amount = item.amountPaid;
                        string total = item.TotalPrice;
                        if (total == null || total == "")
                        {
                            total = "0";
                        }
                        string cgst = item.cgstcharges;
                        string sgst = item.sgstcharges;
                        string deliverycharges = item.Deliverycharges;
                        string status = item.status;
                        string tip = item.Tip;
                        string disco = item.Discount;


                        if (item.status != "8")
                        {
                            TotalPrice = TotalPrice + decimal.Parse(total);
                            Deliverycharges = Deliverycharges + decimal.Parse(deliverycharges);
                            sgstcharges = sgstcharges + decimal.Parse(sgst);
                            cgstcharges = cgstcharges + decimal.Parse(cgst);
                            tips = tips + decimal.Parse(tip);
                            discounts = discounts + decimal.Parse(disco);
                            revenue = TotalPrice + Deliverycharges + sgstcharges + cgstcharges + tips - discounts;
                            PriceSum = PriceSum + decimal.Parse(amount);
                        }
                    }
                    var r = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(revenue));
                    var p = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(PriceSum));

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    int sumObject;
                    //    object sumobject1;
                    //    int sumobject2;
                    //    int sumobject3;
                    //    int sumobject4;
                    //    int sumobject5;


                    //    sumObject = Convert.ToInt32(ds.Tables[0].Compute("Sum(TotalPrice)", "restcode ='" + restCode + "'"));
                    //    sumobject2 = Convert.ToInt32(ds.Tables[0].Compute("Sum(Deliverycharges)", "restcode ='" + restCode + "'"));
                    //    sumobject3 = Convert.ToInt32(ds.Tables[0].Compute("Sum(cgstcharges)", "restcode ='" + restCode + "'"));
                    //    sumobject4 = Convert.ToInt32(ds.Tables[0].Compute("Sum(sgstcharges)", "restcode ='" + restCode + "'"));
                    //    sumobject5 = sumObject + sumobject2 + sumobject3 + sumobject4;
                    //    sumobject1 = ds.Tables[0].Compute("Sum(amountPaid)", "restcode ='" + restCode + "'");

                    //txtrevenue.Text = "Revenue of the Day : Rs." + sumobject5.ToString();//ds.Tables[1].Rows[0][0].ToString();
                    //txtamountpaid.Text = "AmountPaid of Day :Rs." + sumobject1.ToString();

                    txtrevenue.Text = "Revenue of the Day : Rs." + r;//ds.Tables[1].Rows[0][0].ToString();
                    txtamountpaid.Text = "AmountPaid of Day :Rs." + p;
                    DataView dv = new DataView(ds.Tables[0]);
                        if (reportstatus != 0) { dv.RowFilter = "restcode ='" + restCode + "'"; }
                        else { dv.RowFilter = "OrderDate ='" + selDate + "'"; }
                        dgreportsData.ItemsSource = dv;
                    //}
                    //else { MessageBox.Show("There are no Orders Today","Reports",MessageBoxButton.OK,MessageBoxImage.Information); }
                }
                else { MessageBox.Show("Select Restaurant"); }
            }
            else if (cboreports.SelectionBoxItem.ToString().Trim() == "Weekly")
            {
                reportstatus = Convert.ToInt32(((ComboBoxItem)this.cboreports.SelectedValue).Tag.ToString());
                if (restCode.Length > 0)
                {
                    selDate = Convert.ToDateTime(dtpicker.Text.ToString());
                    selDate = Convert.ToDateTime(String.Format("{0:dd-MM-yyyy}", selDate));
                    //todate=Convert.ToDateTime(selDate-7)
                    DataSet ds = new DataSet();
                    ds = rpbal.getweeklyreports(selDate);


                    DataTable result = ds.Tables[0];

                    List<DataRow> list = result.AsEnumerable().ToList();

                    var data = (from DataRow row in result.Rows
                                select new repo()
                                {
                                    OrderId = row["OrderId"].ToString(),
                                    amountPaid = row["amountPaid"].ToString(),
                                    TotalPrice = row["TotalPrice"].ToString(),
                                    cgstcharges = row["cgstcharges"].ToString(),
                                    sgstcharges = row["sgstcharges"].ToString(),
                                    Deliverycharges = row["Deliverycharges"].ToString(),
                                    status = row["statusid"].ToString(),
                                    Tip = row["Tip"].ToString(),
                                    Discount = row["Discount"].ToString(),

                                }).ToList();

                    foreach (var item in data)
                    {

                        string amount = item.amountPaid;
                        string total = item.TotalPrice;
                        if (total == null || total == "")
                        {
                            total = "0";
                        }
                        string cgst = item.cgstcharges;
                        string sgst = item.sgstcharges;
                        string deliverycharges = item.Deliverycharges;
                        string status = item.statusdiscription;
                        string tip = item.Tip;
                        string disco = item.Discount;


                        if (item.status != "8")
                        {
                            TotalPrice = TotalPrice + decimal.Parse(total);
                            Deliverycharges = Deliverycharges + decimal.Parse(deliverycharges);
                            sgstcharges = sgstcharges + decimal.Parse(sgst);
                            cgstcharges = cgstcharges + decimal.Parse(cgst);
                            tips = tips + decimal.Parse(tip);
                            discounts  = discounts + decimal.Parse(disco);
                            revenue = TotalPrice + Deliverycharges + sgstcharges + cgstcharges + tips - discounts;
                            PriceSum = PriceSum + decimal.Parse(amount);
                        }
                    }
                    var r = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(revenue));
                    var p = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(PriceSum));




                    //int sumObject;
                    //object sumobject1;
                    //int sumobject2;
                    //int sumobject3;
                    //int sumobject4;
                    //int sumobject5;
                    //sumObject = Convert.ToInt32(ds.Tables[0].Compute("Sum(TotalPrice)", "restcode ='" + restCode + "'"));
                    //sumobject2 = Convert.ToInt32(ds.Tables[0].Compute("Sum(Deliverycharges)", "restcode ='" + restCode + "'"));
                    //sumobject3 = Convert.ToInt32(ds.Tables[0].Compute("Sum(cgstcharges)", "restcode ='" + restCode + "'"));
                    //sumobject4 = Convert.ToInt32(ds.Tables[0].Compute("Sum(sgstcharges)", "restcode ='" + restCode + "'"));
                    //sumobject5 = sumObject + sumobject2 + sumobject3 + sumobject4;
                    //sumobject1 = ds.Tables[0].Compute("Sum(amountPaid)", "restcode ='" + restCode + "'");

                    //txtrevenue.Text = "Revenue of the week : Rs." + sumobject5.ToString();
                    //txtamountpaid.Text = "AmountPaid of Week :Rs." + sumobject1.ToString();
                    //txtrevenue.Text = ds.Rows[1]["Revenue"].ToString();

                    txtrevenue.Text = "Revenue of the week : Rs." + r;
                    txtamountpaid.Text = "AmountPaid of Week :Rs." + p;
                    DataView dv = new DataView(ds.Tables[0]);
                    if (reportstatus != 0) { dv.RowFilter = "restcode ='" + restCode + "'"; }
                    else { dv.RowFilter = "OrderDate ='" + selDate + "'"; }
                    dgreportsData.ItemsSource = dv;
                }
                else { MessageBox.Show("Select Restaurant"); }
            }
            else if (cboreports.SelectionBoxItem.ToString().Trim() == "Monthly")
            {
                reportstatus = Convert.ToInt32(((ComboBoxItem)this.cboreports.SelectedValue).Tag.ToString());
                if (restCode.Length > 0)
                {
                    selDate = Convert.ToDateTime(dtpicker.Text.ToString());
                    selDate = Convert.ToDateTime(String.Format("{0:dd-MM-yyyy}", selDate));
                    DataSet ds = new DataSet();
                    ds = rpbal.getmonthlyreports(selDate);


                    DataTable result = ds.Tables[0];

                    List<DataRow> list = result.AsEnumerable().ToList();

                    var data = (from DataRow row in result.Rows
                                select new repo()
                                {
                                    OrderId = row["OrderId"].ToString(),
                                    amountPaid = row["amountPaid"].ToString(),
                                    TotalPrice = row["TotalPrice"].ToString(),
                                    cgstcharges = row["cgstcharges"].ToString(),
                                    sgstcharges = row["sgstcharges"].ToString(),
                                    Deliverycharges = row["Deliverycharges"].ToString(),
                                    status = row["statusdiscription"].ToString(),
                                    Tip = row["Tip"].ToString(),
                                    Discount = row["Discount"].ToString(),

                                }).ToList();

                    foreach (var item in data)
                    {

                        string amount = item.amountPaid;
                        string total = item.TotalPrice;
                        if (total == null || total == "")
                        {
                            total = "0";
                        }
                        string cgst = item.cgstcharges;
                        string sgst = item.sgstcharges;
                        string deliverycharges = item.Deliverycharges;
                        string status = item.status;
                        string tip = item.Tip;
                        string disco = item.Discount;


                        if (item.status != "8")
                        {
                            TotalPrice = TotalPrice + decimal.Parse(total);
                            Deliverycharges = Deliverycharges + decimal.Parse(deliverycharges);
                            sgstcharges = sgstcharges + decimal.Parse(sgst);
                            cgstcharges = cgstcharges + decimal.Parse(cgst);
                            tips = tips + decimal.Parse(tip);
                            discounts = discounts + decimal.Parse(disco);
                            revenue = TotalPrice + Deliverycharges + sgstcharges + cgstcharges + tips - discounts;
                            PriceSum = PriceSum + decimal.Parse(amount);
                        }
                    }
                    var r = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(revenue));
                    var p = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(PriceSum));



                    //int sumObject;
                    //object sumobject1;
                    //int sumobject2;
                    //int sumobject3;
                    //int sumobject4;
                    //int sumobject5;
                    //sumObject = Convert.ToInt32(ds.Tables[0].Compute("Sum(TotalPrice)", "restcode ='" + restCode + "'"));
                    //sumobject2 = Convert.ToInt32(ds.Tables[0].Compute("Sum(Deliverycharges)", "restcode ='" + restCode + "'"));
                    //sumobject3 = Convert.ToInt32(ds.Tables[0].Compute("Sum(cgstcharges)", "restcode ='" + restCode + "'"));
                    //sumobject4 = Convert.ToInt32(ds.Tables[0].Compute("Sum(sgstcharges)", "restcode ='" + restCode + "'"));
                    //sumobject5 = sumObject + sumobject2 + sumobject3 + sumobject4;
                    //sumobject1 = ds.Tables[0].Compute("Sum(amountPaid)", "restcode ='" + restCode + "'");

                    //txtrevenue.Text = "Revenue of the month : Rs." + sumobject5.ToString();
                    //txtamountpaid.Text = "AmountPaid of Month :Rs." + sumobject1.ToString();

                    txtrevenue.Text = "Revenue of the month : Rs." + r;
                    txtamountpaid.Text = "AmountPaid of Month :Rs." + p;
                    DataView dv = new DataView(ds.Tables[0]);
                    if (reportstatus != 0) { dv.RowFilter = "restcode ='" + restCode + "'"; }
                    else { dv.RowFilter = "OrderDate ='" + selDate + "'"; }
                    dgreportsData.ItemsSource = dv;
                }
                else { MessageBox.Show("Select Restaurant"); }
            }
        }

        private void btnexport_Click(object sender, RoutedEventArgs e)
        {
            string restCode = "";
            foreach (RadioButton element in stkRadioBtn.Children)
            {
                var restButton = element.Name;
                RadioButton rd = new RadioButton();
                rd = (RadioButton)this.FindName(restButton.ToString());
                if (rd.IsChecked == true)
                {
                    restCode = (rd.Content.ToString());
                }
            }
            if (restCode.Length > 0)
            {
                DateTime selDate;
                selDate = Convert.ToDateTime(dtpicker.Text.ToString());
                selDate = Convert.ToDateTime(String.Format("{0:dd-MM-yyyy}", selDate));
                DataSet ds = new DataSet();
                if (cboreports.SelectionBoxItem.ToString().Trim() == "Daily")
                {
                    ds = rpbal.getdailyreportsexcel(selDate);
                }
                else if (cboreports.SelectionBoxItem.ToString().Trim() == "Weekly")
                {
                    ds = rpbal.getweeklyreportsexcel(selDate);
                }
                else if (cboreports.SelectionBoxItem.ToString().Trim() == "Monthly")
                {
                    ds = rpbal.getmonthlyreportsexcel(selDate);
                }

                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.RowFilter = "restcode ='" + restCode + "'";
                dt = dv.ToTable();
                //dt= dt.Columns[0].ColumnMapping =MappingType.Hidden;
                // string strFilePath = @"C:\Users\SITPL6\Desktop\AnkapursalesReport.csv";
              // string strFilePath = @"C:\Users\user\Desktop\AnkapursalesReport.csv";//hn
                  string strFilePath = @"C:\Users\xsisireesh\Desktop\AnkapursalesReport.csv";
                //  string strFilePath = @"C:\Users\xsirama\Documents\AnkapursalesReport.csv"; //saroja
                // string strFilePath = @"C:\Users\Ankapur Chicken\Desktop\AnkapursalesReport.csv"; //asr
                // string strFilePath = @"C:\Users\SITPL6\Desktop\AnkapursalesReport.csv"; //kp

           
                CreateCSVFile(dt, strFilePath);

            }
            else
            { MessageBox.Show("Please select the restaurant"); }
        }
        public void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)

        {
            //  CSV file to which grid data will be exported.
            //string strFilePath = @"C:\myCSVfile.csv";
            try
            {
                StreamWriter sw = new StreamWriter(strFilePath, false);
                int iColCount = dtDataTablesList.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dtDataTablesList.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);

                // Now write all the rows.

                foreach (DataRow dr in dtDataTablesList.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)

                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }

                sw.Close();
                MessageBox.Show("Data exported successfully");

            }
            catch (Exception)
            {
                MessageBox.Show("Please close the existing file to save the data");
            }
        }

        public class repo
        {
            public string OrderId { get; set; }
            public string OrderDate { get; set; }
            //   public string OrderTime { get; set; }
            public string restcode { get; set; }
            //   public string Totalamount { get; set; }
            public string Orderstatus { get; set; }
            public string status { get; set; }
            public string customerphone { get; set; }
            public string statusdiscription { get; set; }
            public string customerfname { get; set; }
            public string customerlname { get; set; }
            public string Billing_Address { get; set; }
            public string Delivery_Addresss { get; set; }
            public string empcode { get; set; }

            public string Quantity { get; set; }
            public string TotalPrice { get; set; }
            public string Deliverycharges { get; set; }
            public string cgstcharges { get; set; }
            public string sgstcharges { get; set; }
            public string Discount { get; set; }
            public string Tip { get; set; }
            public string amountPaid { get; set; }
            public string Remarks { get; set; }
            public string OrderType { get; set; }
            public string TransactionId { get; set; }

            public string TransactionStatus { get; set; }

            public List<repo> Orderinfo { get; set; }

        }
    }
}
