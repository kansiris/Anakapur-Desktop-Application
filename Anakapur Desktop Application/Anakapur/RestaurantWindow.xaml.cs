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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Navigation;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for RestaurantWindow.xaml
    /// </summary>
    public partial class RestaurantWindow : Window
    {
        private TicketsBal _objbal = new TicketsBal();
        public RestaurantWindow()
        {
            InitializeComponent();
            GetorderDetails();
        }
       
        public void GetorderDetails()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = _objbal.getrestaurants();

                radioBtns(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void radioBtns(DataTable dt)
        {
            //Filling dynamically the Restuarants in radio buttons
            {
                //Filling dynamically the Restuarants in radio buttons
                DataTable dt1 = new DataTable();
                dt1 = dt;
                foreach (DataRow row in dt1.Rows)
                {
                    RadioButton rd = new RadioButton();
                    rd.GroupName = "Rest";
                    rd.Name = "rdbtn" + row.ItemArray[0].ToString().Trim();
                    rd.Content = row.ItemArray[0].ToString();
                    var toReg1 = (RadioButton)this.FindName(rd.Name);
                    if (toReg1 == null)
                    {
                        this.RegisterName(rd.Name, rd);
                    }
                    if (row.ItemArray[0].ToString().Trim() == "HN") { rd.IsChecked = true; }
                    else if (row.ItemArray[0].ToString().Trim() == "ZZ") { rd.Visibility = Visibility.Hidden; }
                    stkRadioBtn.Children.Add(rd);
                }
            }
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton element in stkRadioBtn.Children)
            {
                var restButton = element.Name;
                RadioButton rd = new RadioButton();
                rd = (RadioButton)this.FindName(restButton.ToString());
                if (rd.IsChecked == true)
                {
                    //DataSet dt = new DataSet();
                    //dt = _objbal.getorddata(rd.Content.ToString());   
                    Application.Current.Properties["restcode"] = rd.Content.ToString();
                    Tickets1 tk = new Tickets1();
                    this.Close();
                    Employee emp = new Employee();
                    emp.frmMain.Source = new Uri("Tickets1.xaml", UriKind.RelativeOrAbsolute);
                }
               
                
                
                //tk.NavigationService.Navigate();
            
            }
        }
    }
}
