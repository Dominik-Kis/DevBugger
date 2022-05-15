using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DevBuggerRest.Model;

namespace DevBuggerDesktop.DAL
{
    public class BugReportRepository
    {
        public bool AddBugBugReport(BugReport bugReport)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/BugReport/CreateBugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(bugReport);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                line = result;
            }
            if (line.Contains("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateBugReport(BugReport bugReport)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/BugReport/UpdateBugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(bugReport);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                line = result;
            }
            if (line.Contains("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteBugReport(BugReport bugReport)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/BugReport/DeleteBugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(bugReport);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                line = result;
            }
            if (line.Contains("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public BugReport GetBugReport(int idBugReport)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/BugReport/GetBugReport/" + idBugReport);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(idBugReport);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                BugReport responseBugReport = JsonConvert.DeserializeObject<BugReport>(result);

                Console.WriteLine("------------");
                Console.WriteLine(responseBugReport.Title);
                Console.WriteLine("------------");
                return responseBugReport;
            }
        }
        public IList<BugReport> GetBugReports()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/BugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<BugReport> responseBugReports = JsonConvert.DeserializeObject<List<BugReport>>(result);

                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                return responseBugReports;
            }
        }
    }
}
