using AnkapurBAL;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Anakapur
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {

        private EmployeeBal _objbal = new EmployeeBal();
        EmployeeProperties emp = new EmployeeProperties();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string fname;
        string lname;
        DataTable dt = new DataTable();
        public Profile()
        {
            InitializeComponent();
            GetProfile();
        }

        public void GetProfile()
        {

            emp.EmpCode = Application.Current.Properties["EmpCode"].ToString();
                //"CA107";
            dt = _objbal.GetEmpByEmpCode(emp);
            txtMobile1.Text = dt.Rows[0]["Mobile1"].ToString();
            txtMobile2.Text = dt.Rows[0]["Mobile2"].ToString();
              fname =dt.Rows[0]["First_Name"].ToString();
            lname = dt.Rows[0]["Last_Name"].ToString();
            //  lblFirstName.Content = dt.Rows[0]["First_Name"].ToString();
            //  lblLastName.Content = dt.Rows[0]["Last_Name"].ToString();
            txtName.Text = dt.Rows[0]["First_Name"].ToString() + " " + dt.Rows[0]["Last_Name"].ToString();
            txtEmail.Text = dt.Rows[0]["EmailId"].ToString();
            txtAddress1.Text = dt.Rows[0]["Address1"].ToString();
            txtAddress2.Text = dt.Rows[0]["Address2"].ToString();
            if (dt.Rows[0]["PhotoURL"].ToString() != "" || dt.Rows[0]["PhotoURL"].ToString() != string.Empty)
            {

                string base64 = Convert.ToBase64String((Byte[])(dt.Rows[0]["PhotoURL"]));
                byte[] binaryData = Convert.FromBase64String(base64);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();
                imgPhoto.Source = bi;
            }

        }

        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            emp.First_Name = fname;
            emp.Last_Name = lname;
            emp.Remarks = "";
            emp.Address1 = txtAddress1.Text;
            emp.Address2 = txtAddress2.Text;
            emp.Mobile1 = txtMobile1.Text;
            emp.Mobile2 = txtMobile2.Text;
            emp.EmailId = txtEmail.Text;
            emp.Flag = 1;

            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Enter an email.");
                txtEmail.Focus();
            }
            else if (txtFileName.Text == "")
            {
                MessageBox.Show("Enter an Image");
                txtFileName.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email.");
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {

                //Initialize a file stream to read the image file
                FileStream fs = new FileStream(txtFileName.Text, FileMode.Open, FileAccess.Read);
                byte[] imgByteArr = new byte[fs.Length];
                string[] files = fs.Name.Split(new char[] { '\\' });
                string fileName = files[files.Length - 1];
                Stream stream = new MemoryStream(imgByteArr);
                emp.RestCode = "HN";
                DataTable dt = _objbal.GetAllEmployeesbyRestCode(emp);
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    emp.Image = bytes;
                    string Result = _objbal.EditEmployee(emp);
                    MessageBox.Show("Updated successfully");
                    GetProfile();
                }

            }

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
        private void charValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
