using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Deposit_Withdraw
    {
        DAO dao = new DAO();
        public void UpdateDepositDetails(decimal bal, decimal am, int accno)
        {
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateTransfer";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accno", accno);
            cmd.Parameters.AddWithValue("@na", bal);
            cmd.Parameters.AddWithValue("@am", am);

            cmd.ExecuteNonQuery();
            dao.CloseCon();
        }

    }
}
