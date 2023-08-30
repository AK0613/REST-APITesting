using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTests.Models.Users.Register
{
    internal class RegisterUserRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
