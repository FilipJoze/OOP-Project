using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class CreateAccount
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string AccountType { get; set; }
        public int AccountNo { get; set; }
        public int SortCode { get; set; }
        public decimal InitialBal { get; set; }
        public decimal OverdraftLimit { get; set; }

        public CreateAccount(string fn, string sn, string em, string po, string add1, string add2, string cty, string cy, string at, int anum, int sc, decimal ib, decimal ol)
        {
            Firstname = fn;
            Surname = sn;
            Email = em;
            PhoneNo = po;
            Address1 = add1;
            Address2 = add2;
            City = cty;
            County = cy;
            AccountType = at;
            AccountNo = anum;
            SortCode = sc;
            InitialBal = ib;
            OverdraftLimit = ol;
        }

    }
}
