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

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BreakFastBal _objbal = new BreakFastBal();
        public MainWindow()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt = _objbal.getdata();

            //dataGrid.ItemsSource = dt.DefaultView;
        }

        private void btnBreakFast_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            //navService.Navigate = (new Uri("Page2.xaml", UriKind.Relative));

            //NavigationService.Navigate(new Page2());
            //BreakFast nextPage = new BreakFast();
            //NavigationService.Navigate(nextPage);
            //nextPage.Show();
            //NavigationService.Navigate(new Uri("BreakFast.xaml", UriKind.Relative));

            NavigationWindow navWIN = new NavigationWindow();
            navWIN.Content = new BreakFast();
            //navWIN.Show();
            //nextPage.ShowsNavigationUI();
        }

        private void btnLunch_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navWIN = new NavigationWindow();
            navWIN.Content = new Lunch();
            //navWIN.Show();
        }

        private void btnFamilyPack_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navWIN = new NavigationWindow();
            navWIN.Content = new FamilyPack();
            //navWIN.Show();
        }

        private void btnCombo_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navWIN = new NavigationWindow();
            navWIN.Content = new Combo();
            //navWIN.Show();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navWIN = new NavigationWindow();
            navWIN.Content = new Employee();
            //navWIN.Show();
        }
    }
}
