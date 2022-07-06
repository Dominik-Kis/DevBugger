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
    public class BugCategoryController : ControllerBase
    {
        private const string ID_CATEGORY = "IDCategory";
        private const string DB_ID_CATEGORY = "@IDCategory";
        private const string NAME = "Name";
        private const string DB_NAME = "@Name";
        private const string DESCRIPTION = "Description";
        private const string DB_DESCRIPTION = "@Description";

        [HttpGet]
        public List<BugCategory> GetBugCategory()
        {
            try
            {
                List<BugCategory> bugCategories = new List<BugCategory>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    using (var command = new SqlCommand("selectBugCategories", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        myConnection.Open();
                        using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                BugCategory bugCategory = new BugCategory();
                                bugCategory.IDCategory = int.Parse(oReader[ID_CATEGORY].ToString());
                                bugCategory.Name = oReader[NAME].ToString();
                                bugCategory.Description = oReader[DESCRIPTION].ToString();
                                bugCategories.Add(bugCategory);

                            }

                            myConnection.Close();
                        }
                    }
                }

                return bugCategories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/BugCategory/GetBugCategory/1
        [Route("[action]/{idBugCategory}")]
        [HttpGet]
        public BugCategory GetBugCategory([FromBody] int idBugCategory)
        {
            try
            {
                BugCategory bugCategory = new BugCategory();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectBugCategory", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(DB_ID_CATEGORY, SqlDbType.Int));
                    command.Parameters[DB_ID_CATEGORY].Value = idBugCategory;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            bugCategory.IDCategory = int.Parse(oReader[ID_CATEGORY].ToString());
                            bugCategory.Name = oReader[NAME].ToString();
                            bugCategory.Description = oReader[DESCRIPTION].ToString();
                        }

                        myConnection.Close();
                    }

                }
                return bugCategory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/BugCategory/UpdateBugCategory
        [Route("[action]")]
        [HttpPost]
        public bool UpdateBugCategory(BugCategory bugCategory)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    myConnection.Open();
                    using (SqlCommand command = myConnection.CreateCommand())
                    {
                        command.CommandText = "updateBugCategory";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(DB_ID_CATEGORY, bugCategory.IDCategory);
                        command.Parameters.AddWithValue(DB_NAME, bugCategory.Name);
                        command.Parameters.AddWithValue(DB_DESCRIPTION, bugCategory.Description);
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


        //http://localhost:5000/api/BugCategory/CreateBugCategory
        [Route("[action]")]
        [HttpPost]
        public bool CreateBugCategory(BugCategory bugCategory)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        SqlParameter id = new SqlParameter(
                                DB_ID_CATEGORY,
                                System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        cmd.CommandText = "createBugCategory";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(id);
                        cmd.Parameters.AddWithValue(DB_NAME, bugCategory.Name);
                        cmd.Parameters.AddWithValue(DB_DESCRIPTION, bugCategory.Description);

                        cmd.ExecuteNonQuery();
                        bugCategory.IDCategory = (int)id.Value;
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

        //http://localhost:5000/api/BugCategory/DeleteBugCategory
        [Route("[action]")]
        [HttpPost]
        public bool DeleteBugCategory(BugCategory bugCategory)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "deleteBugCategory";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(DB_ID_CATEGORY, bugCategory.IDCategory);
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
