using Coinbase.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Coinbase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddupdateSettings(Transactiontable model)
        {
            TransactionDAL dAL = new TransactionDAL();
            try
            {
                var result = dAL.AddTransaction(model);
                if (result == true)
                {
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Transaction Added Successfully."};
                    return Ok(Response);
                }
                else
                {
                    var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Please Try Again" };
                    return Ok(Response);
                }

            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                return Ok(Response);

            }

        }
    }
}
