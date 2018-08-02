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
using AnkapurBAL;
using System.Data;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.IO;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        private LoginBal _objLoginBal = new LoginBal();
        private LoginProperties lp = new LoginProperties();
        public LoginWindow()
        {
            InitializeComponent();
            textBox.Focus();
        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                lp.Password = textBox.Text.ToString().Trim();
                DataTable dt = new DataTable();
                dt = _objLoginBal.GetLogin(lp);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != "Does not Exist")
                    {
                        //Application.Current.Properties["orderId"] = "".ToString();
                        Application.Current.Properties["restcode"] = dt.Rows[0][8].ToString();
                        //Application.Current.Properties["custPhone"] = lblOrderID.Content.ToString();
                        Application.Current.Properties["EmpCode"] = dt.Rows[0][3].ToString();
                        Application.Current.Properties["UserType"] = dt.Rows[0][6].ToString();
                        Application.Current.Properties["Mobile1"] = dt.Rows[0][4].ToString();
                        NavigationWindow window = new NavigationWindow();
                        if (dt.Rows[0][6].ToString() == "CA")
                        {
                            Employee emp = new Employee();
                            emp.rbnAdmin.Visibility = Visibility.Hidden;
                            emp.rbncustomer.Visibility = Visibility.Visible;
                           // emp.rbnDelivery.Visibility = Visibility.Visible;
                            emp.rbnOrderUpdate.Visibility = Visibility.Visible;
                            emp.rbnproductavail.Visibility = Visibility.Visible;
                            emp.rbnankreport.Visibility = Visibility.Hidden;
                            emp.rbnreports.Visibility = Visibility.Visible;
                            emp.rbntickets.IsEnabled = true;
                            //emp.rbnorderavail.Visibility = Visibility.Visible;
                            emp.rbnNewOrder.IsEnabled = true;
                            this.Close();
                            emp.Show(); ;
                        }
                        else if (dt.Rows[0][6].ToString() == "RM")
                        {
                            Employee emp = new Employee();
                            //emp.rbnAdmin.IsEnabled = true;
                            emp.rbnAdmin.Visibility = Visibility.Hidden;
                            emp.rbncustomer.Visibility = Visibility.Visible;
                         //   emp.rbnDelivery.Visibility = Visibility.Hidden;
                            emp.rbnOrderUpdate.Visibility = Visibility.Visible;
                            emp.rbnproductavail.Visibility = Visibility.Visible;
                            emp.rbnankreport.Visibility = Visibility.Hidden;
                            emp.rbnreports.Visibility = Visibility.Visible;
                            emp.rbntickets.IsEnabled = true;
                            //emp.rbnorderavail.Visibility = Visibility.Visible;
                            emp.rbnNewOrder.IsEnabled = true;
                            this.Close();
                            emp.Show();
                        }
                        else if (dt.Rows[0][6].ToString() == "AD")
                        {
                            Employee emp = new Employee();
                            emp.rbnAdmin.IsEnabled = true;
                            emp.rbncustomer.Visibility = Visibility.Visible;
                         //   emp.rbnDelivery.Visibility = Visibility.Visible;
                            emp.rbnOrderUpdate.Visibility = Visibility.Visible;
                            emp.rbnproductavail.Visibility = Visibility.Visible;
                            emp.rbnankreport.Visibility = Visibility.Visible;
                            emp.rbnreports.Visibility = Visibility.Visible;
                            emp.rbntickets.IsEnabled = true;
                            //emp.rbnorderavail.Visibility = Visibility.Visible;
                            emp.rbnNewOrder.IsEnabled = true;
                            this.Close();
                            emp.Show();
                        }
                        else if (dt.Rows[0][6].ToString() == "CH")
                        {
                            Employee emp = new Employee();
                            emp.rbnAdmin.Visibility = Visibility.Hidden;
                            emp.rbncustomer.Visibility = Visibility.Visible;
                           // emp.rbnDelivery.Visibility = Visibility.Visible;
                            emp.rbnOrderUpdate.Visibility = Visibility.Visible;
                            emp.rbnproductavail.Visibility = Visibility.Visible;
                            emp.rbnankreport.Visibility = Visibility.Hidden;
                            emp.rbnreports.Visibility = Visibility.Visible;
                            emp.rbntickets.IsEnabled = true;
                            //emp.rbnorderavail.Visibility = Visibility.Visible;
                            emp.rbnNewOrder.IsEnabled = true;
                            this.Close();
                            emp.Show();
                        }
                        else if (dt.Rows[0][6].ToString() == "DB")
                        {
                            Employee emp = new Employee();
                            emp.rbnAdmin.Visibility = Visibility.Hidden;
                            emp.rbncustomer.Visibility = Visibility.Visible;
                       //     emp.rbnDelivery.Visibility = Visibility.Visible;
                            emp.rbnOrderUpdate.Visibility = Visibility.Visible;
                            emp.rbnproductavail.Visibility = Visibility.Visible;
                            emp.rbnankreport.Visibility = Visibility.Hidden;
                            emp.rbnreports.Visibility = Visibility.Visible;
                            emp.rbntickets.IsEnabled = true;
                            //emp.rbnorderavail.Visibility = Visibility.Visible;
                            emp.rbnNewOrder.IsEnabled = true;
                            this.Close();
                            emp.Show();
                        }
                    }
                    else if (textBox.Text.Length == 0 || textBox.Text == "")
                    {
                        MessageBox.Show("Please Enter the pin", "Pin Details", MessageBoxButton.OK, MessageBoxImage.Information);
                        textBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Pin Number", "Pin Details", MessageBoxButton.OK, MessageBoxImage.Information);
                        textBox.Focus();
                    }

                }
            }
            catch(Exception )
            {
                MessageBox.Show("Cannot connect to Server", "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void vkb()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) 
                + System.IO.Path.DirectorySeparatorChar + "osk.exe");
        }
        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_Click_1(this, new RoutedEventArgs());
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //vkb();
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            //{
            //    process.Kill();
            //}
        }

    }
}

