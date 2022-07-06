﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DevBuggerDesktop.Models;

namespace DevBuggerDesktop.DAL
{
    public class BugReportRepository
    {
        private const string LINK = "https://devbuggerrest2022.azurewebsites.net/";
        public bool AddBugBugReport(BugReport bugReport)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/CreateBugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugReport));
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/UpdateBugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugReport));
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/DeleteBugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugReport));
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/GetBugReport/" + idBugReport);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                BugReport responseBugReport = JsonConvert.DeserializeObject<BugReport>(result);

                //Console.WriteLine("------------");
                //Console.WriteLine(responseBugReport.Title);
                //Console.WriteLine("------------");
                return responseBugReport;
            }
        }
        public IList<BugReport> GetBugReports()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<BugReport> responseBugReports = JsonConvert.DeserializeObject<List<BugReport>>(result);

                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugReports;
            }
        }

        public IList<BugReport> GetBugReportsByAccountID(int idAccount)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/GetBugReportsByAccountID/" + idAccount);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                List<BugReport> responseBugReports = JsonConvert.DeserializeObject<List<BugReport>>(result);
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugReports;
            }
        }


        public IList<BugReport> GetBugReportsByGamePageID(int idGamePage)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/GetBugReportsByGamePageID/" + idGamePage);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                List<BugReport> responseBugReports = JsonConvert.DeserializeObject<List<BugReport>>(result);
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugReports;
            }
        }

        public IList<BugReport> GetBugReportsByBugCategoryID(int idBugCategory)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(LINK + "api/BugReport/GetBugReportsByBugCategoryID/" + idBugCategory);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                List<BugReport> responseBugReports = JsonConvert.DeserializeObject<List<BugReport>>(result);
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugReports;
            }
        }

    }
}
