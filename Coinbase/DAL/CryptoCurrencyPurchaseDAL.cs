using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class CryptoCurrencyPurchaseDAL
    {
        public List<Cryptorecurringpurchasetable> GetList()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Cryptorecurringpurchasetables.FromSqlInterpolated($"Exec Cryptorecurringpurchasetable_SP @Flag={1}").ToList();
            }
        }
        public bool AddUpdateCryptoPurchase(Cryptorecurringpurchasetable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptorecurringpurchasetable_SP  @userid={model.Userid}, @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinamount={model.Coinamount},@ccprofileid={model.Ccprofileid},@recurringpurchasestartdate={model.Recurringpurchasestartdate},@recurringpurchaseenddate={model.Recurringpurchaseenddate},@recurringpurchasefrequency={model.Recurringpurchasefrequency}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                   );
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptorecurringpurchasetable_SP @ID={model.Id}  @userid={model.Userid}, @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinamount={model.Coinamount},@ccprofileid={model.Ccprofileid},@recurringpurchasestartdate={model.Recurringpurchasestartdate},@recurringpurchaseenddate={model.Recurringpurchaseenddate},@recurringpurchasefrequency={model.Recurringpurchasefrequency}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                 );
                    }

                }
                success = true;
            }
            return success;
        }

        public bool DeleteCryptoPurchase(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Cryptorecurringpurchasetable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
    }
}
