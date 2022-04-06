using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoginCheck
    {
        DAO dao = new DAO();
        SqlDataReader dr;

        public bool CheckUserLogin(string un, string pw)
        {
            bool readSuccess = false;
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspCheckUserLogin";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userLogin", un);
            cmd.Parameters.AddWithValue("@passLogin", pw);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                readSuccess = true;
            }
            else
            {
                readSuccess = false;
            }

            dao.CloseCon();

            return readSuccess;
        }
    }
}
