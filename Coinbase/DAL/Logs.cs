using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class Logs
    {
        public bool Add_Logs(Logstable model)
        {
            bool success = false;
            if (model != null)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Logstables.Add(model);
                    db.SaveChanges();
                }
                    success = true;
            }
            return success;
        }

        public void MappedModelLogs(DateTime Logdate,string Logtype,string Message,string Apiname,string Methodname)
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                db.Database.ExecuteSqlInterpolated($"Exec Logstable_SP  @logdate={DateTime.Now.Date}, @logtype={Logtype}, @message={Message}, @apiname={Apiname}, @methodname ={Methodname}, @createddate={DateTime.Now.Date}, @Flag={2}");
            }
        }
    }
}
