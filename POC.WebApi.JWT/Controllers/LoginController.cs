using POC.DTO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace POC.WebApi.JWT.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginRequest loginRequest)
        {
            var loginResponse = new LoginResponse
            {
                ResponseMessage = new HttpResponseMessage()
            };

            IHttpActionResult response;

            bool isUsernamePasswordValid = false;

            if (loginRequest != null)
                isUsernamePasswordValid = loginRequest.Password == "admin" ? true : false;
            // if credentials are valid
            if (isUsernamePasswordValid)
            {
                string token = CreateToken(loginRequest.UserName);
                //return the token
                return Ok<string>(token);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                loginResponse.ResponseMessage.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(loginResponse.ResponseMessage);
                return response;
            }
        }

        private string CreateToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddMinutes(1);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim (ClaimTypes.NameIdentifier ,1.ToString () /*userId*/)//,
                //new Claim(ClaimTypes.Role, "Admin")
            }, "custom");

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

            var noChar = sec.ToArray<char>().Count();
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:59311/", audience: "http://localhost:59311/",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
