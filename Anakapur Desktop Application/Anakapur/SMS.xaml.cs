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

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for SMS.xaml
    /// </summary>
    public partial class SMS : Page
    {
        public SMS()
        {
            InitializeComponent();
        }

        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            SMSCAPI.ServiceSoapClient obj1 = new SMSCAPI.ServiceSoapClient();
            string strPostResponse;

            strPostResponse = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "918499949024", "Welcome to Ankapur Chicken, A unique way of cooking !!!", "5658589");

            //ndu - 9951351358
            // Navaneetha - 9676169941

            string delReport;
            delReport = obj1.Getbalance("ankapurchicken", "ankapur6900");
        }
    }
}
