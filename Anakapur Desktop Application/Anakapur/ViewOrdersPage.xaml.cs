using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using AnkapurDAL;
using System;
using AnkapurBAL;
namespace Anakapur
{
    /// <summary>
    /// Interaction logic for ViewOrdersPage.xaml
    /// </summary>
    public partial class ViewOrdersPage : Page
    {
        public CoreDAL _objdal = new CoreDAL();
        private Reportsbal rpbal = new Reportsbal();

        string connStr = "";//"Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";

        public ViewOrdersPage()
        {
            InitializeComponent();
            connStr = _objdal.constring().ToString();
            fillRest();
            fillOrderStatus();

            dtpicker.Text = System.DateTime.Now.ToString();

        }

        private void fillOrderStatus()
        {


        }

        private void fillRest()
        {
            //SqlConnection connection;
            //connStr= _objdal.constring();
            //connection = new SqlConnection(connStr);
            //if (connection.State.ToString() == "open") { connection.Close(); }

            //string CmdString = string.Empty;
            //// connection = _objdal.constring();
            //CmdString= " SELECT   [Rid]  ,[RestCode] ,[Name] FROM [Ankapur].[dbo].[tblRestuarant]  where restcode <>'zz' ";
            //SqlCommand cmd = new SqlCommand(CmdString, connection);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable("rest");
            //sda.Fill(dt);
            ////  dgCust.ItemsSource = dt.DefaultView;
            //connection.Close();
            //radioBtns(dt);
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
            //DataTable dt1 = new DataTable();
            //dt1 = dt;


            //foreach (DataRow row in dt.Rows)
            //{


            //    RadioButton rd = new RadioButton();
            //    rd.GroupName = "Rest";
            //    rd.Name = "rdbtn" + row.ItemArray[0].ToString().Trim();
            //    rd.Content = row.ItemArray[1].ToString();
            //    var toReg1 = (RadioButton)this.FindName(rd.Name);
            //    if (toReg1 == null)
            //    {
            //        this.RegisterName(rd.Name, rd);
            //    }
            //    if (row.ItemArray[0].ToString().Trim() == "HN") { rd.IsChecked = true; }
            //    stkRadioBtn.Children.Add(rd);
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
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                string restCode = "";
                string selDate = "";

                int status = 0;
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

                status = Convert.ToInt32(((ComboBoxItem)this.cboOrderStatus.SelectedValue).Tag.ToString());
                if (status == 3)
                {
                    status = 6;
                }
                selDate = dtpicker.Text.ToString();
            //selDate = String.Format("{0:dd-MM-yyyy}", selDate);
            selDate = Convert.ToDateTime(selDate).ToString("dd-MM-yyyy");
            if (restCode.Length > 0)
                {
                    SqlConnection con = new SqlConnection(connStr);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    SqlCommand cmd = new SqlCommand("AllOrdersSpDT", con);
                    cmd.Parameters.Add(new SqlParameter("@restcode", restCode));
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    DataView dv = new DataView(dt);
                    if (status != 0) { dv.RowFilter = "statusid ='" + status + "' and " + "OrderDate ='" + selDate + "'"; }
                    else { dv.RowFilter = "OrderDate ='" + selDate + "'"; }

                    dgOrdersData.ItemsSource = dv;
                    con.Close();
                    txtcount.Text = "Total Orders: " + dgOrdersData.Items.Count.ToString();


                }
                else { MessageBox.Show("Select Restaurant"); }
            //}
            ////catch(Exception)
            //{
            //    MessageBox.Show("server is busy please wait a moment!!!");
            //}
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

    }

}




