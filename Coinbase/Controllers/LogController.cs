using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coinbase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        public List<Logstable> Get()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Logstables.ToList();
            }
        }
    }
}
