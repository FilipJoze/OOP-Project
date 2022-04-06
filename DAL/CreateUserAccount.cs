using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CreateUserAccount
    {
        DAO dao = new DAO();

        public void CreateUser(string un, string pw)
        {
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspCreateUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", un);
            cmd.Parameters.AddWithValue("@password", pw);

            cmd.ExecuteNonQuery();
            dao.CloseCon();
        }
    }
}
