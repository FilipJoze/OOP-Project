using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class SearchAccountID
    {
        DAO dao = new DAO();
        SqlDataReader dr;


        public bool SearchAccountNo(string AcNo)
        {
            bool success = false;
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspSearch";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@searchacc",AcNo);

            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();

            success = dr.Read();
            return success;
        }
    }
}
