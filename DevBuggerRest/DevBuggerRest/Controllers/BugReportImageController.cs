using DevBuggerRest.Model;
using DevBuggerRest.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugReportImageController : ControllerBase
    {
        private const string ID_BUGREPORTIMAGE = "IDBugReportImaget";
        private const string DB_ID_BUGREPORTIMAGE = "@idBugReportImaget";
        private const string BUGREPORTID = "BugReportID";
        private const string DB_BUGREPORTID = "@BugReportID";
        private const string IMAGE = "Image";
        private const string DB_IMAGE = "@Image";


        [HttpGet]
        public List<BugReportImage> GetBugReportImage()
        {
            try
            {
                List<BugReportImage> bugReportImages = new List<BugReportImage>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    using (var command = new SqlCommand("selectBugReportImages", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        myConnection.Open();
                        using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                BugReportImage bugReportImage = new BugReportImage();
                                bugReportImage.IDBugReportImage = int.Parse(oReader[ID_BUGREPORTIMAGE].ToString());
                                bugReportImage.BugReportID = int.Parse(oReader[BUGREPORTID].ToString());
                                bugReportImage.Image = Encoding.ASCII.GetBytes((oReader[BUGREPORTID].ToString()));
                                bugReportImages.Add(bugReportImage);

                            }

                            myConnection.Close();
                        }
                    }
                }

                return bugReportImages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/BugReportImage/GetBugReportImage/1
        [Route("[action]/{id}")]
        [HttpPost]
        public BugReportImage GetBugReportImage([FromBody] int idBugReportImage)
        {
            try
            {
                BugReportImage bugReportImage = new BugReportImage();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectBugReportImages", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ID_BUGREPORTIMAGE, SqlDbType.Int));
                    command.Parameters[ID_BUGREPORTIMAGE].Value = idBugReportImage;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            bugReportImage.IDBugReportImage = int.Parse(oReader[ID_BUGREPORTIMAGE].ToString());
                            bugReportImage.BugReportID = int.Parse(oReader[BUGREPORTID].ToString());
                            bugReportImage.Image = Encoding.ASCII.GetBytes((oReader[BUGREPORTID].ToString()));
                        }

                        myConnection.Close();
                    }

                }
                return bugReportImage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/BugReportImage/UpdateBugReportImage
        [Route("[action]")]
        [HttpPost]
        public bool UpdateBugReportImage(BugReportImage bugReportImage)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    myConnection.Open();
                    using (SqlCommand command = myConnection.CreateCommand())
                    {
                        command.CommandText = "updateBugReportImage";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(BUGREPORTID, bugReportImage.BugReportID);
                        command.Parameters.AddWithValue(IMAGE, bugReportImage.Image);
                        command.Parameters.AddWithValue(ID_BUGREPORTIMAGE, bugReportImage.IDBugReportImage);
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


        //http://localhost:5000/api/BugReportImage/CreateBugReportImage
        [Route("[action]")]
        [HttpPost]
        public bool CreateBugReportImage(BugReportImage bugReportImage)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "createComment";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(DB_BUGREPORTID, bugReportImage.BugReportID);
                        cmd.Parameters.AddWithValue(DB_IMAGE, bugReportImage.Image);
                        cmd.Parameters.AddWithValue(DB_ID_BUGREPORTIMAGE, bugReportImage.IDBugReportImage);

                        SqlParameter id = new SqlParameter(
                                "@idBugReportImage",
                                System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(id);

                        cmd.ExecuteNonQuery();
                        bugReportImage.IDBugReportImage = (int)id.Value;
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

        //http://localhost:5000/api/BugReportImage/DeleteBugReportImage
        [Route("[action]")]
        [HttpPost]
        public bool DeleteBugReportImage(BugReportImage bugReportImage)
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
                        cmd.Parameters.AddWithValue(DB_ID_BUGREPORTIMAGE, bugReportImage.IDBugReportImage);
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
