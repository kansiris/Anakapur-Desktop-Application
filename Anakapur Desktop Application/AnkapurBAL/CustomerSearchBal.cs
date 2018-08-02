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
   public class CustomerSearchBal
    {
        private CoreDAL _objdal = new CoreDAL();

        //public DataTable getCustomer()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    return _objdal.SearchData("searchCustomerByPhone", null);
        //}
        public DataTable getCustomer(CustomerSearchProperties csp)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@customerdata", csp.CustomerFName));            
            return _objdal.SearchData("searchBycustPhoneAndName", param.ToArray());
        }
       public DataTable getCustData(CustomerSearchProperties csp)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@customerphone", csp.CustPhoneNumber));
            return _objdal.SearchData("searchCustomerByPhone", param.ToArray());
        }
        public string AddNewCustomer(CustomerSearchProperties csp)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@custfname", csp.CustomerFName));
                param.Add(new SqlParameter("@custlname", csp.CustomerLName));
                param.Add(new SqlParameter("@customerphone", csp.CustPhoneNumber));
                param.Add(new SqlParameter("@billaddress", csp.Billing_Address));
                param.Add(new SqlParameter("@delivaddress", csp.Delivery_Addresss));
                param.Add(new SqlParameter("@landmark", csp.Land_Mark));
                param.Add(new SqlParameter("@mobile1", csp.Mobile1));
                param.Add(new SqlParameter("@mobile2", csp.Mobile2));                
                param.Add(new SqlParameter("@custtypeid", csp.CustomerTypeId));
                param.Add(new SqlParameter("@delivloclati", csp.DeliveryLocationLatitude));
                param.Add(new SqlParameter("@delivloclong", csp.DeliveryLocationLongitude));
                return _objdal.fnAdddata("insertNewCustomer", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string EditCustomer(CustomerSearchProperties csp)
        {
            try
            {
                //  cmd.Parameters.Add(new SqlParameter{SqlValue=username ?? (object)DBNull.Value,ParameterName="usuario" }  );

                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@custfname", csp.CustomerFName));
                param.Add(new SqlParameter("@custlname", csp.CustomerLName));
                param.Add(new SqlParameter("@customerphone", csp.CustPhoneNumber));
                param.Add(new SqlParameter("@billaddress", csp.Billing_Address));
                param.Add(new SqlParameter("@delivaddress", csp.Delivery_Addresss));
                param.Add(new SqlParameter("@landmark", csp.Land_Mark));
                 param.Add(new SqlParameter("@mobile1", csp.Mobile1) );
              //  param.Add(new SqlParameter(SqlValue

                  param.Add(new SqlParameter("@mobile2", csp.Mobile2));
                param.Add(new SqlParameter("@custtypeid", csp.CustomerTypeId));
                param.Add(new SqlParameter("@delivloclati", csp.DeliveryLocationLatitude));
                param.Add(new SqlParameter("@delivloclong", csp.DeliveryLocationLongitude));
                return _objdal.fnAdddata("updateCustomer", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
