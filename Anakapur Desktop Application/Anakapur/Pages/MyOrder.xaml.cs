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
    /// Interaction logic for MyOrder.xaml
    /// </summary>
    public partial class MyOrder : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        public MyOrder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            b.CategoryType = "Break Fast";
            DataTable dt = new DataTable();
            dt = _objbal.GetBreakFast(b);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string a = dt.Rows[i][1].ToString();

                Button myButton = new Button
                {
                    Width = 54,
                    Height = 54,
                    Content = new Image
                    {
                        //Name ="Paya",
                        //Source = new BitmapImage(new Uri("image source")),
                        //VerticalAlignment = VerticalAlignment.Center
                    }

                };
                //FramePage1.Navigate()
                StkPnl.Children.Add(myButton);
            }
            }
    }
}
