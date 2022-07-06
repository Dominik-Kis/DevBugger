
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
    public class BugReportController : ControllerBase
    {
        private const string ID_BUGREPORT = "IDBugReport";
        private const string DB_ID_BUGREPORT = "@IDBugReport";
        private const string BUGCATEGORYID = "BugCategoryID";
        private const string DB_BUGCATEGORYID = "@IDBugCategory";
        private const string GAMEPAGEID = "GamePageID";
        private const string DB_GAMEPAGEID = "@IDGamePage";
        private const string ACCOUNTID = "AccountID";
        private const string DB_ACCOUNTID = "@AccountID";
        private const string TITLE = "Title";
        private const string DB_TITLE = "@Title";
        private const string DESCRIPTION = "Description";
        private const string DB_DESCRIPTION = "@Description";
        private const string CREATED = "Created";
        private const string DB_CREATED = "@Created";


        [HttpGet]
        public List<BugReport> GetBugReports()
        {
            try
            {
                List<BugReport> bugReports = new List<BugReport>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    using (var command = new SqlCommand("selectBugReports", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        myConnection.Open();
                        using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                BugReport bugReport = new BugReport();
                                bugReport.IDBugReport = int.Parse(oReader[ID_BUGREPORT].ToString());
                                bugReport.BugCategoryID = int.Parse(oReader[BUGCATEGORYID].ToString());
                                bugReport.GamePageID = int.Parse(oReader[GAMEPAGEID].ToString());
                                bugReport.AccountID= int.Parse(oReader[ACCOUNTID].ToString());
                                bugReport.Title = oReader[TITLE].ToString();
                                bugReport.Description = oReader[DESCRIPTION].ToString();
                                bugReport.Created = DateTime.Parse(oReader[CREATED].ToString());
                                bugReports.Add(bugReport);

                            }

                            myConnection.Close();
                        }
                    }
                }

                return bugReports;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/BugReport/GetBugReport/1
        [Route("[action]/{idBugReport}")]
        [HttpGet]
        public BugReport GetBugReport(int idBugReport)
        {
            try
            {
                BugReport bugReport = new BugReport();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectBugReport", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ID_BUGREPORT, SqlDbType.Int));
                    command.Parameters[ID_BUGREPORT].Value = idBugReport;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            bugReport.IDBugReport = int.Parse(oReader[ID_BUGREPORT].ToString());
                            bugReport.BugCategoryID = int.Parse(oReader[BUGCATEGORYID].ToString());
                            bugReport.GamePageID = int.Parse(oReader[GAMEPAGEID].ToString());
                            bugReport.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            bugReport.Title = oReader[TITLE].ToString();
                            bugReport.Description = oReader[DESCRIPTION].ToString();
                            bugReport.Created = DateTime.Parse(oReader[CREATED].ToString());
                        }

                        myConnection.Close();
                    }

                }
                return bugReport;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/BugReport/GetBugReportsByGamePageID/1
        [Route("[action]/{idGamePage}")]
        [HttpGet]
        public List<BugReport> GetBugReportsByGamePageID(int idGamePage)
        {
            try
            {
                List<BugReport> bugReports = new List<BugReport>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectBugReportsByGamePageID", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(DB_GAMEPAGEID, SqlDbType.Int));
                    command.Parameters[DB_GAMEPAGEID].Value = idGamePage;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            BugReport bugReport = new BugReport();
                            bugReport.IDBugReport = int.Parse(oReader[ID_BUGREPORT].ToString());
                            bugReport.BugCategoryID = int.Parse(oReader[BUGCATEGORYID].ToString());
                            bugReport.GamePageID = int.Parse(oReader[GAMEPAGEID].ToString());
                            bugReport.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            bugReport.Title = oReader[TITLE].ToString();
                            bugReport.Description = oReader[DESCRIPTION].ToString();
                            bugReport.Created = DateTime.Parse(oReader[CREATED].ToString());
                            bugReports.Add(bugReport);
                        }

                        myConnection.Close();
                    }

                }
                return bugReports;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/BugReport/GetBugReportsByBugCategoryID/1
        [Route("[action]/{idBugCategory}")]
        [HttpGet]
        public List<BugReport> GetBugReportsByBugCategoryID(int idBugCategory)
        {
            try
            {
                List<BugReport> bugReports = new List<BugReport>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectBugReportsByBugCategoryID", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(DB_BUGCATEGORYID, SqlDbType.Int));
                    command.Parameters[DB_BUGCATEGORYID].Value = idBugCategory;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            BugReport bugReport = new BugReport();
                            bugReport.IDBugReport = int.Parse(oReader[ID_BUGREPORT].ToString());
                            bugReport.BugCategoryID = int.Parse(oReader[BUGCATEGORYID].ToString());
                            bugReport.GamePageID = int.Parse(oReader[GAMEPAGEID].ToString());
                            bugReport.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            bugReport.Title = oReader[TITLE].ToString();
                            bugReport.Description = oReader[DESCRIPTION].ToString();
                            bugReport.Created = DateTime.Parse(oReader[CREATED].ToString());
                            bugReports.Add(bugReport);
                        }

                        myConnection.Close();
                    }

                }
                return bugReports;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/BugReport/GetBugReportsByAccountID/1
        [Route("[action]/{idAccount}")]
        [HttpGet]
        public List<BugReport> GetBugReportsByAccountID(int idAccount)
        {
            try
            {
                List<BugReport> bugReports = new List<BugReport>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectBugReportsByAccountID", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(DB_ACCOUNTID, SqlDbType.Int));
                    command.Parameters[DB_ACCOUNTID].Value = idAccount;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            BugReport bugReport = new BugReport();
                            bugReport.IDBugReport = int.Parse(oReader[ID_BUGREPORT].ToString());
                            bugReport.BugCategoryID = int.Parse(oReader[BUGCATEGORYID].ToString());
                            bugReport.GamePageID = int.Parse(oReader[GAMEPAGEID].ToString());
                            bugReport.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            bugReport.Title = oReader[TITLE].ToString();
                            bugReport.Description = oReader[DESCRIPTION].ToString();
                            bugReport.Created = DateTime.Parse(oReader[CREATED].ToString());
                            bugReports.Add(bugReport);
                        }

                        myConnection.Close();
                    }

                }
                return bugReports;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/BugReport/UpdateBugReport
        [Route("[action]")]
        [HttpPost]
        public bool UpdateBugReport(BugReport bugReport)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    myConnection.Open();
                    using (SqlCommand command = myConnection.CreateCommand())
                    {
                        command.CommandText = "updateBugReport";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(ID_BUGREPORT, bugReport.IDBugReport);
                        command.Parameters.AddWithValue(BUGCATEGORYID, bugReport.BugCategoryID);
                        command.Parameters.AddWithValue(GAMEPAGEID, bugReport.GamePageID);
                        command.Parameters.AddWithValue(ACCOUNTID, bugReport.AccountID);
                        command.Parameters.AddWithValue(TITLE, bugReport.Title);
                        command.Parameters.AddWithValue(DESCRIPTION, bugReport.Description);
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


        //http://localhost:5000/api/BugReport/CreateBugReport
        [Route("[action]")]
        [HttpPost]
        public bool CreateBugReport(BugReport bugReport)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "createBugReport";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(DB_BUGCATEGORYID, bugReport.BugCategoryID);
                        cmd.Parameters.AddWithValue(DB_GAMEPAGEID, bugReport.GamePageID);
                        cmd.Parameters.AddWithValue(DB_ACCOUNTID, bugReport.AccountID);
                        cmd.Parameters.AddWithValue(DB_TITLE, bugReport.Title);
                        cmd.Parameters.AddWithValue(DB_DESCRIPTION, bugReport.Description);

                        SqlParameter id = new SqlParameter(
                                "@idBugReport",
                                System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(id);

                        cmd.ExecuteNonQuery();
                        bugReport.IDBugReport = (int)id.Value;
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

        //http://localhost:5000/api/BugReport/DeleteBugReport
        [Route("[action]")]
        [HttpPost]
        public bool DeleteBugReport(BugReport bugReport)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "deleteBugReport";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(DB_ID_BUGREPORT, bugReport.IDBugReport);
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
