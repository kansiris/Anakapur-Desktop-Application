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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using AnkapurBAL;
using MahApps.Metro.Controls;
using AnkapurDAL;


namespace Anakapur
{
    /// <summary>
    /// Interaction logic for DishesNotAvailable.xaml
    /// </summary>
    public partial class DishesNotAvailable : Window
    {
        public CoreDAL _objdal = new CoreDAL();
        string connStr = "";
        public DishesNotAvailable()
        {
            InitializeComponent();
            connStr = _objdal.constring();
            fillNotAvailable();

        }

        private void lvMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            DataRowView CompRow;
            int SComp;
            SComp = lvMenu.SelectedIndex;
            if (SComp > 0)
            {
                CompRow = lvMenu.Items.GetItemAt(SComp) as DataRowView;

            }
        }
        private void fillNotAvailable()
        {
            //Not available items
            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }

            connection.Open();


            //notAvailItemsfromRestuarants

            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }

            connection.Open();
            SqlCommand cmd = new SqlCommand("notAvailItemsfromRestuarants1", connection);
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dSet);
            DataSet dt = new DataSet();
            dAd.Fill(dt, "NA");
            //Filtering restuarants

            string restCode = Application.Current.Properties["restcode"].ToString();
            if (Application.Current.Properties["restcode"].ToString().Trim() == "ZZ")
            {
                restCode = "HN";
            }
            else
            {
                restCode = Application.Current.Properties["restcode"].ToString();
            }
            //  dt.DefaultView.RowFilter = "saddress='" + textBox1.Text.Trim() + "'";
            //dSet.DefaultView.RowFilter = "RestCode = '" + restCode + "'";

            lvMenu.ItemsSource = dSet.DefaultView;

            if (connection.State.ToString() == "open") { connection.Close(); }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvMenu.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("RestCode");

            view.GroupDescriptions.Add(groupDescription);

        }

    }



}
