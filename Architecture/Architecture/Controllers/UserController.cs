using Manager.Query;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Architecture.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(User user)
        {
            (new UserQueryManager()).Login(user);
            JsonConvert.SerializeObject(user);
            return Json(JsonConvert.SerializeObject(user));
        }
    }
}
