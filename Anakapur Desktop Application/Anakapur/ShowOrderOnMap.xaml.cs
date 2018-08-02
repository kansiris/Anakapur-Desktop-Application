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
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
 using System.Data;
using System.Data.SqlClient;
 using System.Windows.Navigation;
using System.Text.RegularExpressions;
using AnkapurDAL;
using System.Configuration;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for ShowOrderOnMap.xaml
    /// </summary>
    /// 
    

    public partial class ShowOrderOnMap : Window
    {
        public CoreDAL _objdal = new CoreDAL();
        string connStr = "";
        //_objdal.connstring();
        //ConfigurationManager.ConnectionStrings["connstring"].ToString();

        public ShowOrderOnMap()
        {
            InitializeComponent();


            connStr = _objdal.constring().ToString();

            AddPins();
        }

        private void AddPins()
        {

            string[] Status = { "None", "New Order", "Prepared", "Payment due", "Payment complete", "Driver Assigned", "Delivered", "Refunded", "Cancelled", "Modified", "On Hold", "Order Complete" };
            //getTodayNotDeliverByRest
            string restCode;
            //Application.Current.Properties["restcode"] = "";
            if ((Application.Current.Properties["restcode"].ToString().Trim().Length) > 0 || (Application.Current.Properties["empcode"]) != null)

            {
                restCode = Application.Current.Properties["restcode"].ToString().Trim();
            }
            else { restCode = "HN"; }


            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("getTodayNotDeliverByRest", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@restcode", restCode));
            //  @Categorytype = N'Break Fast'
            SqlDataAdapter dAd = new SqlDataAdapter(cmd);
            DataTable dSet = new DataTable();
            dAd.Fill(dSet); //lblCustName lblCustPhone  lblCustAddr
            if (connection.State.ToString() == "open") { connection.Close(); }
            if (dSet.Rows.Count > 0)
            {
                myMap.Children.Clear();
                //orderid,DeliveryBoycode,customerphone,Latitude,Longitude,NoOfProducts,TotalAmount
                for(int i=0; i<=dSet.Rows.Count-1; i++)
                {

                    if (dSet.Rows[i][3].ToString().Length>0 )
                    {
                        Pushpin pin = new Pushpin();
                        Location pinLocation = new Location();// lblLat.Content.ToString() + "," + lblLong.Content.ToString();
                        pinLocation.Latitude = double.Parse(dSet.Rows[i][3].ToString());
                        pinLocation.Longitude = double.Parse(dSet.Rows[i][4].ToString());
                        pin.Content = "Order ID : " + dSet.Rows[i][0].ToString() + "Delivery Boy : " + dSet.Rows[i][1].ToString() + "Customer phone :" + dSet.Rows[i][4].ToString();
                        pin.Location = pinLocation;
                        ToolTipService.SetToolTip(pin, "Order ID : " + dSet.Rows[i][0].ToString()+ "\r\n" + "Customer phone :" + dSet.Rows[i][2].ToString()+ "\r\n" + "Customer Name :" + dSet.Rows[i][7].ToString().ToUpper() + "\r\n" + "Status:" + Status[int.Parse( dSet.Rows[i]["statusid"].ToString())]);
                        pin.Background = new SolidColorBrush(Color.FromRgb(0, 0, 255));//Red color //Blue(0,0,255)//Yellow (255,255,0) Green(0,255,0)

                        int expression = int.Parse(dSet.Rows[i]["statusid"].ToString());
                        switch (expression)
                        {
                            case 1:
                                pin.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));//Red color //Blue(0,0,255)//Yellow (255,255,0) Green(0,255,0)
                               break; /* optional */
                            case 2  :
                                pin.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));//Red color //Blue(0,0,255)//Yellow (255,255,0) Green(0,255,0)
                                break; /* optional */

                                /* you can have any number of case statements */
                                // default: /* Optional */

                                //pin.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));//Red color //Blue(0,0,255)//Yellow (255,255,0) Green(0,255,0)

                        }


                        pin.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0 ));//Red color //Blue(0,0,255)//Yellow (255,255,0) Green(0,255,0)
                        //   A/dds the pushpin to the map.
                       
                        myMap.Children.Add(pin);

                    }
                }
               
            }
        }
    }
}
