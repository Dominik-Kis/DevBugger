﻿using DevBuggerRest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.DAL
{
    public class BugCategoryRepository
    {
        public bool AddBugCategory(BugCategory bugCategory)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugCategory/CreateBugCategory");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugCategory));
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
        public bool UpdateBugCategory(BugCategory bugCategory)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/GamePage/UpdateGamePage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugCategory));
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
        public bool DeleteBugCategory(BugCategory bugCategory)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugCategory/DeleteBugCategory");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugCategory));
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
        public BugCategory GetBugCategory(int idBugCategory)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugCategory/GetBugCategory/" + idBugCategory);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                BugCategory responseBugCategory = JsonConvert.DeserializeObject<BugCategory>(result);

                //Console.WriteLine("------------");
                //Console.WriteLine(responseBugCategory.Name);
                //Console.WriteLine("------------");
                return responseBugCategory;
            }
        }
        public IList<BugCategory> GetBugCategories()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugCategory");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<BugCategory> responseBugCategories = JsonConvert.DeserializeObject<List<BugCategory>>(result);

                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugCategories;
            }
        }
    }
}
