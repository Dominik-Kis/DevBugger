using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DevBuggerRest.Model
{
    [DataContract]
    public class Comment
    {
        [DataMember(Order = 0)]
        public int IDComment { get; set; }

        [DataMember(Order = 1)]
        public int BugReportID { get; set; }

        [DataMember(Order = 2)]
        public int AccountID { get; set; }

        [DataMember(Order = 3)]
        public string Text { get; set; }

        [DataMember(Order = 4)]
        public DateTime Created { get; set; }

        public Comment(int iDComment, int bugReportID, int accountID, string text, DateTime created)
        {
            IDComment = iDComment;
            BugReportID = bugReportID;
            AccountID = accountID;
            Text = text;
            Created = created;
        }

        public Comment()
        {
        }
    }
}
