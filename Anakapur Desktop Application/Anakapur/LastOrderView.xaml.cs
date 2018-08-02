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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using AnkapurDAL;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for LastOrderView.xaml
    /// </summary>
    public partial class LastOrderView : Window
    {
        DataTable dSet = new DataTable();
        public CoreDAL _objdal = new CoreDAL();
        public LastOrderView()
        {

            InitializeComponent();




            fillNewOrders();

        }

        private void fillNewOrders()
        {
            string orderID;
            if (Application.Current.Properties["orderId"].ToString() == null)
            { orderID = "HN2312-1"; }
            else
            {
                orderID = Application.Current.Properties["orderId"].ToString();
            }//"BW1212-11";// (string)
            string connStr = _objdal.constring();
            // string connStr = "Data Source=XSILOKESH;Initial Catalog=Ankapur DB;Integrated Security=True";
            // string connStr = "Data Source=183.82.97.220;Initial Catalog=ankapur;Persist Security Info=True;User ID=test1;Password=123test";
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
                lblOrderID.Content = dSet.Rows[0][0].ToString().PadRight(5);
                lblCustName.Content = dSet.Rows[0][2].ToString() + " " + dSet.Rows[0][3].ToString().PadRight(5);
                lblAddress.Content = dSet.Rows[0][4].ToString();
                lblCustPhone.Content = dSet.Rows[0][1].ToString().PadRight(5);
                lblOrderDate.Content = dSet.Rows[0]["OrderDate"].ToString().Substring(0, 10);
                lblOrderTime.Content = dSet.Rows[0]["OrderTime"].ToString();
                ItemsCount = int.Parse(dSet.Rows.Count.ToString());
                int sum = Convert.ToInt32(dSet.Compute("SUM(Total)", string.Empty));
                int sum1 = Convert.ToInt32(dSet.Rows[0]["Deliverycharges"]);
                int sum2 = sum + sum1;
                //     decimal cgstcharges = decimal.Parse(dSet.Rows[0]["CGSTcharges"].ToString());
                //    decimal sgstcharges = decimal.Parse(dSet.Rows[0]["SGSTcharges"].ToString());
                //decimal endamount = (int)Math.Round(sum2 + cgstcharges + sgstcharges);
                decimal endamount = (sum2);
                lblItems.Content = ItemsCount;
                lbldelcharges.Content = sum1.ToString();//dSet.Rows[0]["Deliverycharges"].ToString();
                lblGrandTotal.Content = endamount.ToString();
                lblStatus.Content = dSet.Rows[0]["StatusDescription"].ToString();
            //    lblcgst.Content = cgstcharges.ToString();
            //    lblsgst.Content = sgstcharges.ToString();
                lblactamount.Content = sum.ToString();
            }

            if (connection.State.ToString() == "open") { connection.Close(); }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrders.Items.Count > 0)
            {
                print();

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to Print again?", "print", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    print();
                }
            }

            else { MessageBox.Show("Nothing to print !!!"); }
        }

        public void print()
        {
            PrintDialog printDlg = new PrintDialog();

            FlowDocument doc = SimpleFlowExample();
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        private FlowDocument SimpleFlowExample()
        {

            try
            {

                // Add some Bold text to the paragraph
                Paragraph myParagraph = new Paragraph();
                myParagraph.FontSize = 33;//hn
               // myParagraph.FontSize = 11;//asr,kp

                myParagraph.FontFamily = new FontFamily("Arial");
                myParagraph.Inlines.Add(new Bold(new Run("\t\tHimayath Nagar" + "\r\n\b")));//hn
              //  myParagraph.Inlines.Add(new Bold(new Run("\t\tA.S.Rao Nagar" + "\r\n\b"))); //asrao
             //   myParagraph.Inlines.Add(new Bold(new Run("\t\tKukatpally" + "\r\n\b"))); //kp
                myParagraph.Inlines.Add(new Run("\r\n"));
                myParagraph.Inlines.Add(new Run("Order ID : " + lblOrderID.Content.ToString().PadRight(5) + "\r\n"));
                myParagraph.Inlines.Add(new Bold(new Run(lblCustName.Content.ToString().PadRight(5) + "\r\n")));
                myParagraph.Inlines.Add(new Run("Phone : " + lblCustPhone.Content.ToString().PadRight(5) + "  " + lblAddress.Content.ToString() + "\r\n"));
                myParagraph.Inlines.Add(new Run("Items " + lblItems.Content.ToString().PadRight(5) + "  Total Amount : Rs." + lblactamount.Content.ToString() + "\r\n"));

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

                    pname = dSet.Rows[i]["ProductName"].ToString();
                    if (pname.Length > 13) { pname = pname.Substring(0, 13).PadRight(23); }
                    else
                    {
                        int pLen = pname.Length;
                        pname = pname.PadRight(23 - pLen);
                    }
                    string Pid = dSet.Rows[i]["ProductId"].ToString();
                    string qty = dSet.Rows[i]["Quantity"].ToString();
                    string Price = dSet.Rows[i]["Price"].ToString();
                    string Total = dSet.Rows[i]["Total"].ToString();


                    myParagraph.Inlines.Add(new Run(Pid.PadLeft(2) + (pname.PadLeft(2)) + string.Format("{0}", "\t") + qty.PadLeft(2) + string.Format("{0}", "\t") + Price.PadLeft(2) + string.Format("{0}", "\t") + Total.PadLeft(2) + "\r\n"));

                    //  myFlowDocument.Blocks.Add(myParagraph + "\n");
                }
                //myParagraph.Inlines.Add(new Run("\r\r\n\n"));
                //myParagraph.Inlines.Add(new Run("  Total Amount : Rs." + lblactamount.Content.ToString() + "\r\n"));
                //myParagraph.Inlines.Add(new Run("\r\n"));
                //myParagraph.Inlines.Add(new Run("  GST 12% :" + lblgst.Content.ToString() + "\r\n"));
                //myParagraph.Inlines.Add(new Run("\r\n"));
                //myParagraph.Inlines.Add(new Run("  Delivery Charge : Rs." + lbldelcharges.Content.ToString() + "\r\n"));
                //myParagraph.Inlines.Add(new Run("\r\n"));
                //myParagraph.Inlines.Add(new Run("  Grand Total : Rs." + lblGrandTotal.Content.ToString() + "\r\n"));
                //myParagraph.Inlines.Add(new Run("\r\n"));
                //myParagraph.Inlines.Add(new Run("Thank You visit again  040-69006900"));
                myParagraph.Inlines.Add(new Run("\r\n"));

                myParagraph.Inlines.Add(new Bold(new Run("  Total Amount " + lblactamount.Content.ToString().PadLeft(48) + "\r\n")));
                // myParagraph.Inlines.Add(new Run("\r\n"));
              //  myParagraph.Inlines.Add((new Run("  CGST " + lblcgst.Content.ToString().PadLeft(56) + "\r\n")));
                // myParagraph.Inlines.Add(new Run("\r\n"));
              //  myParagraph.Inlines.Add((new Run("  SGST " + lblsgst.Content.ToString().PadLeft(56) + "\r\n")));
                // myParagraph.Inlines.Add(new Run("\r\n"));
                myParagraph.Inlines.Add(new Bold(new Run("  Delivery Charge " + lbldelcharges.Content.ToString().PadLeft(45) + "\r\n")));
                //myParagraph.Inlines.Add(new Run("\r\n"));
                myParagraph.Inlines.Add(new Bold(new Run("  Grand Total" + lblGrandTotal.Content.ToString().PadLeft(52) + "\r\n")));

                myParagraph.Inlines.Add(new Bold(new Run("\r\n")));
                myParagraph.Inlines.Add(new Bold(new Run("  (GST Inclusive) \r\n")));

                myParagraph.Inlines.Add(new Bold(new Run("\r\n")));
                myParagraph.Inlines.Add(new Bold(new Run("  GSTIN:" + lblGSTIN.Content.ToString().PadLeft(15) + "\r\n")));
                myParagraph.Inlines.Add(new Bold(new Run("\r\n")));
                myParagraph.Inlines.Add(new Bold(new Run("Thank You visit again 7306544444")));
                //  myParagraph.Inlines.Add(pLine);
                myFlowDocument.ColumnWidth = 999999;
                myFlowDocument.PagePadding = new Thickness(10);
                // Padding is 5 pixels on the right and left, and 10 pixels on the top and botton.
                myFlowDocument.PagePadding = new Thickness(40, 10, 5, 10);

                //  myParagraph.Inlines.Add(image);


                BlockUIContainer uiCont = new BlockUIContainer();

                Label myButton = new Label
                {
                    //Width = 350,
                    //Height = 250,
                    Width = 200,
                    Height = 100,
                    //  HorizontalAlignment = HorizontalAlignment.Left,//kp,an
                    HorizontalAlignment = HorizontalAlignment.Center,//hn
                    Background = new SolidColorBrush(Colors.White),
                    Content = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\user\Downloads\AC.png", UriKind.Relative)),//hn
                       //  Source = new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\AC.png", UriKind.Relative)),//asr
                       //  Source = new BitmapImage(new Uri(@"D:\AC.png", UriKind.Relative)),//kp

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
            catch (Exception ex)
            { throw ex; }

            //    SqlConnection connection;
            //    connection = new SqlConnection(connStr);
            //    if (connection.State.ToString() == "open") { connection.Close(); }
            //    connection.Open();
            //    SqlCommand cmd = new SqlCommand("[PrintorderStatusByOrderId]", connection);
            //    cmd.Parameters.Add(new SqlParameter("OrderId", orderID));
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    //  @Categorytype = N'Break Fast'

            //    SqlDataAdapter dAd = new SqlDataAdapter(cmd);

            //    dAd.Fill(dSet);
            //    // sda.Fill(dt);

            //    int ItemsCount = 0;
            //    lvOrders.Items.Clear();
            //    if (dSet.Rows.Count > 0) {
            //        lvOrders.ItemsSource = dSet.DefaultView;
            //        lblOrderID.Content = dSet.Rows[0][0].ToString();
            //        lblCustName.Content= dSet.Rows[0][2].ToString() +" "+ dSet.Rows[0][3].ToString();
            //        lblAddress.Content= dSet.Rows[0][4].ToString();
            //        lblCustPhone.Content= dSet.Rows[0][1].ToString();
            //        lblOrderDate.Content =     dSet.Rows[0]["OrderDate"].ToString().Substring(0,10) ;



            //        lblOrderTime.Content = dSet.Rows[0]["OrderTime"].ToString();
            //        ItemsCount = int.Parse(dSet.Rows.Count.ToString());
            //        int sum = Convert.ToInt32(dSet.Compute("SUM(Total)", string.Empty));
            //        lblItems.Content = ItemsCount;
            //        lblGrandTotal.Content = sum.ToString();
            //        lblStatus.Content="Order Status: " + dSet.Rows[0]["StatusDescription"].ToString(); 
            //    }

            //    if (connection.State.ToString() == "open") { connection.Close(); }

            //}

            //private void Button_Click(object sender, RoutedEventArgs e)
            //{
            //    if (lvOrders.Items.Count > 0)
            //    {
            //        PrintDialog printDlg = new PrintDialog();

            //        // Create a FlowDocument dynamically.
            //        //   FlowDocument doc = CreateFlowDocument();
            //        FlowDocument doc = SimpleFlowExample();
            //        doc.Name = "FlowDoc";

            //        // Create IDocumentPaginatorSource from FlowDocument
            //        IDocumentPaginatorSource idpSource = doc;

            //        // Call PrintDocument method to send document to printer
            //        printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            //       // printDlg.ShowDialog = false;  
            //    }

            //    else { MessageBox.Show("Nothing to print !!!"); }
            //}




            //private FlowDocument SimpleFlowExample()
            //{



            //    // Add some Bold text to the paragraph
            //    Paragraph myParagraph = new Paragraph();

            //    myParagraph.FontSize = 33;
            //    myParagraph.FontFamily = new FontFamily("Arial");
            //    myParagraph.Inlines.Add(new Bold(new Run("\t\tHimayath Nagar" + "\r\n\b")));
            //    myParagraph.Inlines.Add(new Run("Order ID : " + lblOrderID.Content.ToString().PadLeft(0) + "\r\n"));
            //    myParagraph.Inlines.Add(new Bold(new Run(lblCustName.Content.ToString().PadLeft(0) + "\r\n")));
            //    myParagraph.Inlines.Add(new Run("Phone : " + lblCustPhone.Content.ToString().PadLeft(0) + "  " + lblAddress.Content.ToString() + "\r\n"));
            //    myParagraph.Inlines.Add(new Run("Items " + lblItems.Content.ToString().PadLeft(0) + "  Total Amount : Rs." + lblGrandTotal.Content.ToString() + "\r\n"));

            //    // Create a FlowDocument and add the paragraph to it.
            //    FlowDocument myFlowDocument = new FlowDocument();
            //    myFlowDocument.Blocks.Add(myParagraph);

            //    Line pLine = new Line();
            //    pLine.Stretch = Stretch.Fill;
            //    pLine.Stroke = Brushes.Black;
            //    pLine.X2 = 1;
            //    pLine.StrokeThickness = 1;
            //    myParagraph.Inlines.Add(pLine);
            //    // Add some plain text to the paragraph

            //    // Create a List and populate with three list items.

            //    //   myParagraph.Inlines.Add(new Run(" Customer Name : " + lblCustName.Content.ToString()));
            //    myParagraph.Inlines.Add(new Run("Code".PadLeft(0) + string.Format("{0}", "\t") + "Dish".PadLeft(3) + string.Format("{0}", "\t") + string.Format("{0}", "\t") + "Qty".PadLeft(3) + string.Format("{0}", "\t") + "Price".PadLeft(3) + string.Format("{0}", "\t") + "Total".PadLeft(3) + "\r\n"));
            //    // myParagraph.Inlines.Add(pLine);
            //    int ordercount = lvOrders.Items.Count;
            //    for (int i = 0; i < ordercount; i++)
            //    {
            //        TableRow tblRow = new TableRow();
            //        TableCell tblCell1 = new TableCell();
            //        TableCell tblCell2 = new TableCell();
            //        //     myParagraph.Inlines.Add(new Run("Cell ID1" + i + "\r\n"));

            //        tblRow.Cells.Add(tblCell1);
            //        tblRow.Cells.Add(tblCell2);
            //        string pname;

            //        pname = dSet.Rows[i]["ProductName"].ToString();
            //        if (pname.Length > 10) { pname = pname.Substring(0, 10).PadRight(20); }
            //        else
            //        {
            //            int pLen = pname.Length;
            //            pname = pname.PadRight(20 - pLen);
            //        }
            //        string Pid = dSet.Rows[i]["ProductId"].ToString();
            //        string qty = dSet.Rows[i]["Quantity"].ToString();
            //        string Price = dSet.Rows[i]["Price"].ToString();
            //        string Total = dSet.Rows[i]["Total"].ToString();


            //        myParagraph.Inlines.Add(new Run(Pid.PadLeft(1) + (pname.PadLeft(1)) + string.Format("{0}", "\t") + qty.PadLeft(1) + string.Format("{0}", "\t") + Price.PadLeft(1) + string.Format("{0}", "\t") + Total.PadLeft(1) + "\r\n"));

            //        //  myFlowDocument.Blocks.Add(myParagraph + "\n");
            //    }
            //    //  myParagraph.Inlines.Add(pLine);
            //    myFlowDocument.ColumnWidth = 999999;


            //    //  myParagraph.Inlines.Add(image);


            //    BlockUIContainer uiCont = new BlockUIContainer();

            //    Label myButton = new Label
            //    {
            //        Width = 400,
            //        Height = 300,
            //        HorizontalAlignment = HorizontalAlignment.Center,
            //        Background = new SolidColorBrush(Colors.White),
            //        Content = new Image
            //        {
            //            Source = new BitmapImage(new Uri(@"C:\Users\venkat\Documents\Visual Studio 2015\Projects\Project3\AnkapurProject\Anakapur\Images\AC.jpg", UriKind.Relative)),
            //            VerticalAlignment = VerticalAlignment.Center
            //        }
            //    };

            //    //  b.Content = "Click me";
            //    uiCont.Child = (myButton);
            //    myFlowDocument.Blocks.Add(uiCont);
            //    myFlowDocument.Blocks.Add(myParagraph);
            //    // myFlowDocument.Blocks.Add(myList);



            //    // Add the FlowDocument to a FlowDocumentReader Control
            //    FlowDocumentReader myFlowDocumentReader = new FlowDocumentReader();
            //    myFlowDocumentReader.Document = myFlowDocument;

            //    this.Content = myFlowDocumentReader;

            //    return myFlowDocument;
        }
    }
}
