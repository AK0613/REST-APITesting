﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTests.Models.Users.Login
{
    internal class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
