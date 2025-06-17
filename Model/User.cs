using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
            public int UserId { get; set; } // assumed as the primary key because has the name of the class + id in it
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }

        }
    }
