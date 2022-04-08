using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ViewTransactions
    {
        DAO dao = new DAO();
        SqlDataReader dr;


        public bool FetchTransactions(string transactionNo)
        {
            bool success = false;
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspFetchTransactions";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@transactionId", transactionNo);

            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();

            success = dr.Read();
            return success;
        }
    }
}
