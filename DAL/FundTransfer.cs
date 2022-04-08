using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{//git hub check
    public class FundTransfer
    {
        DAO dao = new DAO();

        public void ViewTransactions(int SAccNo, int RAccNo, int RSCode, decimal Amount, int RNo, string TransferDate)
        {
            SqlCommand cmd = dao.OpenCon().CreateCommand();

            cmd.CommandText = "uspTransferFunds";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SAccNo", SAccNo);
            cmd.Parameters.AddWithValue("@RAccNo", RAccNo);
            cmd.Parameters.AddWithValue("@RSCode", RSCode);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@RNo", RNo);
            cmd.Parameters.AddWithValue("@TDate", TransferDate);

            cmd.ExecuteNonQuery();
            dao.CloseCon();

        }

        public void UpdateTransferDetails(decimal bal, decimal am, int accno)
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
