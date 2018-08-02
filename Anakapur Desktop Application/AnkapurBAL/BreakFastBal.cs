using AnkapurDAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnkapurBAL
{
    public class BreakFastBal
    {
        private CoreDAL _objdal = new CoreDAL();
        public DataTable getdata()
        {
            SqlCommand cmd = new SqlCommand();
            return _objdal.fngetdata("Categorytype",null);
        }
        public DataTable GetBreakFast(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Categorytype", bfr.CategoryType));
            return _objdal.fngetdata("getMenuByCategory", param.ToArray());
        }
        public DataTable GetOrders(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@restcode", bfr.RestCode));
            return _objdal.fngetdata("getOrdersForTicket2", param.ToArray()); //orderStatusByOrderId
        }
        //public DataTable GetOrders(BreakFastProperties bfr)
        //{
        //    DataTable dt = new DataTable();
        //    List<SqlParameter> param = new List<SqlParameter>();
        //    param.Add(new SqlParameter("@flag",bfr.flag));
        //    param.Add(new SqlParameter("@orderId", bfr.OrderId));
        //    return _objdal.fngetdata("[SP_Tickets]", param.ToArray()); //orderStatusByOrderId
        //}
        public DataTable GetOrdersDetails(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@OrderId", bfr.OrderId));
            return _objdal.fngetdata("spGetOrderDtls", param.ToArray()); //orderStatusByOrderId
        }
        //New method for mobileappupdate
        public DataTable getordertransactiondtls(string orderid)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@OrderId", orderid));
            return _objdal.fngetdata("insertOrderTrackingDetailsforapp", param.ToArray());
        }
        //
        public string UpdateTickets(BreakFastProperties b)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@OrderId", b.OrderId));
            param.Add(new SqlParameter("@statusid", b.StatusId));
            param.Add(new SqlParameter("@empcode", b.EmpCode));
           
            param.Add(new SqlParameter("@AmtPaid", b.totalamount));
            return _objdal.fnAdddata("[insertOrderTrackingDetailsforpaidtrans]", param.ToArray()); //orderStatusByOrderId
        }

        public DataTable GetAllEmployeesbyRestCode(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@RestCode", bfr.RestCode));
            return _objdal.fngetdata("[getAllEmployeesbyRestCode]", param.ToArray()); //orderStatusByOrderId
        }

        //public DataTable getInDrivers(BreakFastProperties bfr)
        //{
        //    DataTable dt = new DataTable();
        //    List<SqlParameter> param = new List<SqlParameter>();
        //    param.Add(new SqlParameter("@flag", bfr.flag));
        //    param.Add(new SqlParameter("@orderId", bfr.OrderId));
        //    return _objdal.fngetdata("[SP_Tickets]", param.ToArray()); //AvailableDrivers
        //}

        public DataTable getOrderDetailsByStatus(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            //param.Add(new SqlParameter("@flag", bfr.flag));
            param.Add(new SqlParameter("@orderId", bfr.OrderId));
            return _objdal.fngetdata("[spGetOrderDtls]", param.ToArray()); //OrdersDetailsByStatusId
        }
        public DataTable getOrdersByStatus(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@flag", bfr.flag));
            param.Add(new SqlParameter("@orderId", bfr.OrderId));
            return _objdal.fngetdata("[SP_Tickets]", param.ToArray()); //OrdersByStatusId
        }
        public DataTable getInDrivers(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            //  param.Add(new SqlParameter("@flag", bfr.flag));
            //param.Add(new SqlParameter("@restcode", bfr.RestCode));
            return _objdal.fngetdata("[getNumberOfOrderstoDelivBoy]", param.ToArray()); //AvailableDrivers
        }
        public DataTable getDeliveryBoyOrders(BreakFastProperties bfr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            //param.Add(new SqlParameter("@flag", bfr.flag));
           // param.Add(new SqlParameter("@restcode", bfr.RestCode));
            param.Add(new SqlParameter("@deliverboy", bfr.EmpCode));
            return _objdal.fngetdata("[showOrderDetailsOfDelivBoy]", param.ToArray()); //OrdersDetailsByStatusId
        }
        public string updatedelboys(BreakFastProperties b)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@orderid", b.OrderId));
            param.Add(new SqlParameter("@deliveryBoy", b.deliveryboy));
            return _objdal.fnAdddata("[updateDeliverBoy]", param.ToArray()); //update deliveryboys
        }
    }
}
