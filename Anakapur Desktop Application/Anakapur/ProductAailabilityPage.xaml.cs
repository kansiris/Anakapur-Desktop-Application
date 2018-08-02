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
using AnkapurDAL;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for ProductAailabilityPage.xaml
    /// </summary>
    public partial class ProductAailabilityPage : Page
    {
        public CoreDAL _objdal = new CoreDAL();
        private ProductsBal _objbal = new ProductsBal();
        ProductProperties ppr = new ProductProperties();
        string connStr = "";
        public ProductAailabilityPage()
        {
            InitializeComponent();
            connStr = _objdal.constring().ToString();
            GetProdDetails();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dt;
                int ind = 0;
                ind = GridProducts.SelectedIndex;
                if (ind >= 0)
                {
                    //if (GridProducts.Items.Count > 0)
                    //{
                    dt = GridProducts.Items.GetItemAt(ind) as DataRowView;
                    if (dt.Row[0].ToString() == "" || dt.Row[5].ToString() == "")
                    {
                        MessageBox.Show("Please update the Availabilty");
                    }
                    //else if (dt.Row[13].ToString() == "")
                    //{
                    //    MessageBox.Show("Please update the Stock in hand");
                    //}
                    else
                    {
                        ppr.ProductID = dt.Row[0].ToString();
                        ppr.Available = bool.Parse(dt.Row[5].ToString());
                        ppr.Remarks = dt.Row[6].ToString();
                        //ppr.SIH = Convert.ToInt32(dt.Row[13].ToString());
                       // ppr.Restcode = dt.Row["RestCode"].ToString();
                        string prd = _objbal.EditProducts(ppr);
                        MessageBox.Show("Products Updated Successfully", "Product Details", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else { MessageBox.Show("Please Select the Products", "Search  Products", MessageBoxButton.OK, MessageBoxImage.Error); }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetProdDetails()
        {

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

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton element in stkRadio.Children)
            {
                var restButton = element.Name;
                RadioButton rd = new RadioButton();
                rd = (RadioButton)this.FindName(restButton.ToString());
                if (rd.IsChecked == true)
                {

                    DataSet dt = new DataSet();
                    //dt = _objbal.GetProdData(rd.Content.ToString());
                    dt = _objbal.GetProdData("tblProductMaster");

                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        GridProducts.ItemsSource = dt.Tables[0].DefaultView;
                    }
                    else
                    {
                        MessageBox.Show("Unable to load the Data");
                    }
                }
            }
        }
        public void radioBtns(DataTable dtb)
        {
            //Filling dynamically the Restuarants in radio buttons
            //{
            //    //Filling dynamically the Restuarants in radio buttons
            //    DataTable dt1 = new DataTable();
            //    dt1 = dtb;
            //    string restCode;
            //    if (Application.Current.Properties["restcode"].ToString().Length > 0)
            //    {
            //        restCode = Application.Current.Properties["restcode"].ToString().Trim();
            //    }
            //    else
            //    { restCode = ""; }
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
            //        if (row.ItemArray[0].ToString().Trim() == restCode) { rd.IsChecked = true; }
            //         if (row.ItemArray[0].ToString().Trim() == "ZZ") { rd.Visibility = Visibility.Hidden; }
            //        stkRadio.Children.Add(rd);
            //    }
            //}

            DataTable dt1 = new DataTable();
            dt1 = dtb;
            string restCode;
            if (Application.Current.Properties["restcode"].ToString().Length > 0)
            {
                restCode = Application.Current.Properties["restcode"].ToString().Trim();
            }
            else
            { restCode = ""; }
            foreach (DataRow row in dtb.Rows)
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

                stkRadio.Children.Add(rd);
            }
        }
        private void btndone_Click(object sender, RoutedEventArgs e)
        {

            //Employee emp = new Employee();
            //emp.Show();
        }
    }
}
