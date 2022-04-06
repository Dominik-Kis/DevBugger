using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DevBuggerRest.Model
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public int IDAccount { get; set; }
        [DataMember]
        public int AccountLevelID { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime Created { get; set; }

        public Account(int iDAccount, int accountLevelID, string email, string username, string password, string firstName, string lastName, DateTime created)
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

        public Account(int accountLevelID, string email, string username, string password, string firstName, string lastName, DateTime created)
        {
            AccountLevelID = accountLevelID;
            Email = email;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Created = created;
        }

        public Account()
        {
        }
    }
}
