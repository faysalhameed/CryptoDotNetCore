using Coinbase.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coinbase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        // GET: api/<SettingController>
        [HttpGet]
        public async Task<IActionResult> GetSettingList(int userID)
        {
            SettingsDAL dAL = new SettingsDAL();
            try
            {
                var result = dAL.GetSettingtables();
                var Response = new {StatusCode = HttpStatusCode.OK, Data = result};
                await Task.Delay(1);
                return Ok(Response);
            }
            catch(Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                await Task.Delay(1);
                return Ok(Response);
               
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> AddupdateSettings(Settingtable model)
        {
            SettingsDAL dAL = new SettingsDAL();
            try
            {
                var result = dAL.AddUpdateSettings(model);
                if(result == true)
                {
                    var Addupdate = model.Id > 0 ? "Update " : "Add ";
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record "+ Addupdate + "Successfully." };
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
      
        public async Task<IActionResult> DeleteSettings(int ID)
        {
            SettingsDAL dAL = new SettingsDAL();
            try
            {
                var result = dAL.DeleteSettings(ID);
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
                await Task.Delay(1);
                return Ok(Response);

            }

        }

        [HttpGet]
        public async Task<IActionResult> GetSettingInfo(int ID)
        {
            SettingsDAL dAL = new SettingsDAL();
            try
            {
                var result = dAL.GetSettingByID(ID);

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
