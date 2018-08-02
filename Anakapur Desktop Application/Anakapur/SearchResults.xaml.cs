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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using AnkapurBAL;
using MahApps.Metro.Controls;
using AnkapurDAL;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Navigation;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchResults : Window
    {
        public CoreDAL _objdal = new CoreDAL();
        private CustomerSearchBal _objBal = new CustomerSearchBal();
        CustomerSearchProperties cs = new CustomerSearchProperties();
        SearchCustomer sc = new SearchCustomer();
        string connStr = "";
        public SearchResults()
        {
            InitializeComponent();
            connStr = _objdal.constring();



            sc.myMap.Children.Clear();
            if (lstCustomerResult.Items.Count > 0) { lstCustomerResult.ItemsSource = null; }
            string cust = Application.Current.Properties["newCust"].ToString();

            if (cust != string.Empty)
                cs.CustomerFName = cust;
            else

                cs.CustomerFName = null;
            cs.CustPhoneNumber = cust;
            //   @ Indu--->> Search Customer Move this code into DAL
            DataTable dt = new DataTable();
            dt = _objBal.getCustomer(cs);
            clear();
            if (dt.Rows.Count > 0)
            {
                //sc.expandRes.IsExpanded = true;

                if ((dt.Rows[0][0].ToString() != "Customer Does not Exists"))
                {
                    lstCustomerResult.ItemsSource = dt.DefaultView;
                    stkListView.Visibility = Visibility.Visible;
                    sc.stkNewCustomer.Visibility = Visibility.Visible;
                    lstCustomerResult.ItemsSource = dt.DefaultView;
                    sc.btnSaveNewCustomer.Visibility = Visibility.Hidden;
                    sc.btnEditCustomer.Visibility = Visibility.Visible;
                    // CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstCustomerResult.ItemsSource);
                    //   PropertyGroupDescription groupDescription = new PropertyGroupDescription("CustPhoneNumber");
                    //      view.GroupDescriptions.Add(groupDescription);
                }

                else
                {
                    stkListView.Visibility = Visibility.Hidden;
                    sc.stkNewCustomer.Visibility = Visibility.Visible;
                    sc.btnEditCustomer.Visibility = Visibility.Hidden;
                    sc.btnSaveNewCustomer.Visibility = Visibility.Visible;
                    MessageBox.Show("Customer not Found!!!", "Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void lstCustomerResult_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
         
            var item = sender as ListViewItem;
            // var row = new DataRow();
            DataRowView CompRow;
            int SComp;
            SComp = lstCustomerResult.SelectedIndex;
            if (SComp >= 0)
            {
                CompRow = lstCustomerResult.Items.GetItemAt(SComp) as DataRowView;
                sc.lblCustomerName.Content = CompRow.Row[0] + "  " + CompRow.Row[1];
                //lstCustomerResult.Visibility = Visibility.Hidden;
                //stkNewCustomer.Visibility = Visibility.Visible;
                sc.txtFname.Text = CompRow["CustomerFName"].ToString();
                sc.txtLname.Text = CompRow["CustomerLName"].ToString();
                sc.txtPhone.Text = CompRow["CustPhoneNumber"].ToString();
                sc.txtDeliverAddress.Text = CompRow["Delivery_Addresss"].ToString();
                sc.txtMobile1.Text = CompRow["Mobile1"].ToString();
                sc.txtMobile2.Text = CompRow["Mobile2"].ToString();
                sc.cboCustType.Text = CompRow["CustomerType"].ToString();
                sc.lblLat.Content = CompRow["DeliveryLocationLatitude"].ToString();
                sc.lblLong.Content = CompRow["DeliveryLocationLongitude"].ToString();
                sc.txtLandMark.Text = CompRow["Land_mark"].ToString();
                addPins();
                sc.btnSaveNewCustomer.Visibility = Visibility.Hidden;
                this.Close();

            }
        }
        public void clear()
        {
            sc.txtFname.Text = "";
            sc.txtLname.Text = "";
            sc.txtPhone.Text = "";
            sc.txtDeliverAddress.Text = "";
            sc.txtDeliverAddress.Text = "";
            sc.cboCustType.SelectedIndex = 1;
            sc.txtLandMark.Text = "";
            sc.lblLat.Content = "";
            sc.lblLong.Content = "";
            sc.txtMobile1.Text = "";
            sc.txtMobile2.Text = "";
        }
        private void addPins()
        {
            if (sc.lblLat.Content.ToString().Length > 0)
            {
                sc.myMap.Children.Clear();
                Pushpin pin = new Pushpin();
                Location pinLocation = new Location();// lblLat.Content.ToString() + "," + lblLong.Content.ToString();
                pinLocation.Latitude = double.Parse(sc.lblLat.Content.ToString());
                pinLocation.Longitude = double.Parse(sc.lblLong.Content.ToString());
                pin.Location = pinLocation;
                //string[] latlong;
                //latlong = pin.Location.ToString().Split(',');
                //lblLat.Content = latlong[0].ToString();
                //lblLong.Content = latlong[1].ToString();

                //   A/dds the pushpin to the map.
                sc.myMap.Children.Add(pin);
            }

        }

        //private void expandRes_Expanded(object sender, RoutedEventArgs e)
        //{
        //    expandRes.Header = "Collapse";
        //}

        //private void expandRes_Collapsed(object sender, RoutedEventArgs e)
        //{
        //    expandRes.Header = "Expand";
        //}
    }
}
