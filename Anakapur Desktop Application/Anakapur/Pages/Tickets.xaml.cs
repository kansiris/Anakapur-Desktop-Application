using AnkapurBAL;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Tickets.xaml
    /// </summary>
    public partial class Tickets : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        DataTable dt = new DataTable();
        DataTable dtOrderDetails = new DataTable();
        //b.CategoryType = "Break Fast";
        public Tickets()
        {
            InitializeComponent();
            //working Code
            BindListView();
        }


        public void BindListView()
        {
            b.flag = 1;
            dt = _objbal.GetOrders(b);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                b.flag = 2;
                b.OrderId = Convert.ToInt32(dt.Rows[j][0]);
                dtOrderDetails = _objbal.GetOrders(b);
                Label lblOrderid = new Label();
                lblOrderid.Content = dt.Rows[j]["OrderId"].ToString();
                Label lblTime = new Label();
                lblTime.Content = dt.Rows[j]["OrderTime"].ToString();
                ListView listBox = new ListView();
                listBox.Items.Add("Order Id :" + dt.Rows[j]["OrderId"].ToString());
                listBox.Items.Add("Ordered Time :" + dt.Rows[j]["OrderTime"].ToString());
                listBox.Items.Add("Items :");
                listBox.Name = "ldData" + "_" + dt.Rows[j]["OrderId"].ToString();
                //+"_" + dt.Rows[j]["StatusId"].ToString() + "_" + dt.Rows[j]["EmpCode"]
                listBox.MouseDoubleClick += ListBox_MouseDoubleClick;

                //listBox.ItemsSource = dtOrderDetails.DefaultView;

                for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                {
                    listBox.Items.Add(new BreakFastProperties() { ProductName = dtOrderDetails.Rows[i][4].ToString(), Quantity = Convert.ToInt32(dtOrderDetails.Rows[i][1]) });
                }
                //object sumObject;
                //sumObject = dtOrderDetails.Compute("Sum(Price)", "");
                //listBox.Items.Add("Total Amount   :" + sumObject);
                this.spdata.Children.Add(listBox);
                listBox.SetValue(Grid.RowProperty, j);
                listBox.SetValue(Grid.ColumnProperty, j);
            }
        }
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show("Hello");
            ListBox clicked = (ListBox)sender;
            string[] words = clicked.Name.Split('_');
            //string result = _objbal.UpdateTickets(Convert.ToInt32(words[1]),0,null);
            BindListView();
            MessageBox.Show("Updated successfully");
        }




    }
}
