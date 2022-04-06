using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    class CreateUser
    {
        public string Username { get; set; }
        public string Password { get; set; }



        public CreateUser(string un, string pw)
        {
            Username = un;
            Password = pw;
        }
    }
}
