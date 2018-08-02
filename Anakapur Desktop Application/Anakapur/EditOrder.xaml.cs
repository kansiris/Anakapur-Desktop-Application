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
using System.Data;
using AnkapurBAL;
namespace Anakapur
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Page
    {
        OrdersBal objbal = new OrdersBal();
        OrderProperties opr = new OrderProperties();
        public EditOrder()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {

            string orderid;
            //int discount;
            //decimal AmountPaid;
            string Remarks;



            orderid = txtorderid.Text;
            if (txtdiscount.Text == "" || txtdiscount.Text == null) { opr.Discount = "0"; } else { opr.Discount = (txtdiscount.Text); }
            if (txtamountpaid.Text == "" || txtamountpaid.Text == null) { opr.AmountPaid = 0; } else { opr.AmountPaid = Convert.ToDecimal(txtamountpaid.Text); }
            //discount = Convert.ToInt32(txtdiscount.Text);

            //AmountPaid = decimal.Parse(txtamountpaid.Text);
            Remarks = txtremarks.Text;

            DataTable dt = new DataTable();
            dt = objbal.chkorderid(orderid);
            int order = Convert.ToInt32(dt.Rows[0][0].ToString());

            if (order >= 1)
            {

                string saveorder = objbal.getcomporderdtls(orderid, opr.Discount, opr.AmountPaid, Remarks);

                MessageBox.Show("Order Updated Successfully", "Order Upadte", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
            }
            else if (txtorderid.Text == "")
            {
                MessageBox.Show("Please Enter OrderId", "Order Update", MessageBoxButton.OK, MessageBoxImage.Information);
                txtorderid.Focus();
            }
            else
            {
                MessageBox.Show("Order Doesnot exist", "Orders", MessageBoxButton.OK, MessageBoxImage.Information);
                txtorderid.Focus();
                txtorderid.SelectAll();
            }
        }
        public void clear()
        {
            txtorderid.Text = "";
            txtdiscount.Text = "";
            txtamountpaid.Text = "";
            txtremarks.Text = "";
        }
    }
}
