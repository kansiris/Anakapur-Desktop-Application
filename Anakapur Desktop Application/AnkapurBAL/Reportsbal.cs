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
   public class Reportsbal
    {
        private CoreDAL _objdal = new CoreDAL();
        public DataSet getdailyreports(DateTime rpt)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@specify_date", rpt));
                return _objdal.fngetData("rptGetDailyReportDT", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getweeklyreports(DateTime rptfrom)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@from_date", rptfrom));
                return _objdal.fngetData("rptGetWeeklyReportDT", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getmonthlyreports(DateTime rptfrom)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@from_date", rptfrom));
                return _objdal.fngetData("rptGetMonthlyReportDT", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getdailyreportsexcel(DateTime rpt)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@specify_date", rpt));
                return _objdal.fngetData("rptGetDailyReportDT", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getweeklyreportsexcel(DateTime rptfrom)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@from_date", rptfrom));
                return _objdal.fngetData("rptGetWeeklyReportDT", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getmonthlyreportsexcel(DateTime rptfrom)
        {
            try
            {
                DataSet dt = new DataSet();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@from_date", rptfrom));
                return _objdal.fngetData("rptGetMonthlyReportDT", param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
