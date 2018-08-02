using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkapurDAL;
using System.Data;
using System.Data.SqlClient;
namespace AnkapurBAL
{
    public class EmployeeBal
    {
        private CoreDAL _objdal = new CoreDAL();
        public string AddEmployee(EmployeeProperties Epr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@First_Name", Epr.First_Name));
                param.Add(new SqlParameter("@Last_Name", Epr.Last_Name));
                param.Add(new SqlParameter("@Address1", Epr.Address1));
                param.Add(new SqlParameter("@Address2", Epr.Address2));
                param.Add(new SqlParameter("@Mobile1", Epr.Mobile1));
                param.Add(new SqlParameter("@Mobile2", Epr.Mobile2));
                param.Add(new SqlParameter("@Active", Epr.Active));
                param.Add(new SqlParameter("@RestCode", Epr.RestCode));
                param.Add(new SqlParameter("@Remarks", Epr.Remarks));
                param.Add(new SqlParameter("@UserTypeId", Epr.UserTypeId));
                param.Add(new SqlParameter("@PhotoUrl", Epr.Image));
                param.Add(new SqlParameter("@EmailId", Epr.EmailId));
                param.Add(new SqlParameter("@UserCode", Epr.UserCode));
               // param.Add(new SqlParameter("@EmpCode", Epr.EmpCode));
                return _objdal.fnAdddata("AddEmployee", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddEmpDtlstoCustomer(EmployeeProperties Epr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@customerphone", Epr.CustPhoneNumber));
                param.Add(new SqlParameter("@custfname", Epr.CustomerFName));
                param.Add(new SqlParameter("@custlname", Epr.CustomerLName));
                param.Add(new SqlParameter("@billaddress", Epr.Billing_Address));
                param.Add(new SqlParameter("@Delivery_Addresss", Epr.Delivery_Addresss));
                param.Add(new SqlParameter("@custtypeid", Epr.CustomerTypeId));
                return _objdal.fnAdddata("spinsertEmpIntoCustomer", param.ToArray());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetEmpData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetdata("spGetTotEmpdtls", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUserType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spGetUserType", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRestCode()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spgetrest1", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EditEmployee(EmployeeProperties Epr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@First_Name", Epr.First_Name));
                param.Add(new SqlParameter("@Last_Name", Epr.Last_Name));
                param.Add(new SqlParameter("@Address1", Epr.Address1));
                param.Add(new SqlParameter("@Address2", Epr.Address2));
                param.Add(new SqlParameter("@Mobile1", Epr.Mobile1));
                param.Add(new SqlParameter("@Mobile2", Epr.Mobile2));
                param.Add(new SqlParameter("@Active", Epr.Active));
                param.Add(new SqlParameter("@RestCode", Epr.RestCode));
                param.Add(new SqlParameter("@Remarks", Epr.Remarks));
                //param.Add(new SqlParameter("@UserTypeId", Epr.UserTypeId));
                param.Add(new SqlParameter("@PhotoUrl", Epr.Image));
                param.Add(new SqlParameter("@EmailId", Epr.EmailId));
                param.Add(new SqlParameter("@EmpCode", Epr.EmpCode));
                return _objdal.fnAdddata("spEditEmpDetails", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ChangePWforEMP(EmployeeProperties Epr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@RestCode", Epr.RestCode));
                param.Add(new SqlParameter("@UserCode", Epr.UserCode));
                param.Add(new SqlParameter("@EmpCode", Epr.EmpCode));
                return _objdal.fnAdddata("spCreateNewPasswordForEmployee", param.ToArray());
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Get Employee based on Employee Code

        public DataTable GetEmpByEmpCode(EmployeeProperties Emp)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@EmpCode", Emp.EmpCode));
                return _objdal.fngetdata("SP_GetEmployee", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable chkempmo(string mob1)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@Empmob1", mob1));

                return _objdal.fngetdata("spChkEmpMob", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable chkempmo2(string mob2)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@Empmob2", mob2));

                return _objdal.fngetdata("spChkEmpMob2", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable chkempemail(string email)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@email", email));

                return _objdal.fngetdata("spChkEmpemail", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllEmployeesbyRestCode(EmployeeProperties Emp)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@RestCode", Emp.RestCode));
            return _objdal.fngetdata("[getAllEmployeesbyRestCode]", param.ToArray()); //orderStatusByOrderId
        }
    }

}
