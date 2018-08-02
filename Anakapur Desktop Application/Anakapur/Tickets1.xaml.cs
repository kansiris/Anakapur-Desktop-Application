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
using System.Speech;
using System.Speech.Synthesis;
namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Tickets1.xaml
    /// </summary>
    /// 
    //public static class Globals
    //{
    //    public static string orgrestcode = Application.Current.Properties["restcode"].ToString();
    //}
    public partial class Tickets1 : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        TicketsBal tbal = new TicketsBal();
        DataTable dSet = new DataTable();
        string orgrestcode = Application.Current.Properties["restcode"].ToString().Trim();

        //string connStr = "Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";

        public Tickets1()
        {



            InitializeComponent();
            //string originalrestcode = Application.Current.Properties["restcode"].ToString();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(30);
            timer1.Tick += timer_Tick1;
            timer1.Start();

            cborest.Visibility = Visibility.Hidden;
            BindRestaurantdtls(cborest);
            string restcode = "";
            if (Application.Current.Properties["restcode"] == null)
            {

                Application.Current.Properties["restcode"] = "HN";
            }
            if (Application.Current.Properties["restcode"].ToString().Trim() == "ZZ")
            {
                this.cborest.Visibility = Visibility.Visible;
                MessageBox.Show("Please select the Restaurant");
                cborest.Focus();
                //cborest.SelectedValue = restcode;
            }
            else

            { restcode = Application.Current.Properties["restcode"].ToString(); }
            ///To add functionality for refreshing every 30 secs
            addUserControl();
            Tickets tc = new Tickets();
            if (tc.IsActive)
            { tc.Close(); }
            else { tc.Show(); }
            try
            {
                string st = " New Order with Order id" + b.OrderId;
                SpeechSynthesizer sp = new SpeechSynthesizer();
                sp.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
                sp.Volume = 100;
                sp.Rate = -3;
                sp.Speak(st);
            }
            catch (Exception)
            {
                MessageBox.Show("PLease switch on the TV in the kitchen");
            }
            //PlaySound();

        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Left = SystemParameters.PrimaryScreenWidth + 100;
            //this.WindowState = System.Windows.WindowState.Maximized;
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

            if (Application.Current.Properties["restcode"].ToString().Trim().ToUpper() != "ZZ")
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
                        uc.lblordertype.Content = dSet.Rows[i]["OrderType"].ToString();
                        uc.lblcustomername.Content = dSet.Rows[i]["CustomerFName"].ToString();
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
                        // Display the Elaspsed time hh:mm
                        //    string elapsedTime = time.ToString(DateTime.Now.ToShortTimeString() );
                        //  string elapsedTime = time.ToString(DateTime.Now.ToShortTimeString());

                        var b1 = DateTime.Parse(DateTime.Now.ToString()) - (DateTime.Parse(dtOrderTime.ToString()));
                        //  var a1 = DateTime.Parse(elapsedTime) - DateTime.Parse(displayTime);
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


                        //uc.lblElapsedTime.Content = DateTime.Parse(elapsedTime) - DateTime.Parse(displayTime);
                        uc.lblElapsedTime.Content = dSet.Rows[i]["ElapsedTime"];

                        uc.lvOrders.MouseDoubleClick += LvOrders_MouseDoubleClick;
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
        }
        private void LvOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ListView clicked = (ListView)sender;
            string[] words = clicked.Name.Split('_');
            DataRow[] dr = dSet.Select("RowId = '" + words[1] + "'");



            b.OrderId = dr[0].ItemArray[2].ToString();

            DataTable dt = new DataTable();
            dt = _objbal.getordertransactiondtls(dr[0].ItemArray[2].ToString());
            string trstatus = dt.Rows[0]["Transactionstatus"].ToString();
            decimal totalamount = Convert.ToDecimal(dt.Rows[0]["Totalamount"].ToString());
            if (trstatus == "SuccessfulTransaction" || trstatus == "your transaction is successfull")
            {
                b.StatusId = 4;
                b.totalamount = Convert.ToDecimal(dt.Rows[0]["Totalamount"].ToString());

            }
            else
            {
                b.StatusId = 2;
                b.totalamount = 0;
            }
            b.EmpCode = dr[0].ItemArray[4].ToString();

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Order is Done ?", "Order Preparation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                string result = _objbal.UpdateTickets(b);
                //StackPanel s = new StackPanel();
                stkMain.Children.Clear();
                try
                {
                    string st = " Order id " + b.OrderId + "Cooking completed";
                    SpeechSynthesizer sp = new SpeechSynthesizer();
                    sp.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                    sp.Volume = 100;
                    sp.Rate = -3;
                    sp.Speak(st);
                }
                catch (Exception)
                {
                    MessageBox.Show("Switch on the tv in kitchen");
                }
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
                UCTickets uc1 = new UCTickets();
                uc1.lvOrders.ItemsSource = null;
                stkMain.Children.Clear();
            }
            addUserControl();


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
                // cmbRestcode.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cborest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string restcode = Application.Current.Properties["restcode"].ToString().Trim();
            if (restcode == "ZZ")
            {
                if (cborest.SelectedValue.ToString().Trim() == "BW")
                {
                    Application.Current.Properties["restcode"] = "BW";
                }
                else if (cborest.SelectedValue.ToString().Trim() == "HN")
                { Application.Current.Properties["restcode"] = "HN"; }
                else if (cborest.SelectedValue.ToString().Trim() == "MD")
                { Application.Current.Properties["restcode"] = "MD"; }
                else if (cborest.SelectedValue.ToString().Trim() == "KP")
                { Application.Current.Properties["restcode"] = "KP"; }
                else if (cborest.SelectedValue.ToString().Trim() == "AN")
                { Application.Current.Properties["restcode"] = "AN"; }
                else
                { restcode = Application.Current.Properties["restcode"].ToString().Trim(); }
                stkMain.Children.Clear();
                addUserControl();

                Tickets tc = new Tickets();
                if (tc.IsActive)
                { tc.Close(); }
                else { tc.Show(); }

            }
            else
            {
                if (cborest.SelectedValue.ToString().Trim() == "BW")
                {
                    Application.Current.Properties["restcode"] = "BW";
                }
                else if (cborest.SelectedValue.ToString().Trim() == "HN")
                { Application.Current.Properties["restcode"] = "HN"; }
                else if (cborest.SelectedValue.ToString().Trim() == "MD")
                { Application.Current.Properties["restcode"] = "MD"; }
                else if (cborest.SelectedValue.ToString().Trim() == "KP")
                { Application.Current.Properties["restcode"] = "KP"; }
                else if (cborest.SelectedValue.ToString().Trim() == "AN")
                { Application.Current.Properties["restcode"] = "AN"; }
                else
                { restcode = Application.Current.Properties["restcode"].ToString().Trim(); }
                stkMain.Children.Clear();
                addUserControl();
                Tickets tc = new Tickets();
                if (tc.IsActive)
                { tc.Close(); }
                else { tc.Show(); }

            }


        }

        private void PlaySound()
        {
            var uri = new Uri(@"C:\Users\user\Downloads\msg_text.mp3", UriKind.RelativeOrAbsolute);
            var player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }
    }
}
