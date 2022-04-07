using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UploadAccount
    {
        DAO dao = new DAO();


        //public Customer(string fn, string sn, string email, string ph, string add1, string add2,
        //    string city, string cy, string AccType, int AccNo, int scode, decimal iBal, decimal odraft)
       public void UploadBankAccount(string fn, string sn, string email, string ph, string add1, string add2, string city, string cy, string AccType, int scode, int iBal, decimal odraft)
        {

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspCreateAccount";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fn", fn);
            cmd.Parameters.AddWithValue("@sn", sn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@ph", ph);
            cmd.Parameters.AddWithValue("@add1", add1);
            cmd.Parameters.AddWithValue("@add2", add2);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@cy", cy);
            cmd.Parameters.AddWithValue("@AccType", AccType);
            cmd.Parameters.AddWithValue("@SCode", scode);
            cmd.Parameters.AddWithValue("@IBal", iBal);
            //cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@ODraft", odraft);

            cmd.ExecuteNonQuery();
            dao.CloseCon();
            //Firstname = fn;
            //Surname = sn;
            //Email = em;
            //PhoneNo = po;
            //Address1 = add1;
            //Address2 = add2;
            //City = cty;
            //County = cy;
            //AccountNo = anum;
            //SortCode = sc;
            //InitialBal = ib;
            //OverdraftLimit = ol;
        }
    }
}
