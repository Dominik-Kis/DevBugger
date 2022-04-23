﻿using DevBuggerDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DevBuggerDesktop.DAL
{
    public class AccountRepository
    {
        public bool AddAccount(Account account)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/AddAccount/1");
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
                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                line = result;
            }
            if(line.Contains("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateAccount(Account account)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/UpdateAccount/1");
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
        public bool DeleteAccount(Account account)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/DeleteAccount/1");
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
        public bool UpdateToDummy(Account account)
        {
            string line;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/UpdateToDummy/1");
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
        public Account GetAccount(int idAccount)
        {
            /*DataContractSerializer serializer = new DataContractSerializer(typeof(int));
            MemoryStream data = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(data);

            serializer.WriteObject(writer, idAccount);
            writer.Close();

            byte[] podaciZaServis = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/GetAccount/1");
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(podaciZaServis, 0, podaciZaServis.Length);
            requestData.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(Account));
            Account account = (Account)deserijalizacija.ReadObject(responseData);
            Console.WriteLine("------------");
            Console.WriteLine(account.Email);
            Console.WriteLine("------------");
            return account;*/
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/GetAccount/1");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(idAccount);
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
        public IList<Account> GetAccounts()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<Account> responseAccounts = JsonConvert.DeserializeObject<List<Account>>(result);

                Console.WriteLine("------------");
                Console.WriteLine(result);
                Console.WriteLine("------------");
                return responseAccounts;
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
