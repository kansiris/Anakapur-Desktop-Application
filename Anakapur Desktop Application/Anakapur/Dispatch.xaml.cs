using AnkapurBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using AnkapurDAL;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Dispatch.xaml
    /// </summary>
    /// //[getNumberOfOrderstoDelivBoy]
    /// //[updateDeliverBoy]
    //[getTodayNotDeliverByRest]
    //showOrderDetailsOfDelivBoy

    public partial class Dispatch : Page
    {
        public CoreDAL _objdal = new CoreDAL();
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        string connStr = ""; //"Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";
                             // string connStr = "Data Source=183.82.97.220;Initial Catalog=ankapur;Persist Security Info=True;User ID=test1;Password=123test";

        private DataGrid masterDataGridView = new DataGrid();

        private DataGrid detailsDataGridView = new DataGrid();



        public Dispatch()
        {
            InitializeComponent();
            //Binding orders to grid
            BindDataGrid();
            //Binding drivers
            BindInDrivers();
            connStr = _objdal.constring();

        }



        public void BindDataGrid()
        {
            //filling the Grid with orders for the restaurant
            string empCode;
            string restCode;
            // Application.Current.Properties["empcode"] = "";
            if (Application.Current.Properties["empcode"] == null) { empCode = "CA102"; }
            else
            {
                if ((Application.Current.Properties["empcode"].ToString().Length) > 0 || (Application.Current.Properties["empcode"]) != null)

                { empCode = Application.Current.Properties["empcode"].ToString(); }
                else { empCode = "CA102"; }
            }



            if (Application.Current.Properties["restcode"] == null) { restCode = "HN"; }
            else
            {
                if ((Application.Current.Properties["restcode"].ToString().Length) > 0 || (Application.Current.Properties["restcode"]) != null)

                { restCode = Application.Current.Properties["restcode"].ToString(); }
                else { restCode = "HN"; }
            }


            DataTable dt = new DataTable();
            SqlConnection connection;
            connStr = _objdal.constring();
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("spGetOrdersForDispatch1", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@restcode", restCode));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblOrderheader.Content = "Total Orders : " + dt.Rows.Count.ToString();
                dgOrders.ItemsSource = dt.DefaultView;
            }
            else
            {
                lblOrderheader.Content = "No Orders to assign !!! :) ";
                dgOrders.ItemsSource = null;
            }

        }
        public void BindInDrivers()
        {
            DataTable dt = new DataTable();
            b.flag = 4;
            if (Application.Current.Properties["restcode"] == null) { b.RestCode = "HN"; }
            else
            { b.RestCode = Application.Current.Properties["restcode"].ToString(); }

            DataSet ds = new DataSet();
            dt = _objbal.getInDrivers(b);
            lvInDrivers.ItemsSource = dt.DefaultView;

        }

        private void dgOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataTable dt = new DataTable();
            DataRowView CompRow;
            int SComp;
            SComp = dgOrders.SelectedIndex;
            CompRow = dgOrders.Items.GetItemAt(SComp) as DataRowView;
            string orderid = CompRow["OrderId"].ToString();

            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("spGetOrdersForDispatch", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OrderId", orderid));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dt);
            if (dt.Rows.Count > 0)
            {


            }
            else { MessageBox.Show("Sorry did not understand !!!"); }
        }

        private void lvInDrivers_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string clicked = button.Tag.ToString().Trim();
            DataTable dt = new DataTable();
            b.EmpCode = button.Tag.ToString();
            b.RestCode = Application.Current.Properties["restcode"].ToString();
            DataSet ds = new DataSet();
            dt = _objbal.getDeliveryBoyOrders(b);

            Drivers dr = new Drivers();
            dr.dataGrid.ItemsSource = dt.DefaultView;
            dr.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dr.ShowDialog();

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

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.Items.Count > 0)
            {

                var newWindow = new ShowOrderOnMap();

                newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                newWindow.Show();
            }
            else { MessageBox.Show("Sorry there are no orders", "Last order", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            DataRowView dt;
            int orders = 0;
            CheckBox chk = (CheckBox)sender;


            b.deliveryboy = chk.Content.ToString().Trim();
            orders = dgOrders.SelectedIndex;
            if (orders >= 0)
            {
                if (dgOrders.Items.Count > 0)
                {
                    dt = dgOrders.Items.GetItemAt(orders) as DataRowView;
                    b.OrderId = dt.Row["OrderId"].ToString();
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to dispatch ?", "Driver Dispatch", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        string Assgndelboy = _objbal.updatedelboys(b);
                    }
                    BindDataGrid();
                    BindInDrivers();
                }
                else
                { MessageBox.Show("Sorry There is no order to display", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                MessageBox.Show("Please select order", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                chk.IsChecked = false;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindDataGrid();
            BindInDrivers();
        }
    }
}
