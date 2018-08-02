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

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for wn.xaml
    /// </summary>
    public partial class wn : Window
    {
        public wn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test1 tst = new test1();
            tst.txtone.Text = "Hello World";
            this.Close();
           
            tst.txtone.Visibility = Visibility.Hidden;
            
        }
    }
}
