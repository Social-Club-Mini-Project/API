using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using myClubeAPI.Controllers.rep;
using System.Data;
using System.Xml.Linq;
using static myClubeAPI.Controllers.UserController;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.IO;
using Azure;
using System.Web.Http.Description;
using System.Net;
using Azure.Core;
using Newtonsoft.Json;
using static Azure.Core.HttpHeader;
using Microsoft.AspNetCore.Hosting;
using System.IO.Pipes;

namespace myClubeAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        string sqlConnection = "Server=localhost;data Source=.;Database=.;Initial Catalog=MTISocialClub;Trusted_Connection=True;TrustServerCertificate=True;";

        //your can get only 1 user with password = null
        [HttpGet]
        public user Get(int id)
        {

            String query = $"SELECT * FROM users where userID ={id}";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            conn.Open();
            user userr = new user();
            SqlDataReader rdr = cmmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    userr.userID = (int)rdr["userID"];
                    userr.email = rdr["email"].ToString();
                    userr.name = rdr["name"].ToString();
                    userr.birth_date = (DateTime)rdr["birth_date"];
                    userr.phone = rdr["phone"].ToString();
                    userr.address = rdr["address"].ToString();
                    userr.Level = (int)rdr["Level"];
                    userr.user_role = rdr["user_role"].ToString();
                    userr.gender = rdr["gender"].ToString();
                    userr.dep_id = (int)rdr["dep_id"];
                }
            }
            conn.Close();
            return userr;

        }
        //login by check id and password then return user object
        [HttpGet]
        [Route("/login")]
        public user GetLogin(int id, string pass)
        {
            user userr = new user();
            SqlConnection con = new SqlConnection(sqlConnection);
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM users where userID ={id} and Password = '{pass}';", con);
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    return Get(id);
                }
            }
            catch (Exception)
            {
                con.Close();
            }
            return userr;
        }

        [HttpPost]
        public string AddUser(user u)
        {

            String query = $"INSERT INTO users values ({u.userID},'{u.email}','{u.password}','{u.name}','{u.birth_date}','{u.phone}'," +
                            $"'{u.address}','{u.Level}','{u.user_role}',null,'{u.gender}','{u.dep_id}')";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();
                return "user added";

            }
            catch (Exception)
            {
                return "user error check if the id not used or the email";
            }
        }





        /*
                //you can update user by id in the sended object
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
        */
        [HttpDelete]
        public string Delete(int id)
        {

            String query = $"delete from users where userID = {id};";
            SqlConnection conn = new SqlConnection(sqlConnection);
            SqlCommand cmmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();
                return "user deleted";

            }
            catch (Exception)
            {
                return "error check if the id existe";
            }
        }


        [HttpGet]
        [Route("/userimgg")]
        public IActionResult Get()
        {
            var image = System.IO.File.OpenRead("noimg.png");
            return File(image, "image/png");
        }

        [HttpGet]
        [ResponseType(typeof(Byte[]))]
        [Route("/userimg")]
        public IActionResult GetUserImages1(int id)
        {
            SqlConnection conn = new SqlConnection(sqlConnection);
            string q = $"SELECT * FROM users where userID ={id}";
            SqlCommand cmmd = new SqlCommand(q, conn);
            conn.Open();

            SqlDataReader rdr = cmmd.ExecuteReader();

            //Imagee img = new Imagee();

            if (rdr.HasRows && rdr.Read())
            {
                Byte[] byteBLOBData = new Byte[0];
                try
                {
                    byteBLOBData = (Byte[])((byte[])rdr["Profile_photo"]);
                    conn.Close();
                    //img.UserId = (int)rdr["userID"];
                    return Ok(byteBLOBData);
                }
                catch (Exception)
                {
                    conn.Close();
                    return Ok(new Byte[0]);
                }
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("/UpdateImg")]
        public IActionResult UpdateUserImg(Imagee img, int id)
        {
            SqlConnection conn = new SqlConnection(sqlConnection);
            string q = $"SELECT * FROM users where userID ={id}";
            SqlCommand cmmd = new SqlCommand(q, conn);
            conn.Open();

            SqlDataReader rdr = cmmd.ExecuteReader();

            //Imagee img = new Imagee();

            if (rdr.HasRows && rdr.Read())
            {
                byte[] byteBLOBData = new byte[0];
                try
                {
                    byteBLOBData = ((byte[])rdr["Profile_photo"]);
                    conn.Close();
                    //img.UserId = (int)rdr["userID"];
                    return Ok(byteBLOBData);

                }
                catch (Exception)
                {
                    conn.Close();
                    return Ok(new Byte[0]);
                }
            }
            else
            {
                return NotFound();
            }

        }

        //[HttpPost]
        //public string saveImage(byte[] img)
        //{
        //    if (img == null)
        //        return null;

        //    System.Drawing.Image newImage;

        //    try
        //    {
        //        using (MemoryStream ms = new MemoryStream(bArray, 0, bArray.Length))
        //        {
        //            ms.Write(bArray, 0, bArray.Length);
        //            newImage = System.Drawing.Image.FromStream(ms, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        newImage = null;

        //        //Log an error here
        //    }

        //    return newImage;
        //}
    }
}