using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class TransactionDAL
    {
        public bool AddTransaction(Transactiontable model)
        {
            bool success = false;
            if (model != null)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated($"Exec Transactiontable_SP  @userid={model.Userid}, @transactiondate={model.Transactiondate}, @paymentsource={model.Paymentsource}, @paymentsourceid={model.Paymentsourceid}, @paymentsourcecurrency={model.Paymentsourcecurrency}, @transactiontype={model.Transactiontype}, @transactionamount={model.Transactionamount}, @createddate={DateTime.Now},@createdbyid={model.Createdbyid}, @Flag={0}"
               );
                }
                success = true;
            }
            return success;
        }
    }
}
