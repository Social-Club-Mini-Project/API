using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace myClubeAPI.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        string sqlConnection = "Server=localhost;data Source=.;Database=.;Initial Catalog=MTISocialClub;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public JsonResult Get()
        {

            String query = "SELECT * FROM post";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            conn.Open();
            List<post> deps = new List<post>();
            SqlDataReader rdr = cmmd.ExecuteReader();
            if (rdr.HasRows)
            {
                post post;
                while (rdr.Read())
                {
                    post = new post();
                    post.postID = (int)rdr["post_id"];
                    post.userID = (int)rdr["userID"];
                    post.text = rdr["text"].ToString();
                    post.postDate = (DateTime)rdr["post_date"];
                    post.likes = (int)rdr["likes"];
                    deps.Add(post);
                }
            }
            conn.Close();
            

            return new JsonResult(deps);

        }
        [Route("getpostID")]
        [HttpGet]
        public JsonResult GetPostID(int id)
        {

            String query = $"SELECT * FROM post where userID = {id}";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            conn.Open();
            List<post> deps = new List<post>();
            SqlDataReader rdr = cmmd.ExecuteReader();
            if (rdr.HasRows)
            {
                post post;
                while (rdr.Read())
                {
                    post = new post();
                    post.postID = (int)rdr["post_id"];
                    post.userID = (int)rdr["userID"];
                    post.text = rdr["text"].ToString();
                    post.postDate = (DateTime)rdr["post_date"];
                    post.likes = (int)rdr["likes"];
                    deps.Add(post);
                }
            }
            conn.Close();


            return new JsonResult(deps);

        }
        [HttpPost]
        public string post(post p)
        {
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            String query = $"INSERT INTO post values ({p.userID},'{date}','{p.text}',null,0)";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();
                return "post done";

            }
            catch (Exception)
            {
                return "post error";
            }
        }

        //you can just edit post text
        [HttpPut]
        public string Update(post p)
        {
            String query = $"UPDATE post SET text = '{p.text}' WHERE post_id={p.postID};";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();
                return "post Updated";

            }
            catch (Exception)
            {
                return "post error";
            }

        }

        [HttpDelete]
        public string Delete(string id)
        {

            String query = $"delete from post where post_id = {id};";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();
                return "post deleted";

            }
            catch (Exception)
            {
                return "error check if the id existe";
            }



        }

    }
}
