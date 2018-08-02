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
using System.Diagnostics;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Dispatch.xaml
    /// </summary>
    public partial class OrdersUpdate : Page
    {
        private OrdersBal _objbal = new OrdersBal();
        OrderProperties opr = new OrderProperties();
        public OrdersUpdate()
        {
            InitializeComponent();
            GetOrders();

        }
        public void GetOrders()
        {
            try
            {
                string restCode = "";
                if (Application.Current.Properties["restcode"] == null) { Application.Current.Properties["restcode"] = "BW"; }
                else
                { restCode = Application.Current.Properties["restcode"].ToString(); }
                DataSet ds = new DataSet();
                ds = _objbal.getOrders(restCode);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgOrders.ItemsSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("No Orders to Display", "Order Details", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgOrders.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Fillorderdtls()
        {
            //try
            //{
                DataRowView dt;
                int ind;
                ind = dgOrders.SelectedIndex;
                dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
                string orderid = dt.Row[0].ToString();
                DataSet ds = new DataSet();
                ds = _objbal.GetOrderDtls(orderid);

                dgDetails.ItemsSource = ds.Tables[0].DefaultView;
                totalbill(ds);

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public void FillMoney()
        {
            DataRowView dt;
            int ind;
            ind = dgOrders.SelectedIndex;
            dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
            if (dgOrders.Items.Count > 0)
            {
                txtdiscount.Text = dt.Row[8].ToString();
                txttip.Text = dt.Row[9].ToString();
                //if (Convert.ToInt32(dt.Row["amountpaid"].ToString()) != 0) { txttotbill.Text = Convert.ToString(Convert.ToInt32(dt.Row["amountpaid"].ToString())); }
                //txttotbill.Text = Convert.ToString(Convert.ToInt32(dt.Row["amountpaid"].ToString()));

            }
            else
            {
                MessageBox.Show("Payment not received");
            }
        }
        private void totalbill(DataSet ds)
        {
            int tot = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tot = tot + Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                }
            }
            //txttotprice.Text = Convert.ToString(tot);
            //txttotbill.Text = Convert.ToString(tot);
            int totprice = tot + Convert.ToInt32(txtdelchrge.Text);
            int ttotbill = tot + Convert.ToInt32(txtdelchrge.Text);
            txttotprice.Text = Convert.ToString(totprice);
            decimal finalbill = ttotbill + Decimal.Parse(txtcgst.Text)+ Decimal.Parse(txtsgst.Text);
            txttotprice.Text = Convert.ToString(finalbill);
            txttotbill.Text = Convert.ToString(finalbill);
            //txttotbill.Text = Convert.ToString(ttotbill);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            GetOrders();
        }
        public void paymentroles()
        {
            DataRowView dt;
            int ind;
            ind = dgOrders.SelectedIndex;
            dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
            if (dt.Row["StatusId"].ToString() == "6")
            {
                btnMap.IsEnabled = false;
                btnAssignDriver.IsEnabled = true;
                btnPd.IsEnabled = true;
            }
            else if (dt.Row["StatusId"].ToString() == "4")
            {
                btnAssignDriver.IsEnabled = false;
                btnMap.IsEnabled = true;
                btnPd.IsEnabled = true;
            }
            else if (dt.Row["StatusId"].ToString() == "1")
            {
                btnAssignDriver.IsEnabled = true;
                btnMap.IsEnabled = true;
                btnPd.IsEnabled = true;
            }
            else if (dt.Row["StatusId"].ToString() == "8")
            {
                btnAssignDriver.IsEnabled = false;
                btnMap.IsEnabled = false;
                btnPd.IsEnabled = false;
            }
            else if (dt.Row["StatusId"].ToString() == "10")
            {
                btnAssignDriver.IsEnabled = true;
                btnMap.IsEnabled = true;
                btnPd.IsEnabled = true;
            }
        }
        private void btnAssignDriver_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetails.Items.Count > 0)
            {
                DataRowView dt;
                int ind;
                ind = dgOrders.SelectedIndex;
                dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
                int statusid = 0;
                if (dt.Row["StatusId"].ToString() == "6")
                {
                    statusid = 11;
                }
                else
                {
                    statusid = 4;
                }

                opr.OrderId = dt.Row["OrderId"].ToString();
                opr.StatusId = statusid;
                opr.EmpCode = dt.Row["EmpCode"].ToString();
                opr.Remarks = txtremarks.Text;
                if (txttip.Text == "" || txttip.Text == null) { opr.Discount = "0"; } else { opr.Tip = (txttip.Text); }
                if (txtdiscount.Text == "" || txtdiscount.Text == null) { opr.Tip = "0"; } else { opr.Discount = (txtdiscount.Text); }
                if (txttotbill.Text.Length == 0) { MessageBox.Show("unable to process the bill"); }
                else { opr.AmountPaid = Convert.ToDecimal(txttotbill.Text); }
                string prd = _objbal.EditOrders(opr);
                MessageBox.Show("Orders Updated Successfully", "Orders", MessageBoxButton.OK, MessageBoxImage.Information);
                GetOrders();
                dgDetails.ItemsSource = null;
                txtremarks.Text = null;
                lblCustomerName.Content = null;
                lblAddress.Text = null;
                txttotprice.Text = null;
                txttotbill.Text = null;
                txtdiscount.Text = null;
                txttip.Text = null;
            }
            else
            {
                MessageBox.Show("Please select the orders to pay the bill", "Order Details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetails.Items.Count > 0)
            {
                DataRowView dt;
                int ind;
                ind = dgOrders.SelectedIndex;
                dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
                int statusid = 0;
                if (dt.Row["StatusId"].ToString() == "4")
                {
                    statusid = 11;
                }
                else
                {
                    statusid = 6;
                }

                opr.OrderId = dt.Row["OrderId"].ToString();
                opr.StatusId = statusid;
                opr.EmpCode = dt.Row["EmpCode"].ToString();
                opr.Remarks = txtremarks.Text;
                if (txttip.Text == "" || txttip.Text == null) { opr.Discount = "0"; } else { opr.Tip = (txttip.Text); }
                if (txtdiscount.Text == "" || txtdiscount.Text == null) { opr.Tip = "0"; } else { opr.Discount = (txtdiscount.Text); }
                if (txttotbill.Text.Length == 0) { MessageBox.Show("unable to process the bill"); }
                else { opr.AmountPaid = Convert.ToDecimal(txttotbill.Text); }

                string prd = _objbal.EditOrders(opr);
                MessageBox.Show("Orders Updated Successfully", "Orders", MessageBoxButton.OK, MessageBoxImage.Information);
                GetOrders();
                dgDetails.ItemsSource = null;
                txtremarks.Text = null;
                lblCustomerName.Content = null;
                lblAddress.Text = null;
                txttotprice.Text = null;
                txttotbill.Text = null;
                txtdiscount.Text = null;
                txttip.Text = null;
            }
            else
            {
                MessageBox.Show("Please select the orders to Deliver", "Order Details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnPd_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetails.Items.Count > 0)
            {
                DataRowView dt;
                int ind;
                ind = dgOrders.SelectedIndex;
                dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
                if (dt != null)
                {
                    int statusid = 11;

                    opr.OrderId = dt.Row["OrderId"].ToString();
                    opr.StatusId = statusid;
                    opr.EmpCode = dt.Row["EmpCode"].ToString();
                    opr.Remarks = txtremarks.Text;
                    if (txttip.Text == "" || txttip.Text == null) { opr.Discount = "0"; } else { opr.Tip = (txttip.Text); }
                    if (txtdiscount.Text == "" || txtdiscount.Text == null) { opr.Tip = "0"; } else { opr.Discount = (txtdiscount.Text); }
                    if (txttotbill.Text.Length == 0) { MessageBox.Show("unable to process the bill"); }
                    else { opr.AmountPaid = Convert.ToDecimal(txttotbill.Text); }
                    string prd = _objbal.EditOrders(opr);
                    MessageBox.Show("Orders Updated Successfully", "Orders", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetOrders();
                    dgDetails.ItemsSource = null;
                   txtremarks.Text = null;
                    lblCustomerName.Content = null;
                    lblAddress.Text = null;
                    txttotprice.Text = null;
                    txttotbill.Text = null;
                    txtdiscount.Text = null;
                    txttip.Text = null;
                }
            }
            else
            { MessageBox.Show("Please select the orders to Pay and Deliver", "Order Details", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        private void dgOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                DataRowView dt;
                int ind;
                ind = dgOrders.SelectedIndex;
                dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
                txtremarks.Text = dt.Row["Remarks"].ToString();
                lblCustomerName.Content = dt.Row[4].ToString();
                lblAddress.Text = dt.Row[6].ToString();
                txtdelchrge.Text = dt.Row["Deliverycharges"].ToString();
                txtcgst.Text = dt.Row["CGSTcharges"].ToString();
                txtsgst.Text = dt.Row["SGSTcharges"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Fillorderdtls();
            paymentroles();
            FillMoney();
            txtdiscount.Focus();


        }


        private void charValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        public void clearcontrols()
        {
            //txttotprice.Text = 0;
        }


        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetails.Items.Count > 0)
            {
                DataRowView dt;
                int ind;
                ind = dgOrders.SelectedIndex;
                dt = dgOrders.Items.GetItemAt(ind) as DataRowView;
                int statusCheck = int.Parse(dt.Row["StatusID"].ToString());
                DateTime startime = Convert.ToDateTime(dt.Row["OrderTime"].ToString());
                DateTime endtime = (DateTime.Now);
                TimeSpan diff = startime - endtime;
                if (statusCheck == 1)
                {
                    if (diff.Hours < 15)
                    {

                        int statusid = 8;

                        opr.OrderId = dt.Row["OrderId"].ToString();
                        opr.StatusId = statusid;
                        opr.EmpCode = dt.Row["EmpCode"].ToString();
                        opr.Remarks = txtremarks.Text;
                        if (txttip.Text == "" || txttip.Text == null) { opr.Discount = "0"; } else { opr.Tip = (txttip.Text); }
                        if (txtdiscount.Text == "" || txtdiscount.Text == null) { opr.Tip = "0"; } else { opr.Discount = (txtdiscount.Text); }

                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to cancel the order ?", "Order Cancellation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Information);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            string prd = _objbal.EditOrders(opr);
                        }
                        GetOrders();
                        dgDetails.ItemsSource = null;
                       txtremarks.Text = null;
                        lblCustomerName.Content = null;
                        lblAddress.Text = null;
                        txttotprice.Text = null;
                        txttotbill.Text = null;
                        txtdiscount.Text = null;
                        txttip.Text = null;
                    }

                    else
                    {
                        MessageBox.Show("Time Exceeded!!! So Order is not cancelled", "Cancellation Request", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else { MessageBox.Show("Sorry Order is not New, so cannot cancel", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else { MessageBox.Show("Please select the Order to cancel", "Order cancellation", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void txtdiscount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txttotprice.Text.Length == 0) { txttotprice.Text = "0"; }
            if (txtdiscount.Text.Length == 0) { txtdiscount.Text = "0"; }
            if (txttip.Text.Length == 0) { txttip.Text = "0"; }
            txttotbill.Text = ((Decimal.Parse(txttotprice.Text) +
                Decimal.Parse(txttip.Text) -
                Decimal.Parse(txtdiscount.Text))).ToString();
            //lostfocus();
        }

        private void txttip_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txttotprice.Text.Length == 0) { txttotprice.Text = "0"; }
            if (txtdiscount.Text.Length == 0) { txtdiscount.Text = "0"; }
            if (txttip.Text.Length == 0) { txttip.Text = "0"; }
            txttotbill.Text = ((Decimal.Parse(txttotprice.Text) +
                Decimal.Parse(txttip.Text) -
                Decimal.Parse(txtdiscount.Text))).ToString();
            //lostfocus();
        }

        private void txtdiscount_GotFocus(object sender, RoutedEventArgs e)
        {
            //vkb();
        }

        private void txttip_GotFocus(object sender, RoutedEventArgs e)
        {
            //vkb();
        }
        public void vkb()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) +
               System.IO.Path.DirectorySeparatorChar + "osk.exe");
        }
        public void lostfocus()
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

    }
}

