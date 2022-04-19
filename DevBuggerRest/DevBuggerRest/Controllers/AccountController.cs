using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBuggerRest.Model;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace DevBuggerRest.Controllers
{


    //http://localhost:5000/api/Account
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //napravi sve konstantne
        private string con = "Server=.\\SQLEXPRESS;Database=DevBugger;Trusted_Connection=True;";
        private const string ID_ACCOUNT = "IDAccount";
        private const string DB_ID_ACCOUNT = "@IDAccount";
        private const string EMAIL = "Email";
        private const string DB_EMAIL = "@Email";
        private const string USERNAME = "Username";
        private const string DB_USERNAME = "@Username";
        private const string PASSWORD = "Password";
        private const string DB_PASSWORD = "@Password";
        private const string FIRSTNAME = "Firstname";
        private const string DB_FIRSTNAME = "@Firstname";
        private const string LASTNAME = "Lastname";
        private const string DB_LASTNAME = "@Lastname";
        private const string ACCOUNT_LEVEL_ID = "AccountLevelID";
        private const string DB_ACCOUNT_LEVEL_ID = "@AccountLevelID";
        private const string CREATED = "Created";

        [HttpGet]
        public List<Account> GetAccounts()
        {

            //var con = ConfigurationManager.ConnectionStrings["MasterDatabase"].ToString();

            List<Account> accounts = new List<Account>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                using (var command = new SqlCommand("selectAccounts", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Account acc = new Account();
                            acc.IDAccount = int.Parse(oReader[ID_ACCOUNT].ToString());
                            acc.AccountLevelID = int.Parse(oReader[ACCOUNT_LEVEL_ID].ToString());
                            acc.Email = oReader[EMAIL].ToString();
                            acc.Username = oReader[USERNAME].ToString();
                            acc.Password = oReader[PASSWORD].ToString();
                            acc.FirstName = oReader[FIRSTNAME].ToString();
                            acc.LastName = oReader[LASTNAME].ToString();
                            acc.Created = DateTime.Parse(oReader[CREATED].ToString());
                            accounts.Add(acc);

                        }

                        myConnection.Close();
                    }
                }
            }
            return accounts;
        }

        //http://localhost:52999/api/Account/GetAccount/1
        [Route("[action]/{id}")]
        [HttpPost]
        public Account GetAccount(Account ac)
        {
            Account acc = new Account();
            Console.WriteLine("ppppppppppp");
            Console.WriteLine(ac.IDAccount);
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                var command = new SqlCommand("selectAccount", myConnection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(ID_ACCOUNT, SqlDbType.Int));
                command.Parameters[ID_ACCOUNT].Value = ac.IDAccount;

                myConnection.Open();
                using (SqlDataReader oReader = command.ExecuteReader())
                {
                    if (oReader.Read())
                    {
                        acc.IDAccount = int.Parse(oReader[ID_ACCOUNT].ToString());
                        acc.AccountLevelID = int.Parse(oReader[ACCOUNT_LEVEL_ID].ToString());
                        acc.Email = oReader[EMAIL].ToString();
                        acc.Username = oReader[USERNAME].ToString();
                        acc.Password = oReader[PASSWORD].ToString();
                        acc.FirstName = oReader[FIRSTNAME].ToString();
                        acc.LastName = oReader[LASTNAME].ToString();
                        acc.Created = DateTime.Parse(oReader[CREATED].ToString());
                    }

                    myConnection.Close();
                }

            }
            return acc;
        }


        //http://localhost:52999/api/Account/UpdateAccount/1
        [Route("[action]/{id}")]
        [HttpPost]
        public void UpdateAccount(Account account)
        {
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                myConnection.Open();
                using (SqlCommand command = myConnection.CreateCommand())
                {
                    command.CommandText = "UpdateAccount";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(ID_ACCOUNT, account.IDAccount);
                    command.Parameters.AddWithValue(USERNAME, account.Username);
                    command.Parameters.AddWithValue(PASSWORD, account.Password);
                    command.Parameters.AddWithValue(FIRSTNAME, account.FirstName);
                    command.Parameters.AddWithValue(LASTNAME, account.LastName);
                    command.ExecuteNonQuery();

                }
            }
        }



        //http://localhost:52999/api/Account/LoginAccount/1
        [Route("[action]/{id}")]
        [HttpPost]
        public Account LoginAccount(string email, string password)
        {
            Account acc = new Account();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                var command = new SqlCommand("loginAccount", myConnection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(DB_EMAIL, SqlDbType.NVarChar));
                command.Parameters[DB_EMAIL].Value = email;
                command.Parameters.Add(new SqlParameter(DB_PASSWORD, SqlDbType.NVarChar));
                command.Parameters[DB_PASSWORD].Value = password;

                myConnection.Open();
                using (SqlDataReader oReader = command.ExecuteReader())
                {
                    if (oReader.Read())
                    {
                        acc.IDAccount = int.Parse(oReader[ID_ACCOUNT].ToString());
                        acc.AccountLevelID = int.Parse(oReader[ACCOUNT_LEVEL_ID].ToString());
                        acc.Email = oReader[EMAIL].ToString();
                        acc.Username = oReader[USERNAME].ToString();
                        acc.Password = oReader[PASSWORD].ToString();
                        acc.FirstName = oReader[FIRSTNAME].ToString();
                        acc.LastName = oReader[LASTNAME].ToString();
                        acc.Created = DateTime.Parse(oReader[CREATED].ToString());
                    }

                    myConnection.Close();
                }

            }
            return acc;
        }


        //http://localhost:52999/api/Account/CreatePerson/1
        [Route("[action]/{id}")]
        [HttpPost]
        public void CreatePerson(Account account)
        {
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "createAccount";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(DB_ACCOUNT_LEVEL_ID, account.AccountLevelID);
                    cmd.Parameters.AddWithValue(DB_EMAIL, account.Email);
                    cmd.Parameters.AddWithValue(DB_USERNAME, account.Username);
                    cmd.Parameters.AddWithValue(DB_PASSWORD, account.Password);
                    cmd.Parameters.AddWithValue(DB_FIRSTNAME, account.FirstName);
                    cmd.Parameters.AddWithValue(DB_LASTNAME, account.LastName);
                    
                    SqlParameter id = new SqlParameter(
                            "@idAccount",
                            System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    
                    cmd.ExecuteNonQuery();
                    account.IDAccount = (int)id.Value;
                }
            }
        }


    }
}
