﻿using Coinbase.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Coinbase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CryptoloanController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            CryptoLoanDAL dAL = new CryptoLoanDAL();
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
        [HttpPost]
        public IActionResult AddupdateCryptoWallet(Cryptoloantable model)
        {
            CryptoLoanDAL dAL = new CryptoLoanDAL();
            try
            {
                var result = dAL.AddUpdateCryptoLoan(model);
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
        public IActionResult DeleteCryptoloan(int ID)
        {
            CryptoLoanDAL dAL = new CryptoLoanDAL();
            try
            {
                var result = dAL.DeleteCryptoLoan(ID);
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
    }
}
