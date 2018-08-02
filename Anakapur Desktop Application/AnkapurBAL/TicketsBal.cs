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
   public class TicketsBal
    {
        private CoreDAL _objdal = new CoreDAL();
        public DataTable getrestaurants()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetdata("[spGetRestCode]", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getorddata(string Ppr)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@restcode", Ppr));
                return _objdal.fngetData("getOrdersForTicket", param.ToArray());
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
                return _objdal.fngetData("spGetRestCodefortickets", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
