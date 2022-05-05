using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.Models
{
    [DataContract]
    public class GamePage
    {
        [DataMember(Order = 0)]
        public int IDGamePage { get; set; }
        [DataMember(Order = 1)]
        public int AccountID { get; set; }
        [DataMember(Order = 2)]
        public string Title { get; set; }
        [DataMember(Order = 3)]
        public string Description { get; set; }
        [DataMember(Order = 4)]
        public DateTime Created { get; set; }

        public GamePage(int iDGamePage, int accountID, string title, string description, DateTime created)
        {
            IDGamePage = iDGamePage;
            AccountID = accountID;
            Title = title;
            Description = description;
            Created = created;
        }

        public GamePage()
        {
        }
    }
}
