using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{// checking testing everything
    public class UpdateCus
    {

        DAO dao = new DAO();

        public void UpdateCustomer(string email, string ph, string add1, string add2, string city, string cy, int acc_no)
        {
            SqlCommand cmd = dao.OpenCon().CreateCommand();

            cmd.CommandText = "uspUpdateAccount";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@ph", ph);
            cmd.Parameters.AddWithValue("@add1", add1);
            cmd.Parameters.AddWithValue("@add2", add2);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@cy", cy);
            cmd.Parameters.AddWithValue("@AccNo", acc_no);

            cmd.ExecuteNonQuery();
            dao.CloseCon();
        }
    }
}
