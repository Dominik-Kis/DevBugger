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
        public void AddAccount(Account account)
        {

        }
        public void UpdateAccount(Account account)
        {

        }
        public void DeleteAccount(Account account)
        {

        }
        public void UpdateToDummy(Account account)
        {

        }
        public Account GetAccount(int idAccount)
        {
            Account ac = new Account();
            ac.IDAccount = idAccount;

            DataContractSerializer serijalizacija = new DataContractSerializer(typeof(Account));
            MemoryStream podaci = new MemoryStream();
            XmlWriter pisac = XmlWriter.Create(podaci);

            serijalizacija.WriteObject(pisac, ac);
            pisac.Close();

            byte[] podaciZaServis = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(podaci.ToArray()));

            HttpWebRequest zahtjev = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Account/GetAccount/1");
            zahtjev.Method = "POST";
            zahtjev.Accept = "application/xml";
            zahtjev.ContentType = "application/xml";
            Stream data = zahtjev.GetRequestStream();
            data.Write(podaciZaServis, 0, podaciZaServis.Length);
            data.Close();

            HttpWebResponse odgovor = (HttpWebResponse)zahtjev.GetResponse();
            Stream podaciOdgovor = odgovor.GetResponseStream();

            DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(Account));
            Account uspjesnoDodano = (Account)deserijalizacija.ReadObject(podaciOdgovor);
            Console.WriteLine("------------");
            Console.WriteLine(uspjesnoDodano.ToString());
            Console.WriteLine("------------");
            return uspjesnoDodano;
        }
       /* public IList<Account> GetAccounts()
        {

        }
        public Account LoginAccount()
        {
       *
        }*/
    }
}
