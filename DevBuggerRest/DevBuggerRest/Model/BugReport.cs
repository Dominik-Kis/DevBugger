using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DevBuggerRest.Model
{
    [DataContract]
    public class BugReport
    {
        [DataMember(Order = 0)]
        public int IDBugReport { get; set; }
        [DataMember(Order = 1)]
        public int BugCategoryID { get; set; }
        [DataMember(Order = 2)]
        public int GamePageID { get; set; }
        [DataMember(Order = 3)]
        public int AccountID { get; set; }
        [DataMember(Order = 4)]
        public string Title { get; set; }
        [DataMember(Order = 5)]
        public string Description { get; set; }
        [DataMember(Order = 6)]
        public DateTime Created { get; set; }

        public BugReport(int iDBugReport, int bugCategoryID, int gamePageID, int accountID, string title, string description, DateTime created)
        {
            IDBugReport = iDBugReport;
            BugCategoryID = bugCategoryID;
            GamePageID = gamePageID;
            AccountID = accountID;
            Title = title;
            Description = description;
            Created = created;
        }

        public BugReport()
        {
        }
    }
}
