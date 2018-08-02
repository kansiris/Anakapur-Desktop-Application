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

namespace Anakapur.Pages
{
    /// <summary>
    /// Interaction logic for New_Order.xaml
    /// </summary>
    public partial class New_Order : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        public New_Order()
        {
            InitializeComponent();
        }

        private void btnBreakFast_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Pages/BreakFast.xaml", UriKind.Relative));
        }

        private void btnLunch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Pages/Lunch.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCombo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Pages/Combo.xaml", UriKind.RelativeOrAbsolute));
        }

        //private void btnFamilyPack_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService nav = NavigationService.GetNavigationService(this);
        //    nav.Navigate(new Uri("Pages/FamilyPack.xaml", UriKind.RelativeOrAbsolute));
        //}

        private void btnFamilyPack_Click(object sender, RoutedEventArgs e)
        {
            b.CategoryType = "Break Fast";
            DataTable dt = new DataTable();
            dt = _objbal.GetBreakFast(b);
            //BreakFastDataGrid.ItemsSource = dt.DefaultView;
            //dataGrid.ItemsSource = dt.DefaultView;
        }

        private void BreakFast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            b.CategoryType = "Break Fast";
            DataTable dt = new DataTable();
            dt = _objbal.GetBreakFast(b);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string a = dt.Rows[i][1].ToString();

                Button myButton = new Button();
                myButton.Content = dt.Rows[i][0].ToString().Trim();
                myButton.Width = 54;
                myButton.Height = 54;
                //{
                //    Width = 54,
                //    Height = 54,
                //    Content = new Image
                //    {
                //        Name = dt.Rows[i][1].ToString(),
                //        //Source = new BitmapImage(new Uri("image source")),
                //        //VerticalAlignment = VerticalAlignment.Center
                //    }

                //};
                //myButton.Name = "Paya";
                //grdData.setr.ro(myButton, 0);
                //spdata.SetColumn(myButton, 0);
                spdata.Children.Add(myButton);
                //frmContent.items.Add(myButton);

            }


            //BreakFastDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}