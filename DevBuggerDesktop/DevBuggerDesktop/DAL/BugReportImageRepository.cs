using DevBuggerRest.Model;
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
    public class BugReportImageRepository
    {
        public bool AddBugBugReportImage(BugReportImage bugReportImage)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugReportImage/CreateBugReportImage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugReportImage));
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
        public bool UpdateBugReportImage(BugReportImage bugReportImage)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugReportImage/UpdateBugReportImage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugReportImage));
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
        public bool DeleteBugReportImage(BugReportImage bugReportImage)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugReportImage/DeleteBugReportImage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(bugReportImage));
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
        public BugReportImage GetBugReportImage(int idBugReportImage)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugReportImage/GetBugReportImage/" + idBugReportImage);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                BugReportImage responseBugReportImage = JsonConvert.DeserializeObject<BugReportImage>(result);

                //Console.WriteLine("------------");
                //Console.WriteLine(responseBugReportImage.IDBugReportImage);
                //Console.WriteLine("------------");
                return responseBugReportImage;
            }
        }
        public IList<BugReportImage> GetBugCategories()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugReportImage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<BugReportImage> responseBugReportImages = JsonConvert.DeserializeObject<List<BugReportImage>>(result);

                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugReportImages;
            }
        }

        public IList<BugReportImage> GetBugReportImagesByBugReportID(int idBugReport)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RepoFactory.getLink() + "/api/BugReport/GetBugReportImagesByBugReportID/" + idBugReport);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                List<BugReportImage> responseBugReportImages = JsonConvert.DeserializeObject<List<BugReportImage>>(result);
                //Console.WriteLine("------------");
                //Console.WriteLine(result);
                //Console.WriteLine("------------");
                return responseBugReportImages;
            }
        }
    }
}
