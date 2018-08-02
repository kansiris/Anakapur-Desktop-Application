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
using MahApps.Metro.Controls;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for empAddPage.xaml
    /// </summary>
    public partial class empAddPage : Page
    {
        private EmployeeBal _objbal = new EmployeeBal();
        EmployeeProperties ep = new EmployeeProperties();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public empAddPage()
        {
            InitializeComponent();
            GetEmpdetails();
            BindUserDetails(cmbusercode);
            BindRestaurantdtls(cmbrestcode);
            Edit.IsEnabled = false;
            Changepw.IsEnabled = false;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string str;
            string mob1 = txtMobile1.Text.ToString();
            string mob2 = txtMobile2.Text.ToString();
            string emppw = txtEmpPW.Text.ToString();
            string empemail = txtEmailId.Text.ToString();
            DataTable dt = new DataTable();
            dt = _objbal.chkempmo(mob1);
            int MOB1 = Convert.ToInt32(dt.Rows[0][0].ToString());
            DataTable dt1 = new DataTable();
            dt1 = _objbal.chkempmo2(mob2);
            int MOB2 = Convert.ToInt32(dt1.Rows[0][0].ToString());
            DataTable dt2 = new DataTable();
            dt2 = _objbal.chkempemail(empemail);
            int eml = Convert.ToInt32(dt2.Rows[0][0].ToString());
            try
            {
                if (txtFirstName.Text == "" && txtLastName.Text == "")
                {
                    MessageBox.Show("Please Enter the Details");
                }
                else if (txtEmailId.Text.Length == 0)
                {
                    MessageBox.Show("Enter an email.");
                    txtEmailId.Focus();
                }
                else if (txtMobile1.Text.Length == 0)
                {
                    MessageBox.Show("Enter the Mobile Number.");
                    txtMobile1.Focus();
                }
                else if (txtMobile2.Text.Length == 0)
                {
                    MessageBox.Show("Enter the Mobile Number.");
                    txtMobile2.Focus();
                }
                else if (txtFileName.Text == "")
                {
                    MessageBox.Show("Enter an Image.");
                    txtFileName.Focus();
                }
                else if (!Regex.IsMatch(txtEmailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Enter a valid email.");
                    txtEmailId.Select(0, txtEmailId.Text.Length);
                    txtEmailId.Focus();
                }
                else if (!Regex.IsMatch(txtMobile1.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Enter a valid Mobile Number.");
                    txtMobile1.Select(0, txtMobile1.Text.Length);
                    txtMobile1.Focus();
                }
                else if (!Regex.IsMatch(txtMobile2.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Enter a valid Mobile Number.");
                    txtMobile2.Select(0, txtMobile1.Text.Length);
                    txtMobile2.Focus();
                }
             
                else if (cmbrestcode.Text == "" || cmbrestcode.Text == null)
                { MessageBox.Show("Please select the Restaurant"); cmbrestcode.Focus(); }
                else if (cmbusercode.Text == "" || cmbusercode.Text == null)
                { MessageBox.Show("Please select the UserType"); cmbusercode.Focus(); }
                else if (cmbactive.Text == "" || cmbactive.Text == null)
                { MessageBox.Show("Please select the Availability"); cmbactive.Focus(); }
                else if (cmbusercode.SelectedIndex == 0)
                { MessageBox.Show("Please select the UserType"); cmbusercode.Focus(); }
                else if (cmbrestcode.SelectedIndex == 0)
                { MessageBox.Show("Please select the Restaurant"); cmbrestcode.Focus(); }
                else if (MOB1 >= 1)
                {
                    MessageBox.Show("The Mobile Number is already Registered", "Mobile1", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtMobile1.Focus();
                    txtMobile1.SelectAll();
                }
                else if (MOB2 >= 1)
                {
                    MessageBox.Show("The Mobile Number is already Registered", "Mobile2", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtMobile2.Focus();
                    txtMobile2.SelectAll();
                }
                else if (eml >= 1)
                {
                    MessageBox.Show("The EmailId is already Registered", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtEmailId.Focus();
                    txtEmailId.SelectAll();
                }
                else
                {
                    FileStream fs = new FileStream(txtFileName.Text, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    string[] files = fs.Name.Split(new char[] { '\\' });
                    string fileName = files[files.Length - 1];
                    Stream stream = new MemoryStream(imgByteArr);

                    SqlCommand com = new SqlCommand();
                    ep.First_Name = txtFirstName.Text;
                    ep.Last_Name = txtLastName.Text;
                    ep.Address1 = txtAddress1.Text;
                    ep.Address2 = txtAddress2.Text;
                    ep.Mobile1 = txtMobile1.Text;
                    ep.Mobile2 = txtMobile2.Text;

                    ep.CustPhoneNumber = txtMobile1.Text;
                    ep.CustomerFName = txtFirstName.Text;
                    ep.CustomerLName = txtLastName.Text;
                    ep.Billing_Address = txtAddress1.Text;
                    ep.Delivery_Addresss = txtAddress2.Text;
                    ep.CustomerTypeId = 5;

                    str = cmbactive.SelectionBoxItem.ToString();
                    
                    ep.Active = Boolean.Parse(str);
                    ep.RestCode = cmbrestcode.SelectedValue.ToString().Trim().ToUpper();
                    ep.Remarks = txtRemarks.Text;
                    ep.UserTypeId = int.Parse(cmbusercode.SelectedIndex.ToString());
                    
                    ep.UserCode = cmbusercode.SelectedValue.ToString().Trim().ToUpper();
                    ep.EmailId = txtEmailId.Text;
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        ep.Image = bytes;
                        string Emp = _objbal.AddEmployee(ep);
                        string customer = _objbal.AddEmpDtlstoCustomer(ep);
                        MessageBox.Show("Employee Added Successfully", "Employee information", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetEmpdetails();
                        Clearcontrols();
                        Edit.IsEnabled = true;
                        Changepw.IsEnabled = true;
                        imgPhoto.Source = null;
                        txtFileName.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetEmpdetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _objbal.GetEmpData();
                if (dt.Rows.Count > 0)
                {
                    GridEmployee.ItemsSource = dt.DefaultView;
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
        public void BindUserDetails(ComboBox cmbusercode)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _objbal.GetUserType();
                cmbusercode.ItemsSource = ds.Tables[0].DefaultView;
                cmbusercode.DisplayMemberPath = ds.Tables[0].Columns["Description"].ToString();
                cmbusercode.SelectedValuePath = ds.Tables[0].Columns["UserCode"].ToString();
                cmbusercode.SelectedIndex = 0;
                cmbusercode.Tag = ds.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindRestaurantdtls(ComboBox cmbRestcode)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _objbal.GetRestCode();
                cmbRestcode.ItemsSource = ds.Tables[0].DefaultView;
                cmbRestcode.DisplayMemberPath = ds.Tables[0].Columns["FullName"].ToString();
                cmbRestcode.SelectedValuePath = ds.Tables[0].Columns["RestCode"].ToString();
                cmbRestcode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GridEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Submit.IsEnabled = false;
            Edit.IsEnabled = true;
            Changepw.IsEnabled = true;
            DataRowView dt;
            int ind;
            ind = GridEmployee.SelectedIndex;
            if (GridEmployee.SelectedIndex != -1)
            {
                dt = GridEmployee.Items.GetItemAt(ind) as DataRowView;
                txtFirstName.Text = dt.Row[1].ToString();
                txtLastName.Text = dt.Row[2].ToString();
                cmbactive.Text = dt.Row[7].ToString();
                

                if (dt.Row[11].ToString() == "1")
                { cmbusercode.Text = "Call Center Agent"; }
                else if (dt.Row[11].ToString().Trim().ToUpper() == "2")
                { cmbusercode.Text = "Restaurant Manager"; }
                else if (dt.Row[11].ToString().Trim().ToUpper() == "3")
                { cmbusercode.Text = "Admin"; }
                else if (dt.Row[11].ToString().Trim().ToUpper() == "4")
                { cmbusercode.Text = "Cashier"; }
                else if (dt.Row[11].ToString().Trim().ToUpper() == "6")
                { cmbusercode.Text = "Delivery Boy"; }
                else if (dt.Row[11].ToString().Trim().ToUpper() == "7")
                { cmbusercode.Text = "Cook"; }
                else if (dt.Row[11].ToString().Trim().ToUpper() == null)
                {
                    MessageBox.Show("The UserType does not Exist", "User Type", MessageBoxButton.OK, MessageBoxImage.Error);
                    cmbusercode.Text = "---Select UserType---";
                }

                if (dt.Row[9].ToString().Trim().ToUpper() == "ZZ")
                { cmbrestcode.Text = "All Restaurants"; }
                else if (dt.Row[9].ToString().Trim().ToUpper() == "HN")
                { cmbrestcode.Text = "Himayat Nagar"; }
                else if (dt.Row[9].ToString().Trim().ToUpper() == "BW")
                { cmbrestcode.Text = "Bowenpally"; }
                else if (dt.Row[9].ToString().Trim().ToUpper() == "MD")
                { cmbrestcode.Text = "Madhapur"; }
                else if (dt.Row[9].ToString().Trim().ToUpper() == null)
                {
                    MessageBox.Show("The Restaurant does not Exist", "Restaurants", MessageBoxButton.OK, MessageBoxImage.Error);
                    cmbusercode.Text = "---Select Restaurant---";
                }
                
                txtEmailId.Text = dt.Row[12].ToString();
                txtEmpcod.Text = dt.Row[0].ToString();
                txtEmpPW.Text = dt.Row[8].ToString();
                txtAddress1.Text = dt.Row[3].ToString();
                txtAddress2.Text = dt.Row[4].ToString();
                txtMobile1.Text = dt.Row[5].ToString();
                txtMobile2.Text = dt.Row[6].ToString();
                txtRemarks.Text = dt.Row[10].ToString();
                if (dt.Row["PhotoURL"].ToString() != "" || dt.Row["PhotoURL"].ToString() != string.Empty)
                {

                    string base64 = Convert.ToBase64String((Byte[])(dt.Row["PhotoURL"]));
                    byte[] binaryData = Convert.FromBase64String(base64);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(binaryData);
                    bi.EndInit();
                    imgPhoto.Source = bi;

                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string str;
            try
            {
                if (txtFirstName.Text == "" && txtLastName.Text == "")
                {
                    MessageBox.Show("Please Load the details to edit");
                }
                else if (txtEmailId.Text.Length == 0)
                {
                    MessageBox.Show("Enter an email.");
                    txtEmailId.Focus();
                }
                else if (txtMobile1.Text.Length == 0)
                {
                    MessageBox.Show("Enter the Mobile Number.");
                    txtMobile1.Focus();
                }
                else if (cmbrestcode.Text == "" || cmbrestcode.Text == null)
                { MessageBox.Show("Please select the Restaurant"); cmbrestcode.Focus(); }
                else if (cmbusercode.Text == "" || cmbusercode.Text == null)
                { MessageBox.Show("Please select the UserType"); cmbusercode.Focus(); }
                else if (cmbactive.Text == "" || cmbactive.Text == null)
                { MessageBox.Show("Please select the Availability"); cmbactive.Focus(); }
                else if (cmbusercode.SelectedIndex == 0)
                { MessageBox.Show("Please select the UserType"); cmbusercode.Focus(); }
                else if (cmbrestcode.SelectedIndex == 0)
                { MessageBox.Show("Please select the Restaurant"); cmbrestcode.Focus(); }
                else if (txtMobile2.Text.Length == 0)
                {
                    MessageBox.Show("Enter the Mobile Number.");
                    txtMobile2.Focus();
                }
                else if (txtFileName.Text == "")
                {

                    MessageBox.Show("Please Enter an Image.", "Image", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtFileName.Focus();
                }
                else if (!Regex.IsMatch(txtEmailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Enter a valid email.");
                    txtEmailId.Select(0, txtEmailId.Text.Length);
                    txtEmailId.Focus();
                }
                else if (!Regex.IsMatch(txtMobile1.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Enter a valid Mobile Number.");
                    txtMobile1.Select(0, txtMobile1.Text.Length);
                    txtMobile1.Focus();
                }
                else if (!Regex.IsMatch(txtMobile2.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Enter a valid Mobile Number.");
                    txtMobile2.Select(0, txtMobile2.Text.Length);
                    txtMobile2.Focus();
                }
                else
                {
                   
                    FileStream fs = new FileStream(txtFileName.Text, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    string[] files = fs.Name.Split(new char[] { '\\' });
                    string fileName = files[files.Length - 1];
                    Stream stream = new MemoryStream(imgByteArr);
                    SqlCommand com = new SqlCommand();
                    ep.EmpCode = txtEmpcod.Text;
                    ep.First_Name = txtFirstName.Text;
                    ep.Last_Name = txtLastName.Text;
                    ep.Address1 = txtAddress1.Text;
                    ep.Address2 = txtAddress2.Text;
                    ep.Mobile1 = txtMobile1.Text;
                    ep.Mobile2 = txtMobile2.Text;
                    str = cmbactive.SelectionBoxItem.ToString();
                    ep.Active = Boolean.Parse(str);
                    ep.RestCode = cmbrestcode.SelectedValue.ToString().Trim().ToUpper();
                    ep.Remarks = txtRemarks.Text;
                   
                    ep.UserCode = cmbusercode.SelectedValue.ToString().Trim().ToUpper();
                    ep.EmailId = txtEmailId.Text;
                   
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        ep.Image = bytes;
                        string Emp = _objbal.EditEmployee(ep);
                        MessageBox.Show("Employee updated Successfully", "Employee Details", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetEmpdetails();
                        Clearcontrols();
                        imgPhoto.Source = null;
                        txtFileName.Text = "";
                        Submit.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Changepw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbrestcode.Text == "" && txtEmpcod.Text == "")
                {
                    MessageBox.Show("Please give the inputs to change the password ");
                }
                else if (cmbrestcode.Text == "" || cmbrestcode.Text == null)
                { MessageBox.Show("Please select the Restaurant"); cmbrestcode.Focus(); }
                else if (cmbusercode.Text == "" || cmbusercode.Text == null)
                { MessageBox.Show("Please select the UserType"); cmbusercode.Focus(); }
                else if (cmbusercode.SelectedIndex == 0)
                { MessageBox.Show("Please select the UserType"); cmbusercode.Focus(); }
                else if (cmbrestcode.SelectedIndex == 0)
                { MessageBox.Show("Please select the Restaurant"); cmbrestcode.Focus(); }
                else
                {
                    SqlCommand com = new SqlCommand();
                    ep.EmpCode = txtEmpcod.Text;
                    ep.UserCode = cmbusercode.SelectedValue.ToString().Trim().ToUpper();
                    ep.RestCode = cmbrestcode.SelectedValue.ToString().Trim().ToUpper();

                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to Change the password ?", "Password change", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        string Emp = _objbal.ChangePWforEMP(ep);
                    }
                    GetEmpdetails();
                    Clearcontrols();
                    Submit.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Clearcontrols()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRemarks.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            txtEmpcod.Text = "";
            txtEmpPW.Text = "";
            txtEmailId.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            cmbactive.Text = "";
            cmbrestcode.Text = "";
            cmbusercode.Text = "";
            
        }

        private void charValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtFirstName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.Key)) e.Handled = true;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
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

    }
}
