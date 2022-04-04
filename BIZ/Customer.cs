using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class Customer
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address_1 { get; set; }

        public string Address_2 { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Acc_type { get; set; }

        public int Acc_No { get; set; }

        public int SortCode { get; set; }

        public decimal Initial_balance { get; set; }

        public decimal overdraft { get; set; }


        public Customer(string fn, string sn, string email, string ph, string add1, string add2,
            string city, string cy, string AccType, int AccNo, int scode, decimal iBal, decimal odraft)
        {
            Firstname = fn;
            Surname = sn;
            Email = email;
            Phone = ph;
            Address_1 = add1;
            Address_2 = add2;
            City = city;
            County = cy;
            Acc_type = AccType;
            Acc_No = AccNo;
            SortCode = scode;
            Initial_balance = iBal;
            overdraft = odraft;

        }


    }
}
