using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/DevBuggerRest.Model")]
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

        //public override bool Equals(object obj)
        //{
        //    if (obj is Account && obj != null)
        //    {
        //        Account acc = obj as Account;
        //        return this.IDAccount.Equals(acc.IDAccount);
        //    }
        //    return false;
        //}
    }
}
