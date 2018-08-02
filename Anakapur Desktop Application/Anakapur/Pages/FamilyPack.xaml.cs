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
    /// Interaction logic for FamilyPack.xaml
    /// </summary>
    public partial class FamilyPack : Page
    {
        private BreakFastBal _objbal = new BreakFastBal();
        BreakFastProperties b = new BreakFastProperties();
        public FamilyPack()
        {
            InitializeComponent();
            b.CategoryId = 21;
            DataTable dt = new DataTable();
            dt = _objbal.GetBreakFast(b);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
