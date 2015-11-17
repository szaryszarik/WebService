using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class InfoController : ApiController
    {
        // GET api/Employers
        public string getInfo()
        {
            return "Info";
        }
    }
}
