using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppOicar.Models
{
    public class User
    {
        public int IDAccount { get; set; }
        public int AccountLevelID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }

        public User(int accountLevelID, string email, string username, string password, string firstName, string lastName, DateTime created)
        {
            AccountLevelID = accountLevelID;
            Email = email;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Created = created;
        }

        public User(int iDAccount, int accountLevelID, string email, string username, string password, string firstName, string lastName, DateTime created)
        {
            IDAccount = iDAccount;
            AccountLevelID = accountLevelID;
            Email = email;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Created = created;
        }

        public User()
        {
        }
    }
}