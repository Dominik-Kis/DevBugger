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
        [DataMember(Order = 0)]
        public int IDAccount { get; set; }

        [DataMember(Order = 1)]
        public int AccountLevelID { get; set; }

        [DataMember(Order = 2)]
        public string Email { get; set; }

        [DataMember(Order = 3)]
        public string Username { get; set; }

        [DataMember(Order = 4)]
        public string Password { get; set; }

        [DataMember(Order = 5)]
        public string FirstName { get; set; }

        [DataMember(Order = 6)]
        public string LastName { get; set; }

        [DataMember(Order = 7)]
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

        public override bool Equals(object obj)
        {
            return obj is Account account &&
                   IDAccount == account.IDAccount &&
                   AccountLevelID == account.AccountLevelID &&
                   Email == account.Email &&
                   Username == account.Username &&
                   Password == account.Password &&
                   FirstName == account.FirstName &&
                   LastName == account.LastName;
        }
    }
}
