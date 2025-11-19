using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core
{
    public class User
    {
        // Declaration of the user properties.
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public int FailedLoginAttempts { get; set; }
    }
}
