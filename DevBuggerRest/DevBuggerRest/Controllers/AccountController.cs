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
        private string con = "Server=.\\SQLEXPRESS;Database=DevBugger;Trusted_Connection=True;";

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
                            acc.IDAccount = int.Parse(oReader["IDAccount"].ToString());
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
        [HttpGet]
        public Account GetAccount(int id)
        {
            Account acc = new Account();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                var command = new SqlCommand("selectAccount", myConnection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IDAccount", SqlDbType.Int));
                command.Parameters["@IDAccount"].Value = id;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            acc.IDAccount = int.Parse(oReader["IDAccount"].ToString());
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
    }
}
