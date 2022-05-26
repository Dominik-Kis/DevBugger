using DevBuggerRest.Model;
using DevBuggerRest.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuggerRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePageController : ControllerBase
    {
        private const string ID_GAMEPAGE = "IDGamePage";
        private const string DB_ID_GAMEPAGE = "@idGamePage";
        private const string ACCOUNTID = "AccountID";
        private const string DB_ACCOUNTID = "@AccountID";
        private const string TITLE = "Title";
        private const string DB_TITLE = "@Title";
        private const string DESCRIPTION = "Description";
        private const string DB_DESCRIPTION = "@Description";
        private const string CREATED = "Created";
        private const string DB_CREATED = "@Created";


        [HttpGet]
        public List<GamePage> GetGamePages()
        {

            //var con = ConfigurationManager.ConnectionStrings["MasterDatabase"].ToString();
            try
            {
                List<GamePage> gamePages = new List<GamePage>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    using (var command = new SqlCommand("selectGamePages", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        myConnection.Open();
                        using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                GamePage gp = new GamePage();
                                gp.IDGamePage = int.Parse(oReader[ID_GAMEPAGE].ToString());
                                gp .AccountID= int.Parse(oReader[ACCOUNTID].ToString());
                                gp.Title = oReader[TITLE].ToString();
                                gp.Description = oReader[DESCRIPTION].ToString();
                                gp.Created = DateTime.Parse(oReader[CREATED].ToString());
                                gamePages.Add(gp);

                            }

                            myConnection.Close();
                        }
                    }
                }

                return gamePages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/GamePage/GetGamePage/1
        [Route("[action]/{id}")]
        [HttpPost]
        public GamePage GetGamePage([FromBody] int idGamePage)
        {
            try
            {
                GamePage gp = new GamePage();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectGamePage", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ID_GAMEPAGE, SqlDbType.Int));
                    command.Parameters[ID_GAMEPAGE].Value = idGamePage;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            gp.IDGamePage = int.Parse(oReader[ID_GAMEPAGE].ToString());
                            gp.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            gp.Title = oReader[TITLE].ToString();
                            gp.Description = oReader[DESCRIPTION].ToString();
                            gp.Created = DateTime.Parse(oReader[CREATED].ToString());
                        }

                        myConnection.Close();
                    }

                }
                return gp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/GamePage/GetGamePagesByAccountID/1
        [Route("[action]/{id}")]
        [HttpPost]
        public List<GamePage> GetGamePagesByAccountID([FromBody] int idAccount)
        {
            try
            {
                List<GamePage> gamePages = new List<GamePage>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectGamePageByAccountID", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ACCOUNTID, SqlDbType.Int));
                    command.Parameters[ACCOUNTID].Value = idAccount;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            GamePage gamePage = new GamePage();
                            gamePage.IDGamePage = int.Parse(oReader[ID_GAMEPAGE].ToString());
                            gamePage.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            gamePage.Title = oReader[TITLE].ToString();
                            gamePage.Description = oReader[DESCRIPTION].ToString();
                            gamePage.Created = DateTime.Parse(oReader[CREATED].ToString());
                            gamePages.Add(gamePage);
                        }

                        myConnection.Close();
                    }

                }
                return gamePages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/GamePage/UpdateGamePage
        [Route("[action]")]
        [HttpPost]
        public bool UpdateGamePage(GamePage gamePage)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    myConnection.Open();
                    using (SqlCommand command = myConnection.CreateCommand())
                    {
                        command.CommandText = "updateGamePage";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(ACCOUNTID, gamePage.AccountID);
                        command.Parameters.AddWithValue(CREATED, gamePage.Created);
                        command.Parameters.AddWithValue(TITLE, gamePage.Title);
                        command.Parameters.AddWithValue(DESCRIPTION, gamePage.Description);
                        command.Parameters.AddWithValue(ID_GAMEPAGE, gamePage.IDGamePage);
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


        //http://localhost:5000/api/GamePage/CreateGamePage
        [Route("[action]")]
        [HttpPost]
        public bool CreateGamePage(GamePage gamePage)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "createGamePage";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(DB_ACCOUNTID, gamePage.AccountID);
                        cmd.Parameters.AddWithValue(DB_TITLE, gamePage.Title);
                        cmd.Parameters.AddWithValue(DB_DESCRIPTION, gamePage.Description);

                        SqlParameter id = new SqlParameter(
                                "@idGamePage",
                                System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(id);

                        cmd.ExecuteNonQuery();
                        gamePage.IDGamePage = (int)id.Value;
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

        //http://localhost:5000/api/GamePage/DeleteGamePage
        [Route("[action]")]
        [HttpPost]
        public bool DeleteGamePage(GamePage gamePage)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "deleteGamePage";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(DB_ID_GAMEPAGE, gamePage.IDGamePage);
                        cmd.ExecuteNonQuery();
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
