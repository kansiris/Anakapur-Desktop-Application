using AnkapurBAL;
using System.Data;
using System.Windows.Controls;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Lunch.xaml
    /// </summary>
    public partial class Lunch : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        public Lunch()
        {
            InitializeComponent();
            b.CategoryId = 5;
            DataTable dt = new DataTable();
            dt = _objbal.GetBreakFast(b);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
