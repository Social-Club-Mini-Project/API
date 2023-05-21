using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace myClubeAPI.Controllers
{
    public class post
    {
        public int postID
        { get; set; }
        public int userID
        { get; set; }
        public DateTime postDate
        { get; set; }
        public String text
        { get; set; }
        public int likes 
        { get; set; }

    }
}
