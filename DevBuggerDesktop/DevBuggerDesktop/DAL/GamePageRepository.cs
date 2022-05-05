using DevBuggerDesktop.Models;
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
    public class GamePageRepository
    {
        public bool AddGamePage(GamePage gamePage)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/GamePage/CreateGamePage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(gamePage);
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
        public bool UpdateGamePage(GamePage gamePage)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/GamePage/UpdateGamePage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(gamePage);
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
        public bool DeleteGamePage(GamePage gamePage)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/GamePage/DeleteGamePage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(gamePage);
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
        public GamePage GetGamePage(int idGamePage)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/GamePage/GetGamePage/" + idGamePage);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(idGamePage);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                GamePage responseGamePage = JsonConvert.DeserializeObject<GamePage>(result);

                Console.WriteLine("------------");
                Console.WriteLine(responseGamePage.Title);
                Console.WriteLine("------------");
                return responseGamePage;
            }
        }
        public IList<GamePage> GetGamePages()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/GamePage");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<GamePage> responseGamePages = JsonConvert.DeserializeObject<List<GamePage>>(result);

                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                return responseGamePages;
            }
        }
        public Account LoginAccount(Account account)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/LoginAccount/1");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(account);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Account responseAccount = JsonConvert.DeserializeObject<Account>(result);

                Console.WriteLine("------------");
                Console.WriteLine(responseAccount.Email);
                Console.WriteLine("------------");
                return responseAccount;
            }
        }
    }
}
