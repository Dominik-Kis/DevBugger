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
using DevBuggerRest.Utils;

namespace DevBuggerRest.Controllers
{


    //http://localhost:5000/api/Account
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
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

        private const string DELETEDACCOUNT = "[Deleted_Account]";

        [HttpGet]
        public List<Account> GetAccounts()
        {

            //var con = ConfigurationManager.ConnectionStrings["MasterDatabase"].ToString();
            try
            {
                List<Account> accounts = new List<Account>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/Account/GetAccount/1
        [Route("[action]/{id}")]
        [HttpPost]
        public Account GetAccount([FromBody] int idAccount)
        {
            try
            {
                Account acc = new Account();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectAccount", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ID_ACCOUNT, SqlDbType.Int));
                    command.Parameters[ID_ACCOUNT].Value = idAccount;

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/Account/UpdateAccount
        [Route("[action]")]
        [HttpPost]
        public bool UpdateAccount(Account account)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
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
                if(account.Username.Equals(DELETEDACCOUNT))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }



        //http://localhost:5000/api/Account/LoginAccount
        [Route("[action]")]
        [HttpPost]
        public Account LoginAccount(Account account)
        {
            try
            {
                Account returnAccount = new Account();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("loginAccount", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(DB_EMAIL, SqlDbType.NVarChar));
                    command.Parameters[DB_EMAIL].Value = account.Email;
                    command.Parameters.Add(new SqlParameter(DB_PASSWORD, SqlDbType.NVarChar));
                    command.Parameters[DB_PASSWORD].Value = account.Password;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            returnAccount.IDAccount = int.Parse(oReader[ID_ACCOUNT].ToString());
                            returnAccount.AccountLevelID = int.Parse(oReader[ACCOUNT_LEVEL_ID].ToString());
                            returnAccount.Email = oReader[EMAIL].ToString();
                            returnAccount.Username = oReader[USERNAME].ToString();
                            returnAccount.Password = oReader[PASSWORD].ToString();
                            returnAccount.FirstName = oReader[FIRSTNAME].ToString();
                            returnAccount.LastName = oReader[LASTNAME].ToString();
                            returnAccount.Created = DateTime.Parse(oReader[CREATED].ToString());
                        }

                        myConnection.Close();
                    }

                }
                if (returnAccount.Username.Equals(DELETEDACCOUNT))
                {
                    return null;
                }
                else
                {
                    return returnAccount;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/Account/CreateAccount
        [Route("[action]")]
        [HttpPost]
        public bool CreateAccount(Account account)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
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
                if (account.Username.Equals(DELETEDACCOUNT))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        //http://localhost:5000/api/Account/UpdateToDummy
        [Route("[action]")]
        [HttpPost]
        public bool UpdateToDummy(Account account)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    myConnection.Open();
                    using (SqlCommand command = myConnection.CreateCommand())
                    {
                        command.CommandText = "updateToDummy";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(ID_ACCOUNT, account.IDAccount);
                        command.Parameters.AddWithValue(USERNAME, account.Username);
                        command.Parameters.AddWithValue(PASSWORD, account.Password);
                        command.Parameters.AddWithValue(FIRSTNAME, account.FirstName);
                        command.Parameters.AddWithValue(LASTNAME, account.LastName);
                        command.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }


    }
}
