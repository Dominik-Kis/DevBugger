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
        private const string ID = "@IDAccount";

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
                            acc.AccountLevelID = int.Parse(oReader["AccountLevelID"].ToString());
                            acc.Email = oReader["Email"].ToString();
                            acc.Username = oReader["Username"].ToString();
                            acc.Password = oReader["Password"].ToString();
                            acc.FirstName = oReader["FirstName"].ToString();
                            acc.LastName = oReader["LastName"].ToString();
                            acc.Created = DateTime.Parse(oReader["Created"].ToString());
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
        public Account GetAccount(int id)
        {
            Account acc = new Account();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                var command = new SqlCommand("selectAccount", myConnection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(ID, SqlDbType.Int));
                command.Parameters[ID].Value = id;

                myConnection.Open();
                using (SqlDataReader oReader = command.ExecuteReader())
                {
                    if (oReader.Read())
                    {
                        acc.IDAccount = int.Parse(oReader[ID_ACCOUNT].ToString());
                        acc.AccountLevelID = int.Parse(oReader["AccountLevelID"].ToString());
                        acc.Email = oReader["Email"].ToString();
                        acc.Username = oReader["Username"].ToString();
                        acc.Password = oReader["Password"].ToString();
                        acc.FirstName = oReader["FirstName"].ToString();
                        acc.LastName = oReader["LastName"].ToString();
                        acc.Created = DateTime.Parse(oReader["Created"].ToString());
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
                    command.Parameters.AddWithValue("IDAccount", account.IDAccount);
                    command.Parameters.AddWithValue("Username", account.Username);
                    command.Parameters.AddWithValue("Password", account.Password);
                    command.Parameters.AddWithValue("FirstName", account.FirstName);
                    command.Parameters.AddWithValue("LastName", account.LastName);
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
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                command.Parameters["@Email"].Value = email;
                command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
                command.Parameters["@Password"].Value = password;

                myConnection.Open();
                using (SqlDataReader oReader = command.ExecuteReader())
                {
                    if (oReader.Read())
                    {
                        acc.IDAccount = int.Parse(oReader[ID_ACCOUNT].ToString());
                        acc.AccountLevelID = int.Parse(oReader["AccountLevelID"].ToString());
                        acc.Email = oReader["Email"].ToString();
                        acc.Username = oReader["Username"].ToString();
                        acc.Password = oReader["Password"].ToString();
                        acc.FirstName = oReader["FirstName"].ToString();
                        acc.LastName = oReader["LastName"].ToString();
                        acc.Created = DateTime.Parse(oReader["Created"].ToString());
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
                    cmd.Parameters.AddWithValue("@AccountLevelID", account.AccountLevelID);
                    cmd.Parameters.AddWithValue("@Email", account.Email);
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@Firstname", account.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", account.LastName);
                    /*
                    SqlParameter id = new SqlParameter(
                            IdPersonParam,
                            System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    */
                    cmd.ExecuteNonQuery();
                    //person.IDPerson = (int)id.Value;
                }
            }
        }


    }
}
