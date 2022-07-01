using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace BTL_QLNS.DAL
{
    public class Data
    {
        public SqlConnection getConnect()
        {
            String strConn = @"Data Source=NGOCANH/SQLEXPRESS;Initial Catalog=Quanlynhasu;Integrated Security=True";
            return new SqlConnection(strConn);
        }
        public DataTable getTable(String sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = getConnect();
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public void ExcuteNonQuery(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public String ExcuteScalar(String sql)
        {
            SqlConnection conn = getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            String kq=cmd.ExecuteScalar().ToString();
            conn.Close();
            return kq;
        }
    }
}
