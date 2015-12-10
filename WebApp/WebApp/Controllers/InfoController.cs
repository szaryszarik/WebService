using System.Web.Http;

namespace WebApp.Controllers
{
    public class InfoController : ApiController
    {
        public string GetInfo()
        {
            return "Info";
        }
    }
}
