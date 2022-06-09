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
    public class CommentController : ControllerBase
    {
        private const string ID_COMMENT = "IDComment";
        private const string DB_ID_COMMENT = "@idComment";
        private const string BUGREPORTID = "BugReportID";
        private const string DB_BUGREPORTID = "@BugReportID";
        private const string ACCOUNTID = "AccountID";
        private const string DB_ACCOUNTID = "@AccountID";
        private const string TEXT = "Text";
        private const string DB_TEXT = "@Text";
        private const string CREATED = "Created";
        private const string DB_CREATED = "@Created";


        [HttpGet]
        public List<Comment> GetComments()
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    using (var command = new SqlCommand("selectComments", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        myConnection.Open();
                        using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                Comment comment = new Comment();
                                comment.IDComment = int.Parse(oReader[ID_COMMENT].ToString());
                                comment.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                                comment.BugReportID = int.Parse(oReader[BUGREPORTID].ToString());
                                comment.Text = oReader[TEXT].ToString();
                                comment.Created = DateTime.Parse(oReader[CREATED].ToString());
                                comments.Add(comment);

                            }

                            myConnection.Close();
                        }
                    }
                }

                return comments;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //http://localhost:5000/api/Comment/GetComment/1
        [Route("[action]/{id}")]
        [HttpPost]
        public Comment GetComment([FromBody] int idComment)
        {
            try
            {
                Comment comment = new Comment();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectComment", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ID_COMMENT, SqlDbType.Int));
                    command.Parameters[ID_COMMENT].Value = idComment;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            comment.IDComment = int.Parse(oReader[ID_COMMENT].ToString());
                            comment.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            comment.BugReportID = int.Parse(oReader[BUGREPORTID].ToString());
                            comment.Text = oReader[TEXT].ToString();
                            comment.Created = DateTime.Parse(oReader[CREATED].ToString());
                        }

                        myConnection.Close();
                    }

                }
                return comment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/Comment/GetCommentsByAccountID/1
        [Route("[action]/{id}")]
        [HttpPost]
        public List<Comment> GetCommentsByAccountID([FromBody] int idAccount)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectCommentsByAccountID", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ACCOUNTID, SqlDbType.Int));
                    command.Parameters[ACCOUNTID].Value = idAccount;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Comment comment = new Comment();
                            comment.IDComment = int.Parse(oReader[ID_COMMENT].ToString());
                            comment.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            comment.BugReportID = int.Parse(oReader[BUGREPORTID].ToString());
                            comment.Text = oReader[TEXT].ToString();
                            comment.Created = DateTime.Parse(oReader[CREATED].ToString());
                            comments.Add(comment);
                        }

                        myConnection.Close();
                    }

                }
                return comments;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/Comment/GetCommentsByBugReportID/1
        [Route("[action]/{id}")]
        [HttpPost]
        public List<Comment> GetCommentsByBugReportID([FromBody] int idBugReport)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    var command = new SqlCommand("selectCommentsByBugReportID", myConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(ACCOUNTID, SqlDbType.Int));
                    command.Parameters[BUGREPORTID].Value = idBugReport;

                    myConnection.Open();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Comment comment = new Comment();
                            comment.IDComment = int.Parse(oReader[ID_COMMENT].ToString());
                            comment.AccountID = int.Parse(oReader[ACCOUNTID].ToString());
                            comment.BugReportID = int.Parse(oReader[BUGREPORTID].ToString());
                            comment.Text = oReader[TEXT].ToString();
                            comment.Created = DateTime.Parse(oReader[CREATED].ToString());
                            comments.Add(comment);
                        }

                        myConnection.Close();
                    }

                }
                return comments;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        //http://localhost:5000/api/Comment/UpdateComment
        [Route("[action]")]
        [HttpPost]
        public bool UpdateComment(Comment comment)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SqlConnectionUtils.con))
                {
                    myConnection.Open();
                    using (SqlCommand command = myConnection.CreateCommand())
                    {
                        command.CommandText = "updateComment";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(BUGREPORTID, comment.BugReportID);
                        command.Parameters.AddWithValue(ACCOUNTID, comment.AccountID);
                        command.Parameters.AddWithValue(TEXT, comment.Text);
                        command.Parameters.AddWithValue(CREATED, comment.Created);
                        command.Parameters.AddWithValue(ID_COMMENT, comment.IDComment);
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


        //http://localhost:5000/api/Comment/CreateComment
        [Route("[action]")]
        [HttpPost]
        public bool CreateComment(Comment comment) 
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
                        cmd.Parameters.AddWithValue(DB_BUGREPORTID, comment.BugReportID);
                        cmd.Parameters.AddWithValue(DB_ACCOUNTID, comment.AccountID);
                        cmd.Parameters.AddWithValue(DB_TEXT, comment.Text);

                        SqlParameter id = new SqlParameter(
                                "@idComment",
                                System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(id);

                        cmd.ExecuteNonQuery();
                        comment.IDComment = (int)id.Value;
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

        //http://localhost:5000/api/Comment/DeleteComment
        [Route("[action]")]
        [HttpPost]
        public bool DeleteComment(Comment comment)
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
                        cmd.Parameters.AddWithValue(DB_ID_COMMENT, comment.IDComment);
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
