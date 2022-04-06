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
        [HttpGet]
        public List<Account> GetAccounts()
        {

            //var con = ConfigurationManager.ConnectionStrings["MasterDatabase"].ToString();
            string con = "Server=.\\SQLEXPRESS;Database=DevBugger;Trusted_Connection=True;";

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
    }
}
