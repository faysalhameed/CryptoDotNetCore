using Coinbase.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace Coinbase.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MonoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AddAccountMono(string BankCode,int UserID)
        {
            CCProfileDAL dAL = new CCProfileDAL();
            try
            {
                var result = dAL.AddmonoAccount(BankCode, UserID);
                if (result == true)
                {
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record Add Successfully." };
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
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                await Task.Delay(1);
                return Ok(Response);

            }

        }



    }
}
