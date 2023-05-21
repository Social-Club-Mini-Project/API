using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace myClubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        /*        [HttpGet]
                [Route("/department")]
                public JsonResult Get()
                {
                    string sqlConnection = "Server=localhost;data Source=.;Database=.;Initial Catalog=MTISocialClub;Trusted_Connection=True;TrustServerCertificate=True;";
                    String query = "SELECT * FROM department";
                    DataTable table = new DataTable();
                    // String sqlDataSource = _configuration.GetConnectionString(sqlConnection);
                    SqlDataReader r;
                    using (SqlConnection mycon = new SqlConnection(sqlConnection))
                    {
                        mycon.Open();
                        using (SqlCommand cmd = new SqlCommand(query, mycon))
                        {
                            r = cmd.ExecuteReader();
                            table.Load(r);
                            r.Close();
                            mycon.Close();
                        }
                    }
                    return new JsonResult(table);
                }

        */



       [HttpGet]
        [Route("/department")]
        public List<Department> Get()
        {


        /*            string sqlConnection = "Server=localhost;data Source=.;Database=.;Initial Catalog=MTISocialClub;Trusted_Connection=True;TrustServerCertificate=True;";
                    SqlConnection con = new SqlConnection(sqlConnection);
                    SqlCommand cmd = new SqlCommand($"select * from department;", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    con.Close();
        */

        String query = "SELECT * FROM department";
        string sqlConnection = "Server=localhost;data Source=.;Database=.;Initial Catalog=MTISocialClub;Trusted_Connection=True;TrustServerCertificate=True;";
        SqlConnection conn = new SqlConnection(sqlConnection);
        SqlCommand cmmd = new SqlCommand(query, conn);
        conn.Open();
        List<Department> deps = new List<Department>();
        SqlDataReader rdr = cmmd.ExecuteReader();
            if (rdr.HasRows)
            {
                Department dep;
                while (rdr.Read())
                {
                    dep = new Department();

                    dep.id = (int)rdr["dep_id"];
                    dep.name = rdr["dep_name"].ToString();

                    deps.Add(dep);
                }
            }
            conn.Close();

            return deps;   
        }


    }
}
