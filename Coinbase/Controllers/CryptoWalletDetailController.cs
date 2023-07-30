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
    public class CryptoWalletDetailController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            CryptoWalletDetailDAL dAL = new CryptoWalletDetailDAL();
            try
            {
                var result = dAL.GetList();
                var Response = new { StatusCode = HttpStatusCode.OK, Data = result };
                return Ok(Response);
            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                return Ok(Response);

            }

        }
        public IActionResult DeleteCryptoWallet(int ID)
        {
            CryptoWalletDetailDAL dAL = new CryptoWalletDetailDAL();
            try
            {
                var result = dAL.DeleteCryptoWalletDetail(ID);
                if (result == true)
                {
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record Delete Successfully." };
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

        [HttpPost]
        public IActionResult AddupdateCryptoWalletDetail(Cryptowalletdetailtable model)
        {
            CryptoWalletDetailDAL dAL = new CryptoWalletDetailDAL();
            try
            {
                var result = dAL.AddUpdateCryptoWalletDetail(model);
                if (result == true)
                {
                    var Addupdate = model.Id > 0 ? "Update " : "Add ";
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record " + Addupdate + "Successfully." };
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
