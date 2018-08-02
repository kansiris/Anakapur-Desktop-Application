using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AnkapurDAL
{
   public class CoreDAL
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter adaptr = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        //To get data from DB
        public DataTable fngetdata(string sqlprocedure, SqlParameter[] parameters)
        {
            string str = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlprocedure;
            cmd.Connection = con;
            if (parameters != null)
            {
                foreach (SqlParameter _objparam in parameters)
                {
                    cmd.Parameters.Add(_objparam);
                }
            }
            adaptr = new SqlDataAdapter(cmd);
            con.Close();
            DataTable dt = new DataTable("cust");
            adaptr.Fill(dt);
            return dt;
        }

        // To Add,Update and Delete data from DB
        public string fnAdddata(string sqlprocedure, SqlParameter[] parameters)
        {
            string str = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlprocedure;
            cmd.Connection = con;
            //con.Open();
            foreach (SqlParameter _objparam in parameters)
            {
                if (_objparam.Value == null)
                {
                    _objparam.Value = DBNull.Value;
                }
                cmd.Parameters.Add(_objparam);
            }
            //con.Close();
            cmd.ExecuteNonQuery();    
            return null;
   
        }
        public  string constring()
        {
            string str = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            
            return str;

        }
        public DataSet fngetData(string sqlprocedure, SqlParameter[] parameters)
        {
            string str = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlprocedure;
            cmd.Connection = con;
            if (parameters != null)
            {
                foreach (SqlParameter _objparam in parameters)
                {
                    cmd.Parameters.Add(_objparam);
                }
            }
            adaptr = new SqlDataAdapter(cmd);
            con.Close();
           DataSet ds = new DataSet("cust");
            adaptr.Fill(ds);
            return ds;
        }

        public DataTable SearchData(string sqlprocedure, SqlParameter[] parameters)
        {
            string str = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlprocedure;
            cmd.Connection = con;
            if (parameters != null)
            {
                foreach (SqlParameter _objparam in parameters)
                {
                    cmd.Parameters.Add(_objparam);
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Close();
            DataTable dt = new DataTable("Result");
            sda.Fill(dt);
            return dt;



           
        }
        //function to fetch maxid from table
        public DataTable fngetMaxId(string query, SqlParameter[] parameters)
        {
            string str = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(str, con);
            cmd.CommandText = query;
            cmd.Connection = con;
            if (parameters != null)
            {
                foreach (SqlParameter _objparam in parameters)
                {
                    cmd.Parameters.Add(_objparam);
                }
            }
            adaptr = new SqlDataAdapter(cmd);
            con.Close();
            DataTable ds = new DataTable("cust");
            adaptr.Fill(ds);
            return ds;
        }


    }
}
