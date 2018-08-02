using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Controls.DataVisualization.Charting;
using AnkapurDAL;
using AnkapurBAL;
namespace Anakapur
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page
    {
       public CoreDAL objdal = new CoreDAL();
        Reportsbal rpbal = new Reportsbal();
        string connStr;
        DataSet dataset1 = new DataSet();

        
        public DashBoard()
        {
            InitializeComponent();
            showColumnChart();
            connStr = objdal.constring();
        }

        private void showColumnChart()
        {



            SqlConnection connection;
            connStr = objdal.constring();
            connection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("[rptGetRevenueAllRest1]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add(new SqlParameter("EmpCode", empCode));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
             dAd.Fill(dataset1);
            dAd.Fill(dt);
            //  dgCust.ItemsSource = dt.DefaultView;
            connection.Close();
            string rest;
            int amt;
           
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
          
            for (int i = 0; i < dataset1.Tables[0].Rows.Count; i++)
            {
                rest = dataset1.Tables[0].Rows[i][0].ToString().Trim();
                amt = Convert.ToInt32(dataset1.Tables[0].Rows[i][1].ToString().Trim());
                valueList.Add(new KeyValuePair<string, int>(rest,amt ));
            }
         

            //Setting data for column chart
            columnChart.DataContext = valueList;

            // Setting data for pie chart
            List<KeyValuePair<string, int>> valueList1 = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < dataset1.Tables[2].Rows.Count; i++)
            {
                rest = dataset1.Tables[2].Rows[i][0].ToString().Trim();
                amt = Convert.ToInt32(dataset1.Tables[2].Rows[i][1].ToString().Trim());
                valueList1.Add(new KeyValuePair<string, int>(rest, amt));
            }
            pieChart.DataContext = valueList1;

            List<KeyValuePair<string, int>> valueList2 = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < dataset1.Tables[3].Rows.Count; i++)
            {
                rest = dataset1.Tables[3].Rows[i][0].ToString().Trim();
                amt = Convert.ToInt32(dataset1.Tables[3].Rows[i][1].ToString().Trim());
                valueList2.Add(new KeyValuePair<string, int>(rest, amt));
            }
            barchart.DataContext = valueList2;
            List<KeyValuePair<string, int>> valueList3 = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < dataset1.Tables[4].Rows.Count; i++)
            {
                rest = "Dec";
                amt = Convert.ToInt32(dataset1.Tables[4].Rows[i][0].ToString().Trim());
                valueList3.Add(new KeyValuePair<string, int>(rest, amt));
            }
            lineseries3.DataContext = valueList3;

            List<KeyValuePair<string, int>> valueList4 = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < dataset1.Tables[5].Rows.Count; i++)
            {
                rest = "Jan";
                amt = Convert.ToInt32(dataset1.Tables[5].Rows[i][0].ToString().Trim());
                valueList4.Add(new KeyValuePair<string, int>(rest, amt));
            }
            lineseries2.DataContext = valueList4;

            List<KeyValuePair<string, int>> valueList5 = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < dataset1.Tables[6].Rows.Count; i++)
            {
                rest = "Feb";
                amt = Convert.ToInt32(dataset1.Tables[6].Rows[i][0].ToString().Trim());
                valueList5.Add(new KeyValuePair<string, int>(rest, amt));
            }
            lineseries1.DataContext = valueList5;


            //Setting data for area chart
            // areaChart.DataContext = valueList;

            //Setting data for bar chart
            // barChart.DataContext = valueList;

            //Setting data for line chart
            // lineChart.DataContext = valueList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //.dataGrid.ItemsSource = dataset1.Tables[1].DefaultView;
            //var newWindow = new Report1();
            //object sumObject;
            //sumObject = dataset1.Tables[1].Compute("Sum(TotalAmount)", "TotalAmount >0");
            //newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //newWindow.dataGrid.ItemsSource = dataset1.Tables[1].DefaultView;
            //newWindow.lblTotal.Content = "Revenue by Restuarant : Rs." + sumObject.ToString();
            //newWindow.Show();

        }

        private void btnDaily_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt= new DateTime();
            dt = System.DateTime.Today;
            DataSet ds2 = new DataSet();
                 
            ds2 = rpbal.getdailyreports(dt);
            var newWindow = new Report1();
            object sumObject;
            sumObject = ds2.Tables[1].Compute("Sum(Revenue)", "Revenue >0");
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newWindow.dataGrid.ItemsSource = ds2.Tables[0].DefaultView;
            newWindow.lblTotal.Content = "Revenue by Restuarant : Rs." + sumObject.ToString();
            newWindow.Show();
        }

        private void btnWeek_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1 = new DateTime();
            dt1 = System.DateTime.Now;
            dataset1 = rpbal.getweeklyreports(dt1);
            var newWindow = new Report1();
            object sumObject;
            sumObject = dataset1.Tables[1].Compute("Sum(Revenue)", "Revenue >0");
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newWindow.dataGrid.ItemsSource = dataset1.Tables[0].DefaultView;
            newWindow.lblTotal.Content = "Revenue by Restuarant : Rs." + sumObject.ToString();
            newWindow.Show();
        }

        private void btnMonth_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt2 = new DateTime();
            dt2 = System.DateTime.Now;
            dataset1 = rpbal.getmonthlyreports(dt2);
            var newWindow = new Report1();
            object sumObject;
            sumObject = dataset1.Tables[1].Compute("Sum(Revenue)", "Revenue >0");
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newWindow.dataGrid.ItemsSource = dataset1.Tables[0].DefaultView;
            newWindow.lblTotal.Content = "Revenue by Restuarant : Rs." + sumObject.ToString();
            newWindow.Show();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection;
            connStr = objdal.constring();
            connection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("[rptGetRevenueAllRest]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.Add(new SqlParameter("EmpCode", empCode));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet dt2 = new DataSet();
            dAd.Fill(dt2);
            dAd.Fill(dt);
            //  dgCust.ItemsSource = dt.DefaultView;
            connection.Close();
            var newWindow = new TotalReport();
            object sumObject;
            sumObject = dt2.Tables[1].Compute("Sum(TotalAmount)", "TotalAmount >0");
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newWindow.dataGrid.ItemsSource = dt2.Tables[1].DefaultView;
            newWindow.lblTotal.Content = "Revenue by Restuarant : Rs." + sumObject.ToString();
            newWindow.Show();
        }
    }
}
