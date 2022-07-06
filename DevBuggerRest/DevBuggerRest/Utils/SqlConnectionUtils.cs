using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuggerRest.Utils
{
    public static class SqlConnectionUtils
    {
        //public static string con = "Server=.\\SQLEXPRESS;Database=DevBugger;Trusted_Connection=True;";
        //public static string con = "Server=.;Database=DevBugger;Trusted_Connection=True;"; //Dominik login
        public static string con = "Server=tcp:oicar-devbugger.database.windows.net,1433;Initial Catalog=DevBugger;Persist Security Info=False;User ID=oicar;Password=$$$$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //azure
    }
}
