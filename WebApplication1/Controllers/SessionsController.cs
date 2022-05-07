using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private AuthenticationService auth = new AuthenticationService();

        [HttpPost]
        public JsonResult Login(Credentials credentials)
        {
            try
            {
                return new JsonResult(this.auth.Authenticate(credentials));
            }
            catch
            {
                return new JsonResult("Invalid username or password") { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        [HttpPost]
        [Route("extend")]
        public JsonResult ExpirationExtend(Token token)
        {
            try
            {
                return new JsonResult(this.auth.ExpritaionExtend(token._Token));
            }
            catch
            {
                return new JsonResult("Invalid Token") { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
