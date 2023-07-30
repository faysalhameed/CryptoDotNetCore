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
    public class CCProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList(int ID)
        {
            CCProfileDAL dAL = new CCProfileDAL();
            try
            {
                var result = dAL.ProfileList(ID);
               
                var Response = new { StatusCode = HttpStatusCode.OK, Data = result };
                 await Task.Delay(1);
                return  Ok(Response);
            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                await Task.Delay(1);
                return Ok(Response);

            }

        }
        [HttpPost]
        public async Task<IActionResult> AddupdateCCProfile(Ccprofiletable model)
        {
            CCProfileDAL dAL = new CCProfileDAL();
            try
            {

                bool CheckNumber = model.Id>0?true: dAL.CheckCardExist(model.Ccnumber);
                if (CheckNumber)
                {
                    var result = dAL.AddUpdateCCProfile(model);
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
                    var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Credit Card already Exist" };
                    await Task.Delay(1);
                    return Ok(Response);
                }
                

            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                return Ok(Response);

            }

        }
        public async Task<IActionResult> DeleteCCProfile(int ID)
        {
            CCProfileDAL dAL = new CCProfileDAL();
            try
            {
                var result = dAL.DeleteCCProfile(ID);
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
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                return Ok(Response);

            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCreditCardInfo(int ID)
        {
            CCProfileDAL dAL = new CCProfileDAL();
            try
            {
                var result = dAL.GetCreditCardByID(ID);

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
