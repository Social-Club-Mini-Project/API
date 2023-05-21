using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myClubeAPI.Controllers.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace UploadImageWithData8777.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public Task<common> Post([FromForm] FileUploadAPI objFile)
        {
            common obj = new common();
            obj.LstCustomer = new List<Customer>();
            obj._fileAPI = new FileUploadAPI();
            try
            {
                List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(objFile.Customers);
                obj.LstCustomer = list;
                obj._fileAPI.ImgID = objFile.ImgID;
                obj._fileAPI.ImgName = "\\Upload\\" + objFile.files.FileName;
                if (objFile.files.Length > 0)
                {


                    //if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
                    //{
                    //    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    //}
                    //using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    //{
                    //    objFile.files.CopyTo(filestream);
                    //    filestream.Flush();
                    //    //  return "\\Upload\\" + objFile.files.FileName;
                    //}
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(obj);
        }
    }
}