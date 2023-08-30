using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTests.Models.Users.Register
{
    internal class RegisterUserResponse
    {
        public int id { get; set; }
        public string token { get; set; }
    }
}
