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
using AnkapurBAL;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;


namespace Anakapur
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private ProductsBal _objbal = new ProductsBal();
        ProductProperties Pp = new ProductProperties();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public ProductsPage()
        {
            //Edit.IsEnabled = false;
            InitializeComponent();
            Bindcategorydtls(cmbcatType);
            Binddishdtls(cmbDishType);
            BindItemdtls(cmbitemcode);
            GetProdMasterDetails();
            btnEdit.IsEnabled = false;
        }

        public void Bindcategorydtls(ComboBox cmbcategType)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _objbal.GetCategoryType();
                cmbcategType.ItemsSource = ds.Tables[0].DefaultView;
                cmbcategType.DisplayMemberPath = ds.Tables[0].Columns["CategoryType"].ToString();
                cmbcategType.SelectedValuePath = ds.Tables[0].Columns["CategoryID"].ToString();
                cmbcategType.SelectedIndex = 0;
                //cmbcategType.Tag = ds.Tables[0].Columns["CategoryID"].ToString();
                //cmbcategType.SelectedValue = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Binddishdtls(ComboBox cmbdish)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _objbal.GetdishType();
                cmbdish.ItemsSource = ds.Tables[0].DefaultView;
                cmbdish.DisplayMemberPath = ds.Tables[0].Columns["DishType"].ToString();
                cmbdish.SelectedValuePath = ds.Tables[0].Columns["DishTypeId"].ToString();
                cmbdish.SelectedIndex = 0;
                //cmbdish.Items.Insert(0, "-SELECT DishType-");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void charValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void BindItemdtls(ComboBox cmbitem)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _objbal.GetItemCode();
                cmbitem.ItemsSource = ds.Tables[0].DefaultView;
                cmbitem.DisplayMemberPath = ds.Tables[0].Columns["Description"].ToString();
                cmbitem.SelectedValuePath = ds.Tables[0].Columns["ItemCode"].ToString();
                cmbitem.SelectedIndex = 0;
                cmbitem.Tag = ds.Tables[0].Columns["ItemCode"].ToString();

                //cmbitem.Items.Insert(0, "-SELECT ItemCode-");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetProdDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _objbal.GetProdBasedOnRestaurantGetProData();
                GridProducts.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetProdMasterDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _objbal.GetProdMasterDtls();
                if (dt.Rows.Count > 0)
                {
                    GridProducts.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Unable to load the data");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getmaxid()
        {
            if (cmbitemcode.SelectedItem == null)
            {
                MessageBox.Show("Please select the item code");
            }
        }

        private void cmbitemcode_TextChanged_1(object sender, RoutedEventArgs e)
        {
            string code;
            string itemcode = cmbitemcode.SelectedValue.ToString().Trim().ToUpper();
            DataTable ds = new DataTable();
            ds = _objbal.GetMaxProdId(itemcode);
            code = ds.Rows[0][0].ToString();
            if ((code).Length == 1) { code = "00" + code; }
            if ((code).Length == 2) { code = "0" + code; }
            txtprodcod.Text = this.cmbitemcode.SelectedValue.ToString().Trim().ToUpper() + code;
        }


        private void GridProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string category;
            category = cmbcatType.SelectionBoxItem.ToString();
            string dishtype;
            dishtype = cmbDishType.SelectionBoxItem.ToString();
            Submit.IsEnabled = false;
            btnEdit.IsEnabled = true;
            cmbitemcode.IsEnabled = false;
            DataRowView dt;
            int ind;
            ind = GridProducts.SelectedIndex;
            if (GridProducts.SelectedIndex != -1)
            {
                dt = GridProducts.Items.GetItemAt(ind) as DataRowView;
                txtprodcod.Text = dt.Row[0].ToString();
                txtProdName.Text = dt.Row[1].ToString();
                txtshortdesc.Text = dt.Row[2].ToString();
                txtPrice.Text = dt.Row[4].ToString();
                txtktdesc.Text = dt.Row["Kitchen description"].ToString();
                cmbactive.Text = dt.Row[5].ToString();
                (category) = dt.Row[8].ToString();
                cmbcatType.SelectedValue = category;
                dishtype = dt.Row[9].ToString();
                cmbDishType.SelectedValue = dishtype;
                if (dt.Row["Image"].ToString() != "" || dt.Row["Image"].ToString() != string.Empty)
                {

                    string base64 = Convert.ToBase64String((Byte[])(dt.Row["Image"]));
                    byte[] binaryData = Convert.FromBase64String(base64);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(binaryData);
                    bi.EndInit();
                    imgPhoto.Source = bi;
                }
            }
        }

        private void Submit_Click_1(object sender, RoutedEventArgs e)
        {
            string Str;
            try
            {
                if (cmbitemcode.SelectedItem == null)
                {
                    MessageBox.Show("Please select the item code");
                }
                else if (cmbDishType.Text == "")
                { MessageBox.Show("Please select the Dish Type"); }
                else if (cmbcatType.Text == "")
                { MessageBox.Show("Please select the Category"); }
                else if (cmbitemcode.SelectedIndex == 0)
                { MessageBox.Show("Please select the ItemCode"); cmbitemcode.Focus(); }
                else if (cmbDishType.SelectedIndex == 0)
                { MessageBox.Show("Please select the DishType"); cmbDishType.Focus(); }
                else if (cmbcatType.SelectedIndex == 0)
                { MessageBox.Show("Please select the CategoryType"); cmbcatType.Focus(); }
                else if (txtProdName.Text.Length == 0)
                {
                    MessageBox.Show("Enter product Name");
                    txtProdName.Focus();
                }
                else if (txtPrice.Text.Length == 0)
                {
                    MessageBox.Show("Enter product Price");
                    txtPrice.Focus();
                }
                else if (txtRemarks.Text == "")
                {
                    MessageBox.Show("Enter Remarks");
                    txtRemarks.Focus();
                }
                else if (txtshortdesc.Text.Length == 0)
                {
                    MessageBox.Show("Enter Description");
                    txtshortdesc.Focus();
                }
                else if (txtFileName.Text.Length == 0)
                {
                    MessageBox.Show("Choose  File to upload");
                    txtFileName.Focus();
                }
                else if (txtsih.Text.Length == 0)
                {
                    MessageBox.Show("select stock in hand");
                    txtsih.Focus();
                }
                else if (txtQuantity.Text.Length == 0)
                {
                    MessageBox.Show("select  Quantity");
                    txtQuantity.Focus();
                }
                else
                {
                    FileStream fs = new FileStream(txtFileName.Text, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    string[] files = fs.Name.Split(new char[] { '\\' });
                    string fileName = files[files.Length - 1];
                    Stream stream = new MemoryStream(imgByteArr);

                    Str = cmbactive.SelectionBoxItem.ToString();
                    Pp.Available = Boolean.Parse(Str);
                    Pp.CategoryID = int.Parse(cmbcatType.SelectedValue.ToString());
                    //Pp.Discounts = Convert.ToDecimal(txtdiscount.Text);
                    Pp.DishTypeID = int.Parse(cmbDishType.SelectedValue.ToString());
                    Pp.ProductID = txtprodcod.Text;
                    //Pp.ImageUrl = txtImageurl.Text;
                    Pp.ItemCode = cmbitemcode.SelectedValue.ToString().Trim().ToUpper();
                    Pp.LongDescription = txtlongdesc.Text;
                    Pp.Price = Convert.ToDecimal(txtPrice.Text);
                    Pp.ProductName = txtProdName.Text;
                    Pp.Quantity = txtQuantity.Text;
                    Pp.Remarks = txtRemarks.Text;
                    Pp.ShortDescription = txtshortdesc.Text;
                    Pp.SIH = Convert.ToInt32(txtsih.Text);
                    Pp.Kitchen_Description = txtktdesc.Text;
                    //Pp.Tax = Convert.ToDecimal(txtTax.Text);
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        Pp.Image = bytes;
                        string prd = _objbal.AddDtlsToProdMaster(Pp);
                        MessageBoxResult mb = MessageBox.Show("Product Added Successfully", "Product Details", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetProdMasterDetails();
                        Clearcontrols();
                        imgPhoto.Source = null;
                        txtFileName.Text = "";
                        btnEdit.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Edit_Click_1(object sender, RoutedEventArgs e)
        {
            string Str;
            try
            {
                if (txtprodcod.Text.Length == 0)
                {
                    MessageBox.Show("Product Code Is Mandatory");
                }
                //if (txtRemarks.Text.Length == 0 || txtRemarks.Text == null)
                //{
                //    MessageBox.Show("Enter Remarks");
                //    txtRemarks.Focus();
                //}
                //else if (txtFileName.Text == "")
                //{
                //    MessageBox.Show("Enter an Image.");
                //    txtFileName.Focus();
                //}
                else if (txtProdName.Text.Length == 0)
                {
                    MessageBox.Show("Enter product Name");
                    txtProdName.Focus();
                }
                else if (txtPrice.Text.Length == 0)
                {
                    MessageBox.Show("Enter product Price");
                    txtPrice.Focus();
                }

                else if (txtshortdesc.Text.Length == 0)
                {
                    MessageBox.Show("Enter Description");
                    txtshortdesc.Focus();
                }
                FileStream fs = new FileStream(txtFileName.Text, FileMode.Open, FileAccess.Read);
                byte[] imgByteArr = new byte[fs.Length];
                string[] files = fs.Name.Split(new char[] { '\\' });
                string fileName = files[files.Length - 1];
                Stream stream = new MemoryStream(imgByteArr);
                Str = cmbactive.SelectionBoxItem.ToString();
                Pp.Available = Boolean.Parse(Str);
                Pp.ProductID = txtprodcod.Text;
                Pp.ProductName = txtProdName.Text;
                Pp.Remarks = txtRemarks.Text;
                Pp.ShortDescription = txtshortdesc.Text;
                Pp.Price = Convert.ToDecimal(txtPrice.Text);
                Pp.Kitchen_Description = txtktdesc.Text;
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    Pp.Image = bytes;
                    string prd = _objbal.EditProductdetails(Pp);
                MessageBox.Show("Product Updated Successfully", "Product Details", MessageBoxButton.OK, MessageBoxImage.Information);

                GetProdMasterDetails();
                Clearcontrols();
                imgPhoto.Source = null;
                txtFileName.Text = "";
                Submit.IsEnabled = true;
                btnEdit.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clearcontrols()
        {
            txtdiscount.Text = "";
            txtFileName.Text = "";
            txtlongdesc.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtprodcod.Text = "";
            txtProdName.Text = "";
            txtQuantity.Text = "";
            txtRemarks.Text = "";
            txtshortdesc.Text = "";
            txtTax.Text = "";
            txtktdesc.Text = "";
        }

        private void BTN_BROWSE_FILE_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                txtFileName.Text = openFileDialog.FileName;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(openFileDialog.FileName);
            bitmap.EndInit();
            imgPhoto.Source = bitmap;
        }

        private void cmbitemcode_KeyDown(object sender, KeyEventArgs e)
        {
            string code;
            string itemcode = cmbitemcode.SelectedValue.ToString().Trim().ToUpper();
            DataTable ds = new DataTable();
            ds = _objbal.GetMaxProdId(itemcode);
            code = ds.Rows[0][0].ToString();
            if ((code).Length == 1) { code = "00" + code; }
            if ((code).Length == 2) { code = "0" + code; }
            txtprodcod.Text = this.cmbitemcode.SelectedValue.ToString().Trim().ToUpper() + code;
        }

        private void cmbitemcode_LostFocus(object sender, RoutedEventArgs e)
        {
            string code;
            string itemcode = cmbitemcode.SelectedValue.ToString().Trim().ToUpper();
            DataTable ds = new DataTable();
            ds = _objbal.GetMaxProdId(itemcode);
            code = ds.Rows[0][0].ToString();
            if ((code).Length == 1) { code = "00" + code; }
            if ((code).Length == 2) { code = "0" + code; }
            txtprodcod.Text = this.cmbitemcode.SelectedValue.ToString().Trim().ToUpper() + code;
        }
    }
}
