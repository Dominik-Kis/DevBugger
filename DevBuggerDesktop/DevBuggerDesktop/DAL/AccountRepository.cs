using DevBuggerDesktop.Models;
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
            DataContractSerializer serializer = new DataContractSerializer(typeof(Account));
            MemoryStream data = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(data);

            serializer.WriteObject(writer, account);
            writer.Close();

            byte[] podaciZaServis = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/CreateAccount/1");
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(podaciZaServis, 0, podaciZaServis.Length);
            requestData.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(bool));
            bool added = (bool)deserijalizacija.ReadObject(responseData);
            return added;
        }
        public bool UpdateAccount(Account account)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Account));
            MemoryStream data = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(data);

            serializer.WriteObject(writer, account);
            writer.Close();

            byte[] podaciZaServis = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/UpdateAccount/1");
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(podaciZaServis, 0, podaciZaServis.Length);
            requestData.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(bool));
            bool added = (bool)deserijalizacija.ReadObject(responseData);
            return added;
        }
        /*public void DeleteAccount(Account account)
        {

        }*/
        public bool UpdateToDummy(Account account)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Account));
            MemoryStream data = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(data);

            serializer.WriteObject(writer, account);
            writer.Close();

            byte[] podaciZaServis = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/UpdateToDummy/1");
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(podaciZaServis, 0, podaciZaServis.Length);
            requestData.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(bool));
            bool added = (bool)deserijalizacija.ReadObject(responseData);
            return added;
        }
        public Account GetAccount(int idAccount)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(int));
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
            return account;
        }
        public IList<Account> GetAccounts()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/GetAccount/1");
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(List<Account>));
            List<Account> accounts = (List<Account>)deserijalizacija.ReadObject(responseData);
            Console.WriteLine("------------");
            foreach (var ac in accounts)
            {
                Console.WriteLine(ac.Email);
            }
            Console.WriteLine("------------");
            return accounts;
        }
        public Account LoginAccount(Account account)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Account));
            MemoryStream data = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(data);

            serializer.WriteObject(writer, account);
            writer.Close();

            byte[] podaciZaServis = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/LoginAccount/1");
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(podaciZaServis, 0, podaciZaServis.Length);
            requestData.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(Account));
            Account loginAccount = (Account)deserijalizacija.ReadObject(responseData);
            Console.WriteLine("------------");
            Console.WriteLine(loginAccount.Email);
            Console.WriteLine("------------");
            return loginAccount;
        }
    }
}
