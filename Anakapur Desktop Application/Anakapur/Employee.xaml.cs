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
using System.Windows.Controls.Ribbon;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
 

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : MetroWindow
    {
        public Employee()
        {
            
            try
            {
                InitializeComponent();
                //lblempname.Content = Application.Current.Properties["First_Name"].ToString();
                
                expMenu.IsExpanded = true;
                expMenu.Header = "Close Menu";
                

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void RibbonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Source= new Uri("NewOrder.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("empAddPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("ProductsPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("NewOrder.xaml", UriKind.RelativeOrAbsolute);
        }

        //private void RibbonMenuItem_Click_4(object sender, RoutedEventArgs e)
        //{
            
        //}

        //private void RibbonMenuItem_Click_5(object sender, RoutedEventArgs e)
        //{
        //    frmMain.Source = new Uri("ProductAailabilityPage.xaml", UriKind.RelativeOrAbsolute);
        //}

        private void RibbonMenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("Profile.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            //frmMain.Source = SearchCustomer();

            
            frmMain.Source = new Uri("SearchCustomer.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("OrdersUpdate.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            
            frmMain.Source = new Uri("Tickets1.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("Dispatch.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("ViewOrdersPage.xaml", UriKind.RelativeOrAbsolute);
        }
        private void RibbonMenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow lw = new LoginWindow();
            lw.Show();
        }

        private void RibbonMenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("ProductAailabilityPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("ReportsPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow lw = new LoginWindow();
            lw.Show();
        }

        private void expMenu_Collapsed(object sender, RoutedEventArgs e)
        {
            expMenu.Header = "Open Menu";
        }

        private void expMenu_Expanded(object sender, RoutedEventArgs e)
        {
            expMenu.Header = "Close Menu";
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("Dashboard.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RibbonMenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            frmMain.Source = new Uri("EditOrder.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
