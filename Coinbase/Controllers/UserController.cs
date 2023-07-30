using Coinbase.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Coinbase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        public UserController(IConfiguration configuration) {
        Configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            Logs LogdAL = new Logs();
            UserDAL dAL = new UserDAL();
            try
            {
                var result = dAL.GetUsers();
                var Response = new { StatusCode = HttpStatusCode.OK, Data = result };
                await Task.Delay(1);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                LogdAL.MappedModelLogs(DateTime.Now, "HttpGet", ex.Message, "UserController", "GetUsers");
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                await Task.Delay(1);
                return Ok(Response);

            }

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddupdateUsers(Usertable model)
        {
            bool Checkuser = true;
            Logs LogdAL = new Logs();
            UserDAL dAL = new UserDAL();
            try
            {
                if(model.Id== 0)
                {
                     Checkuser = dAL.CheckEmailExist(model.Emailaddress);
                }
                if (Checkuser)
                {
                    var result = dAL.AddUpdateUser(model);
                    if (result == true)
                    {
                        var Addupdate = model.Id > 0 ? "Update " : "Add ";
                        var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record " + Addupdate + "Successfully." };
                        await Task.Delay(1);
                        return Ok(Response);
                    }
                    else
                    {
                        var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Please Try Again" };
                        await Task.Delay(1);
                        return Ok(Response);
                    }
                }
                else
                {
                    var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Email already Exist" };
                    await Task.Delay(1);
                    return Ok(Response);
                }
            }
            catch (Exception ex)
            {
                LogdAL.MappedModelLogs(DateTime.Now, "HttpPost", ex.Message, "UserController", "AddupdateUsers");
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                await Task.Delay(1);
                return Ok(Response);

            }

        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            Logs LogdAL = new Logs();
            UserDAL dAL = new UserDAL();
            try
            {
                var result = dAL.DeleteUser(ID);
                if (result == true)
                {
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record Delete Successfully." };
                    await Task.Delay(1);
                    return Ok(Response);
                }
                else
                {
                    var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Please Try Again" };
                    await Task.Delay(1);
                    return Ok(Response);
                }

            }
            catch (Exception ex)
            {
                LogdAL.MappedModelLogs(DateTime.Now, "HttpDelete", ex.Message, "UserController", "DeleteUser");
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                await Task.Delay(1);
                return Ok(Response);

            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email,string password)
        {
            Logs LogdAL = new Logs();
            UserDAL dAL = new UserDAL();
            string GetToken = string.Empty;
            try
            {
                var jwt = Configuration.GetSection("Jwt").Get<Jwt>();
                var result = dAL.CheckLogin(email, password);
                if (result != null)
                {
                    var claims = new[]
                    {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,jwt.Subject),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
                        new Claim("Id",result.Id.ToString()),
                        new Claim("email",result.Emailaddress),
                        new Claim("password",result.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, expires: DateTime.Now.AddHours(8), signingCredentials: signIn);
                     GetToken = new JwtSecurityTokenHandler().WriteToken(token);
                }
                var Response = new { StatusCode = HttpStatusCode.OK, Token = GetToken, Data = result };
                await Task.Delay(1);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                LogdAL.MappedModelLogs(DateTime.Now, "HttpPost", ex.Message, "UserController", "GetUsers");
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                return Ok(Response);

            }

        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo(int ID)
        {
            UserDAL dAL = new UserDAL();
            try
            {
                var result = dAL.GetUserByID(ID);

                var Response = new { StatusCode = HttpStatusCode.OK, Data = result };
                await Task.Delay(1);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                await Task.Delay(1);
                return Ok(Response);

            }

        }
    }
}
