﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.Models
{
    public class Account
    {
        public int IDAccount { get; set; }
        public int AccountLevelID  { get; set; }
        public string Email { get; set; }
        public string Username  { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
    }
}
