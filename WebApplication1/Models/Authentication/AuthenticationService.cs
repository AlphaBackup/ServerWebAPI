using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AuthenticationService
    {
        const string SECRET = "xxx";

        private MyContext context = new MyContext();

        public string Authenticate(Credentials credentials)
        {
            Administrator admin = this.context.Administrators.Where(x => x.Name == credentials.Login && x.Password == credentials.Password).FirstOrDefault();

            if (admin == null)
                throw new Exception("invalid user");

            return JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(SECRET)
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
                      .AddClaim("user_id", admin.Id)
                      .Encode();
        }

        public bool VerifyToken(string token)
        {
            try
            {
                string json = JwtBuilder.Create()
                             .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                             .WithSecret(SECRET)
                             .MustVerifySignature()
                             .Decode(token);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
