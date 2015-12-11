using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.IdentityModel.Claims;

namespace JWTTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "Oleh";
            string sid = "123";

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName, "All"),
                new Claim(ClaimTypes.Sid, sid, "All")
            };
            byte[] bytes = { 1, 2 , 3 };

            var tokenHandler = new JwtSecurityTokenHandler();
            var sKey = new InMemorySymmetricSecurityKey(bytes);
            Console.WriteLine(result.CreateToken().ToString());
            Console.ReadKey();
        }
    }
}
