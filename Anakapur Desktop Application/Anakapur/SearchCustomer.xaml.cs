using AnkapurBAL;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using System.Windows.Data;
using MahApps.Metro.Controls;
using System.Windows.Interop;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;



//Do not remove the below line
//API 3mrcDN85gFcdksMCctBl ~Npoo2wRVtC6h1tQTxvhnmg~Ap17BfInLNVFV6LDJv18zWNHetTtlyDPu2Un9yLYY9mpGL2fUP-FY_BMMIon7ACj
namespace Anakapur
{
    /// <summary>
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    public partial class SearchCustomer : Page
    {
        private CustomerSearchBal _objBal = new CustomerSearchBal();
        CustomerSearchProperties cs = new CustomerSearchProperties();
        static HttpClient client = new HttpClient();
        //// string connStr = "Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";

        Microsoft.Maps.MapControl.WPF.Design.LocationConverter locConverter = new LocationConverter();




        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //  Disables the default mouse double-click action.
            e.Handled = true;
            myMap.Children.Clear();
            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(this.myMap);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

            // The pushpin to add to the map.
            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;
            string[] latlong;
            latlong = pin.Location.ToString().Split(',');
            lblLat.Content = latlong[0].ToString();
            lblLong.Content = latlong[1].ToString();

            // Adds the pushpin to the map.
            myMap.Children.Add(pin);


        }
        public void vkb()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) +
                Path.DirectorySeparatorChar + "osk.exe");
        }

        private void addPins()
        {
            if (lblLat.Content.ToString().Length > 0)
            {
                myMap.Children.Clear();
                Pushpin pin = new Pushpin();
                Location pinLocation = new Location();// lblLat.Content.ToString() + "," + lblLong.Content.ToString();
                pinLocation.Latitude = double.Parse(lblLat.Content.ToString());
                pinLocation.Longitude = double.Parse(lblLong.Content.ToString());
                pin.Location = pinLocation;
                //string[] latlong;
                //latlong = pin.Location.ToString().Split(',');
                //lblLat.Content = latlong[0].ToString();
                //lblLong.Content = latlong[1].ToString();

                //   A/dds the pushpin to the map.
                myMap.Children.Add(pin);
            }

        }




        public SearchCustomer()
        {
            InitializeComponent();
            //RunAsync().Wait();
            txtCustomerName.Focus();
            myMap.Focus();
            clear();
            txtCustomerName.TabIndex = 0;
            txtCustomerName.Focus();
            gridCustomerSearch.Visibility = Visibility.Visible;
            stkListView.Visibility = Visibility.Hidden;
            stkNewCustomer.Visibility = Visibility.Hidden;
            txtDeliverAddress.Visibility = Visibility.Hidden;
            lbllandmark.Visibility = Visibility.Hidden;
            lbldeladd.Visibility = Visibility.Hidden;
            txtLandMark.Visibility = Visibility.Hidden;

        }

        //Ramesh sample Code
        #region ramesh

        public async void getphonenumber()
        {
            string url = "https://konnectprodstream3.knowlarity.com:8200/update-stream/7887d237-b541-11e6-9504-066beb27a027/konnect";
            callinfo x =await GetProductAsync(url);
            //HttpClient client = new HttpClient();
            //string url = "https://konnectprodstream3.knowlarity.com:8200/update-stream/7887d237-b541-11e6-9504-066beb27a027/konnect";
            //var getStringTask = client.GetStringAsync(url);
        }

        public class callinfo
        {
            public string dispnumber { get; set; }
            public string caller_id { get; set; }
            public decimal Call_Type { get; set; }
            public string uuid { get; set; }
        }

        static async Task RunAsync()
        {
            //HttpClient client = new HttpClient();
            string url = "https://konnectprodstream3.knowlarity.com:8200/update-stream/7887d237-b541-11e6-9504-066beb27a027/konnect";
            // New code:
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            callinfo callinfo = await GetProductAsync(url);
            
        }

        static async Task<callinfo> GetProductAsync(string path)
        {
           // HttpClient client = new HttpClient();
            callinfo product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<callinfo>();
            }
            return product;
        }




        //private static async Task TestConcurrency()
        //{
        //    int threads = 5;
        //    var tasks = new List<Task>();
        //    CAPI api = new CAPI("rosette api key");
        //    foreach (int task in Enumerable.Range(0, threads))
        //    {
        //        Console.WriteLine("Starting task {0}", task);
        //        tasks.Add(Task.Factory.StartNew(() => runLookup(task, api)));
        //    }
        //    await Task.WhenAll(tasks);
        //    Console.WriteLine("Test complete");
        //}

        //private static Task runLookup(int taskId, CAPI api)
        //{
        //    int calls = 5;
        //    string contentUri = "http://www.foxsports.com/olympics/story/chad-le-clos-showed-why-you-never-talk-trash-to-michael-phelps-080916";
        //    for (int i = 0; i < calls; i++)
        //    {
        //        Console.WriteLine("Task ID: {0} call {1}", taskId, i);
        //        try
        //        {
        //            var result = api.Entity(contentUri: contentUri);
        //            Console.WriteLine("Concurrency: {0}, Result: {1}", api.Concurrency, result);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //        }
        //    }
        //    return Task.CompletedTask;
        //}

        //private void btnCustSearch_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    (sender as TextBox).SelectAll();
        //}

        #endregion
        // Ramesh Sample code



        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            NewOrder no = new NewOrder();
            no.wrpPanel.Visibility = Visibility.Visible;
            Application.Current.Properties["custPhone"] = txtPhone.Text.ToString();

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("NewOrder.xaml", UriKind.RelativeOrAbsolute));

        }
        private void btnCustSearch_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("SearchCustomer.xaml", UriKind.RelativeOrAbsolute));
            gridCustomerSearch.Visibility = Visibility.Visible;
            //stkListView.Visibility = Visibility.Hidden;
            //stkNewCustomer.Visibility = Visibility.Hidden;
        }

        private void lvOrders_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Filling the selected customer name
            var item = sender as ListViewItem;
            // var row = new DataRow();
            DataRowView CompRow;
            int SComp;
            SComp = lstCustomerResult.SelectedIndex;
            if (SComp >= 0)
            {
                CompRow = lstCustomerResult.Items.GetItemAt(SComp) as DataRowView;
                lblCustomerName.Content = CompRow.Row[0] + "  " + CompRow.Row[1];
                //lstCustomerResult.Visibility = Visibility.Hidden;
                stkNewCustomer.Visibility = Visibility.Visible;
                txtDeliverAddress.Visibility = Visibility.Visible;
                lbllandmark.Visibility = Visibility.Visible;
                lbldeladd.Visibility = Visibility.Visible;
                txtLandMark.Visibility = Visibility.Visible;

                txtFname.Text = CompRow["CustomerFName"].ToString();
                txtLname.Text = CompRow["CustomerLName"].ToString();
                txtPhone.Text = CompRow["CustPhoneNumber"].ToString();
                txtDeliverAddress.Text = CompRow["Delivery_Addresss"].ToString();
                txtMobile1.Text = CompRow["Mobile1"].ToString();
                txtMobile2.Text = CompRow["Mobile2"].ToString();
                cboCustType.Text = CompRow["CustomerType"].ToString();
                lblLat.Content = CompRow["DeliveryLocationLatitude"].ToString();
                lblLong.Content = CompRow["DeliveryLocationLongitude"].ToString();
                txtLandMark.Text = CompRow["Land_mark"].ToString();
                addPins();
                btnSaveNewCustomer.Visibility = Visibility.Hidden;
                expandRes.IsExpanded = false;
            }
        }

        private void btnCustomerSearch_Click(object sender, RoutedEventArgs e)
        {
            //if (txtCustomerName.Text.Length == 0 || txtCustomerName.Text == "")
            //{ MessageBox.Show("Please Enter The Customer Details to Search"); }
            myMap.Children.Clear();
            if (lstCustomerResult.Items.Count > 0) { lstCustomerResult.ItemsSource = null; }

            if (txtCustomerName.Text.Trim() != string.Empty)
                cs.CustomerFName = txtCustomerName.Text.Trim();
            else

                cs.CustomerFName = null;
            cs.CustPhoneNumber = txtCustomerName.Text.Trim();
            //   @ Indu--->> Search Customer Move this code into DAL
            DataTable dt = new DataTable();
            dt = _objBal.getCustomer(cs);
            clear();
            if (dt.Rows.Count > 0)
            {
                expandRes.IsExpanded = true;

                if ((dt.Rows[0][0].ToString() != "Customer Does not Exists"))
                {
                    lstCustomerResult.ItemsSource = dt.DefaultView;
                    stkListView.Visibility = Visibility.Visible;
                    stkNewCustomer.Visibility = Visibility.Hidden;
                    txtDeliverAddress.Visibility = Visibility.Hidden;
                    lbllandmark.Visibility = Visibility.Hidden;
                    lbldeladd.Visibility = Visibility.Hidden;
                    txtLandMark.Visibility = Visibility.Hidden;
                    lstCustomerResult.ItemsSource = dt.DefaultView;
                    btnSaveNewCustomer.Visibility = Visibility.Hidden;
                    btnEditCustomer.Visibility = Visibility.Visible;
                    // CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstCustomerResult.ItemsSource);
                    //   PropertyGroupDescription groupDescription = new PropertyGroupDescription("CustPhoneNumber");
                    //      view.GroupDescriptions.Add(groupDescription);
                }

                else
                {
                    stkListView.Visibility = Visibility.Hidden;
                    stkNewCustomer.Visibility = Visibility.Visible;
                    txtDeliverAddress.Visibility = Visibility.Visible;
                    lbllandmark.Visibility = Visibility.Visible;
                    lbldeladd.Visibility = Visibility.Visible;
                    txtLandMark.Visibility = Visibility.Visible;
                    btnEditCustomer.Visibility = Visibility.Hidden;
                    btnSaveNewCustomer.Visibility = Visibility.Visible;
                    MessageBox.Show("Customer not Found!!!", "Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                    expandRes.IsExpanded = false;
                }
            }


        }

        private void btnSaveNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            //@ Indu --->>Write code for insert new customer
            //try
            //{
            if (txtFname.Text == "" || txtLname.Text == "")
            {
                MessageBox.Show("Please Enter the Details");
            }
            else if (txtPhone.Text == "" || txtPhone.Text == null)
            {
                MessageBox.Show("Please Enter the Customer Phone");
                txtPhone.Focus();
            }
            else if (!Regex.IsMatch(txtMobile1.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Enter a valid Mobile Number.");
                txtMobile1.Select(0, txtMobile1.Text.Length);
                txtMobile1.Focus();
            }
            else if (!Regex.IsMatch(txtMobile2.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Enter a valid Mobile Number.");
                txtMobile2.Select(0, txtMobile2.Text.Length);
                txtMobile2.Focus();
            }
            else if (!Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Enter a valid Mobile Number.");
                txtPhone.Select(0, txtPhone.Text.Length);
                txtPhone.Focus();
            }
            else
            {
                SqlCommand com = new SqlCommand();
                cs.CustomerFName = txtFname.Text;
                cs.CustomerLName = txtLname.Text;
                cs.CustPhoneNumber = txtPhone.Text;
                cs.Delivery_Addresss = txtDeliverAddress.Text;
                cs.Billing_Address = txtDeliverAddress.Text;
                cs.CustomerTypeId = cboCustType.SelectedIndex;
                cs.Land_Mark = txtLandMark.Text;
                cs.Mobile1 = txtMobile1.Text;
                cs.Mobile2 = txtMobile2.Text;
                if (lblLat.Content != null)
                {
                    if (IsFloat(lblLat.Content.ToString()))
                    {
                        float lat = float.Parse(lblLat.Content.ToString());
                        cs.DeliveryLocationLatitude = lat;
                    }
                    else { cs.DeliveryLocationLatitude = null; }
                }
                else { cs.DeliveryLocationLatitude = null; }
                if (lblLong.Content != null)
                {
                    if (IsFloat(lblLong.Content.ToString()))
                    {
                        float lon = float.Parse(lblLong.Content.ToString());
                        cs.DeliveryLocationLongitude = lon;
                    }
                    else { cs.DeliveryLocationLongitude = null; }
                }
                else { cs.DeliveryLocationLongitude = null; }
                string cust = _objBal.AddNewCustomer(cs);
                MessageBox.Show("The New customer is added", "New Customer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //  clear();
            }
            //@ Indu --- >> Wite code to clear all the Text boxes           

        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (txtFname.Text == "" && txtLname.Text == "")
            {
                MessageBox.Show("Please Enter the Details");
            }
            else
            {
                SqlCommand com = new SqlCommand();
                cs.CustomerFName = txtFname.Text;
                cs.CustomerLName = txtLname.Text;
                if (IsInteger(txtPhone.Text.ToString())) { cs.CustPhoneNumber = txtPhone.Text; }

                cs.Delivery_Addresss = txtDeliverAddress.Text;
                cs.Billing_Address = txtDeliverAddress.Text;
                cs.CustomerTypeId = cboCustType.SelectedIndex;
                cs.Land_Mark = txtLandMark.Text;
                if (IsInteger(txtMobile1.Text.ToString())) { cs.Mobile1 = txtMobile1.Text; }
                else { cs.Mobile1 = null; }
                if (IsInteger(txtMobile2.Text.ToString())) { cs.Mobile2 = txtMobile2.Text; }
                else { cs.Mobile2 = null; }


                if (lblLat.Content != null)
                {
                    if (IsFloat(lblLat.Content.ToString()))
                    {
                        float lat = float.Parse(lblLat.Content.ToString());
                        cs.DeliveryLocationLatitude = lat;
                    }
                    else { cs.DeliveryLocationLatitude = null; }
                }
                else { cs.DeliveryLocationLatitude = null; }
                if (lblLong.Content != null)
                {
                    if (IsFloat(lblLong.Content.ToString()))
                    {
                        float lon = float.Parse(lblLong.Content.ToString());
                        cs.DeliveryLocationLongitude = lon;
                    }
                    else { cs.DeliveryLocationLongitude = null; }
                }
                else { cs.DeliveryLocationLongitude = null; }



                //  lat= Convert.ToDecimal(lblLat.Content);
                // cs.DeliveryLocationLongitude = lat;
                //  cs.DeliveryLocationLongitude = lon;
                string cust = _objBal.EditCustomer(cs);
                MessageBoxResult mb = MessageBox.Show("Customer updated Successfully", "Message", MessageBoxButton.OK);
                btnCustomerSearch_Click(sender, e);
            }

        }
        public void clear()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhone.Text = "";
            txtDeliverAddress.Text = "";
            txtDeliverAddress.Text = "";
            cboCustType.SelectedIndex = 1;
            txtLandMark.Text = "";
            lblLat.Content = "";
            lblLong.Content = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
        }

        private void btnPlaceNewOrder_Click(object sender, RoutedEventArgs e)
        {

            if (txtPhone.Text.ToString().Length > 0)
            {
                Application.Current.Properties["custPhone"] = txtPhone.Text;
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("NewOrder.xaml", UriKind.RelativeOrAbsolute));
            }

        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {

        }


        Regex regex = new Regex(@"^[0-9]+$");
        Regex regFloat = new Regex(@"^\d + (\.\d +) ?$");
        private bool IsInteger(string str)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                if (!regex.IsMatch(str))
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;

        }
        private bool IsFloat(string str)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                if (!regFloat.IsMatch(str))
                {
                    return true;
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;

        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnCustomerSearch_Click(sender, e);
            }
            //lostfocus();
        }

        private void btnCustomerSearch_GotFocus(object sender, RoutedEventArgs e)
        {

        }

      
        private void charValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPhone.SelectAll();
           // vkb();
        }

        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPhone.Text.Trim().Length > 0)
            {

                txtMobile1.Text = txtPhone.Text.ToString();
                txtMobile2.Text = txtPhone.Text.ToString();
            }
            //lostfocus();
        }

        private void expandRes_Expanded(object sender, RoutedEventArgs e)
        {
            expandRes.Header = "Collapse";
        }

        private void expandRes_Collapsed(object sender, RoutedEventArgs e)
        {
            expandRes.Header = "Expand";
        }
        public void lostfocus()
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

     
        private void txtFname_GotFocus(object sender, RoutedEventArgs e)
        {
           // vkb();
        }

        private void txtFname_LostFocus(object sender, RoutedEventArgs e)
        {
            //lostfocus();
        }

        private void txtLname_GotFocus(object sender, RoutedEventArgs e)
        {
           // vkb();
        }

        private void txtLname_LostFocus(object sender, RoutedEventArgs e)
        {
           // lostfocus();
        }

        private void txtDeliverAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            //vkb();
        }

        private void txtDeliverAddress_LostFocus(object sender, RoutedEventArgs e)
        {
           // lostfocus();
        }

        private void txtLandMark_GotFocus(object sender, RoutedEventArgs e)
        {
            //vkb();
        }

        private void txtLandMark_LostFocus(object sender, RoutedEventArgs e)
        {
            //lostfocus();
        }
      
        private void txtCustomerName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCustomerName.SelectAll();
           // vkb();
        }

        private void txtCustomerName_LostFocus(object sender, RoutedEventArgs e)
        {
            //lostfocus();
        }
    }

}
