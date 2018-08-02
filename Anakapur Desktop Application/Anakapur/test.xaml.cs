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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using AnkapurDAL;
using System.IO;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        DataTable dSet = new DataTable();
        public CoreDAL _objdal = new CoreDAL();
        public test()
        {
            InitializeComponent();
            fillNewOrders();
        }
        private void fillNewOrders()
        {
            string orderID = "HN2312-1";// Application.Current.Properties["orderId"].ToString();//"BW1212-11";// (string)
            //string connStr = "Data Source=SAIKRISHNA;Initial Catalog=ankapur;Persist Security Info=True;User ID=ankapuruser1;Password=user123";
            string connStr = "Data Source=XSILOKESH;Initial Catalog=Ankapur;Persist Security Info=True;User ID=test;Password=user123";


            SqlConnection connection;
            connection = new SqlConnection(connStr);
            if (connection.State.ToString() == "open") { connection.Close(); }
            connection.Open();
            SqlCommand cmd = new SqlCommand("[PrintorderStatusByOrderId]", connection);
            cmd.Parameters.Add(new SqlParameter("OrderId", orderID));
            cmd.CommandType = CommandType.StoredProcedure;

            //  @Categorytype = N'Break Fast'

            SqlDataAdapter dAd = new SqlDataAdapter(cmd);

            dAd.Fill(dSet);
            // sda.Fill(dt);

            int ItemsCount = 0;
            lvOrders.Items.Clear();
            if (dSet.Rows.Count > 0)
            {
                lvOrders.ItemsSource = dSet.DefaultView;
                lblOrderID.Content = dSet.Rows[0][0].ToString();
                lblCustName.Content = dSet.Rows[0][2].ToString() + " " + dSet.Rows[0][3].ToString();
                lblAddress.Content = dSet.Rows[0][4].ToString();
                lblCustPhone.Content = dSet.Rows[0][1].ToString();
                lblOrderDate.Content = dSet.Rows[0]["OrderDate"].ToString().Substring(0, 10);



                lblOrderTime.Content = dSet.Rows[0]["OrderTime"].ToString();
                ItemsCount = int.Parse(dSet.Rows.Count.ToString());
                int sum = Convert.ToInt32(dSet.Compute("SUM(Total)", string.Empty));
                lblItems.Content = ItemsCount;
                lblGrandTotal.Content = sum.ToString();
                lblStatus.Content = dSet.Rows[0]["StatusDescription"].ToString();
            }

            if (connection.State.ToString() == "open") { connection.Close(); }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrders.Items.Count > 0)
            {
                PrintDialog printDlg = new PrintDialog();
               

                // Create a FlowDocument dynamically.
                //   FlowDocument doc = CreateFlowDocument();
                FlowDocument doc = SimpleFlowExample();
                doc.Name = "FlowDoc";

                // Create IDocumentPaginatorSource from FlowDocument
                IDocumentPaginatorSource idpSource = doc;

                // Call PrintDocument method to send document to printer
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
                // printDlg.ShowDialog = false;  
            }

            else { MessageBox.Show("Nothing to print !!!"); }
        }



        private FlowDocument SimpleFlowExample()
        {



            // Add some Bold text to the paragraph
            Paragraph myParagraph = new Paragraph();





            myParagraph.FontSize = 12;
            myParagraph.FontFamily = new FontFamily("Arial");
            myParagraph.Inlines.Add(new Bold(new Run("\t\tHimayath Nagar" + "\r\n\b")));
            myParagraph.Inlines.Add(new Run("Order ID : " + lblOrderID.Content.ToString() + "\r\n"));
            myParagraph.Inlines.Add(new Bold(new Run(lblCustName.Content.ToString() + "\r\n")));
            myParagraph.Inlines.Add(new Run("Phone : " + lblCustPhone.Content.ToString() + "  " + lblAddress.Content.ToString() + "\r\n"));
            myParagraph.Inlines.Add(new Run("Items " + lblItems.Content.ToString() + "  Total Amount : Rs." + lblGrandTotal.Content.ToString() + "\r\n"));

            // Create a FlowDocument and add the paragraph to it.
            FlowDocument myFlowDocument = new FlowDocument();
            myFlowDocument.Blocks.Add(myParagraph);

            Line pLine = new Line();
            pLine.Stretch = Stretch.Fill;
            pLine.Stroke = Brushes.Black;
            pLine.X2 = 1;
            pLine.StrokeThickness = 1;
            myParagraph.Inlines.Add(pLine);
            // Add some plain text to the paragraph

            // Create a List and populate with three list items.

            //   myParagraph.Inlines.Add(new Run(" Customer Name : " + lblCustName.Content.ToString()));
            myParagraph.Inlines.Add(new Run("Code".PadLeft(2) + string.Format("{0}", "\t") + "Dish".PadLeft(5) + string.Format("{0}", "\t") + string.Format("{0}", "\t") + "Qty".PadLeft(5) + string.Format("{0}", "\t") + "Price".PadLeft(5) + string.Format("{0}", "\t") + "Total".PadLeft(5) + "\r\n"));
            // myParagraph.Inlines.Add(pLine);
            int ordercount = lvOrders.Items.Count;
            for (int i = 0; i < ordercount; i++)
            {
                TableRow tblRow = new TableRow();
                TableCell tblCell1 = new TableCell();
                TableCell tblCell2 = new TableCell();
                //     myParagraph.Inlines.Add(new Run("Cell ID1" + i + "\r\n"));

                tblRow.Cells.Add(tblCell1);
                tblRow.Cells.Add(tblCell2);
                string pname;
                //if (dSet.Rows[i]["ProductName"].ToString().Length > 10) { pname = dSet.Rows[i]["ProductName"].ToString().Substring(0, 10).Trim();
                //pname  = $"{pname,10}";
                //}
                //else pname = dSet.Rows[i]["ProductName"].ToString();//.Substring(0, 5).Trim();
                pname = dSet.Rows[i]["ProductName"].ToString();
                if (pname.Length > 10) { pname = pname.Substring(0, 10).PadRight(20); }
                else
                {
                    int pLen = pname.Length;
                    pname = pname.PadRight(20 - pLen);
                }
                string Pid = dSet.Rows[i]["ProductId"].ToString();
                string qty = dSet.Rows[i]["Quantity"].ToString();
                string Price = dSet.Rows[i]["Price"].ToString();
                string Total = dSet.Rows[i]["Total"].ToString();


                myParagraph.Inlines.Add(new Run(Pid.PadLeft(2) + (pname.PadLeft(2)) + string.Format("{0}", "\t") + qty.PadLeft(2) + string.Format("{0}", "\t") + Price.PadLeft(2) + string.Format("{0}", "\t") + Total.PadLeft(2) + "\r\n"));

                //  myFlowDocument.Blocks.Add(myParagraph + "\n");
            }
            //  myParagraph.Inlines.Add(pLine);
            myFlowDocument.ColumnWidth = 999999;


            //  myParagraph.Inlines.Add(image);


            BlockUIContainer uiCont = new BlockUIContainer();

            Label myButton = new Label
            {
                Width = 200,
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = new SolidColorBrush(Colors.White),
                Content = new Image
                {
                    Source = new BitmapImage(new Uri(@"C:\Users\venkat\Documents\Visual Studio 2015\Projects\Project3\AnkapurProject\Anakapur\Images\AC.jpg", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center
                }
            };

            //  b.Content = "Click me";
            uiCont.Child = (myButton);
            myFlowDocument.Blocks.Add(uiCont);
            myFlowDocument.Blocks.Add(myParagraph);
            // myFlowDocument.Blocks.Add(myList);



            // Add the FlowDocument to a FlowDocumentReader Control
            FlowDocumentReader myFlowDocumentReader = new FlowDocumentReader();
           
            myFlowDocumentReader.Document = myFlowDocument;
            //FlowDocument fp = new FlowDocument();
           
            this.Content = myFlowDocumentReader;

            return myFlowDocument;
        }
    }
}
