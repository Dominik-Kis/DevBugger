﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DevBuggerRest.Model
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/DevBuggerRest.Model")]
    public class BugReportImage
    {
        [DataMember(Order = 0)]
        public int IDBugReportImage { get; set; }

        [DataMember(Order = 1)]
        public int BugReportID { get; set; }

        [DataMember(Order = 2)]
        public byte[] Image { get; set; }

    }
}
