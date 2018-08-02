
using System.Windows.Controls;
using AnkapurBAL;
using System.Data;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for BreakFast.xaml 
    /// </summary>
    public partial class BreakFast : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        public BreakFast()
        {
            InitializeComponent();
            b.CategoryType = "Break Fast";
            DataTable dt = new DataTable();
            dt = _objbal.GetBreakFast(b);
            dataGrid.ItemsSource = dt.DefaultView;
           
        }
    }
}
