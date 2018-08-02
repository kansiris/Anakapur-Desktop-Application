using AnkapurDAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnkapurBAL
{
   public class LoginBal
    {
        private CoreDAL _objdal = new CoreDAL();
        //public DataTable getdata()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    return _objdal.fngetdata("Categorytype", null);
        //}
        public DataTable GetLogin(LoginProperties lp)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Password",lp.Password));
            return _objdal.fngetdata("spValidateEmpDetails", param.ToArray());
        }
    }
}
