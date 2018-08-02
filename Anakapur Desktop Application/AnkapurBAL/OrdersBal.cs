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
   public class OrdersBal
    {
        private CoreDAL _objdal = new CoreDAL();
        public DataSet getOrders(string RestCode)
        {
            //string RestCode
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@RestCode", RestCode));
                return _objdal.fngetData("spGET_ORDERS1",param.ToArray());
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRestName()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spGET_RESTNAME", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EditOrders(OrderProperties opr)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@OrderId", opr.OrderId));
                param.Add(new SqlParameter("@statusid", opr.StatusId));
                param.Add(new SqlParameter("@empcode", opr.EmpCode));
                param.Add(new SqlParameter("@Tip", opr.Tip));
                param.Add(new SqlParameter("@Discount", opr.Discount));
                param.Add(new SqlParameter("@AmtPaid", opr.AmountPaid));
                param.Add(new SqlParameter("@Remarks", opr.Remarks));
                return _objdal.fnAdddata("insertOrderTrackingDetails1", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetOrderDtls(string OrderId)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@OrderId", OrderId));
                return _objdal.fngetData("spGetOrderDtls", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Getchanneldtls()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                return _objdal.fngetData("spgetchannels", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getcomporderdtls(string OrderId, string discount, decimal amountpaid, string Remarks)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@orderid", OrderId));
                param.Add(new SqlParameter("@discount", discount));
                param.Add(new SqlParameter("@Amountpaid ", amountpaid));
                param.Add(new SqlParameter("@Remarks", Remarks));
                return _objdal.fnAdddata("updatecompletedorder", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable chkorderid(string orderid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@orderid", orderid));

                return _objdal.fngetdata("checkorderid", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
