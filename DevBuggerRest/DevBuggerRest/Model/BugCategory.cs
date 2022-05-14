using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DevBuggerRest.Model
{
    [DataContract]
    public class BugCategory
    {
        [DataMember(Order = 0)]
        public int IDCategory { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string Description { get; set; }

        public BugCategory(int iDCategory, string name, string description)
        {
            IDCategory = iDCategory;
            Name = name;
            Description = description;
        }

        public BugCategory()
        {
        }
    }
}
