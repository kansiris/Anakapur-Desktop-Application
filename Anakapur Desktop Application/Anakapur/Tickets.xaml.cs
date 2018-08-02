using AnkapurBAL;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using System.Media;
using System.Windows.Media.Imaging;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Tickets1.xaml
    /// </summary>
    public partial class Tickets: MetroWindow
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        TicketsBal tbal = new TicketsBal();
        DataTable dSet = new DataTable();


        //string connStr = "Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";

        public Tickets()
        {
            
            
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(60);
            timer1.Tick += timer_Tick1;
            timer1.Start();
            addUserControl();
          
            if (Application.Current.Properties["restcode"] == null)
            {

                Application.Current.Properties["restcode"] = "HN";
            }
             
            ///To add functionality for refreshing every 30 secs

        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = SystemParameters.PrimaryScreenWidth +100;
            this.Width = 5000;
            this.WindowState = System.Windows.WindowState.Maximized;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Content = DateTime.Now.ToLongTimeString();     
        }

        void timer_Tick1(object sender, EventArgs e)
        {
            stkMain.Children.Clear();
            addUserControl();
        }

        private void addUserControl()
        {
            stkMain.Background = new SolidColorBrush(Colors.Azure);
            if (Application.Current.Properties["restcode"] == null)
            { b.RestCode = "BW"; }
            else

            { b.RestCode = Application.Current.Properties["restcode"].ToString(); }
            //  b.RestCode = "BW";
            dSet = _objbal.GetOrders(b);
            lblCurrentTime.Content = "Current Time :" + DateTime.Now.ToString("hh:mm");
            if (dSet.Rows.Count > 0)
            {

                
                lblTicketsPending.Content = dSet.Rows.Count.ToString();

                DataColumn ElapsedTime = new System.Data.DataColumn("ElapsedTime", typeof(System.String));
                DataColumn RowId = new System.Data.DataColumn("RowId", typeof(System.String));
                dSet.Columns.Add(ElapsedTime);
                dSet.Columns.Add(RowId);
                for (int i = 0; i < dSet.Rows.Count; i++)
                {
                    UCTickets uc = new UCTickets();
                    StackPanel sc = new StackPanel();

                    

                   
                    uc.Name = "UC" + i.ToString();
                    uc.lblOrderID.Content = dSet.Rows[i]["OrderId"].ToString();
                    uc.lblItemsCount.Content = "Items : " + dSet.Rows[i][0].ToString();
                    uc.txtUserRequests.Text = "Customer Request : " + dSet.Rows[i]["CustRequest"].ToString();
                    uc.txtDeliveryTime.Text = dSet.Rows[i]["ToBeDelivered"].ToString();
                    uc.lblordertype.Content =  dSet.Rows[i]["OrderType"].ToString();
                    uc.lblcustomername.Content= dSet.Rows[i]["CustomerFName"].ToString();
                    uc.lblcustphone.Content = dSet.Rows[i]["CustPhoneNumber"].ToString();
                    if (uc.lblordertype.Content.ToString() == "Mobile app  order")
                    {
                        uc.stkmn.Background = Brushes.LightBlue;
                        uc.imgmobicon.Visibility = Visibility.Visible;
                    }
                    if (dSet.Rows[i]["TransactionId"].ToString() == "")
                    {
                        uc.lblosts.Content = "Not Paid";
                    }
                    else if (dSet.Rows[i]["TransactionId"].ToString() == "COD")
                    {
                        uc.lblosts.Content = "Not Paid";
                    }
                    else
                    {
                        uc.lblosts.Content = "Paid";
                    }
                    DateTime dtOrderTime = Convert.ToDateTime(dSet.Rows[i]["OrderTime"].ToString());
                    TimeSpan timespan = new TimeSpan();
                    DateTime time = dtOrderTime.Add(timespan);
                    string displayTime = time.ToString("hh:mm");
                    //Display the order time hh:mm
                    uc.lblOrderTime.Content = "OrderTime : " + String.Format("{0:g}", displayTime);
                  
                    var b1 = DateTime.Parse(DateTime.Now.ToString()) - (DateTime.Parse(dtOrderTime.ToString()));
                  
                    var a1 = b1;
                    if (a1.Hours == 0)
                    {

                        if (a1.Minutes > 10 && a1.Minutes < 19)
                        {
                            uc.lblElapsedTime.Background = Brushes.White;
                        }
                        else if (a1.Minutes > 21 && a1.Minutes < 30)
                        {
                            uc.lblElapsedTime.Background = Brushes.Yellow;
                        }

                        else if (a1.Minutes >= 30)
                        {
                            uc.lblElapsedTime.Background = Brushes.Red;
                        }
                    }
                    else
                    {
                        uc.lblElapsedTime.Background = Brushes.Red;
                    }
                    if (a1.Hours > 0) { dSet.Rows[i]["ElapsedTime"] = a1.Hours + " Hours " + a1.Minutes + " Minutes "; }
                    if (a1.Hours <= 0) dSet.Rows[i]["ElapsedTime"] = a1.Minutes + " Minutes ";


                  
                    uc.lblElapsedTime.Content = dSet.Rows[i]["ElapsedTime"];

                  
                    dSet.Rows[i]["RowId"] = i + 1;
                    uc.lvOrders.Name = "lvOrders" + "_" + dSet.Rows[i]["RowId"];
                    sc.Children.Add(uc);
                    DataTable dSet1 = new DataTable();
                    b.OrderId = dSet.Rows[i]["OrderId"].ToString();
                    dSet1 = _objbal.GetOrdersDetails(b);
                    if (dSet1.Rows.Count > 0)
                    {

                        uc.lvOrders.ItemsSource = dSet1.DefaultView;
                    }
                    stkMain.Children.Add(sc);

                }
            }
            else if (dSet.Rows.Count == 0)
            {

                lblTicketsPending.Content = 0;

            }
        }
       
        public void BindRestaurantdtls(ComboBox cmbRestcode)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = tbal.GetRestCode();
                cmbRestcode.ItemsSource = ds.Tables[0].DefaultView;
                cmbRestcode.DisplayMemberPath = ds.Tables[0].Columns["RestCode"].ToString();
                cmbRestcode.SelectedValuePath = ds.Tables[0].Columns["RestCode"].ToString();
               
             }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
