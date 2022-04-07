using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class CreateBankAccount
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
        public int InitialBal { get; set; }
        public decimal Amount { get; set; }
        public decimal OverdraftLimit { get; set; }

        public CreateBankAccount(string fn, string sn, string em, string po, string add1, string add2, string cty, string cy, string at, int anum, int sc, int ib, decimal am, decimal ol)
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
            Amount = am;
            OverdraftLimit = ol;
        }

    }
}
