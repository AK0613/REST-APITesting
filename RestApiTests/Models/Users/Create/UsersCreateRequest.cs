using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTests.Models.Users.Create
{
    internal class UsersCreateRequest
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}
