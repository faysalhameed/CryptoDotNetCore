using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class CryptoLockDAL
    {
        public List<Cryptolocktable> GetList()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Cryptolocktables.FromSqlInterpolated($"Exec Cryptolocktable_SP @Flag={1}").ToList();
            }
        }
        public bool AddUpdateCryptoLock(Cryptolocktable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptolocktable_SP  @userid={model.Userid}, @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinlockamount={model.Coinlockamount},@lockstartdate={model.Lockstartdate},@lockenddate={model.Lockenddate}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                   );
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptolocktable_SP @ID={model.Id}  @userid={model.Userid}, @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinlockamount={model.Coinlockamount},@lockstartdate={model.Lockstartdate},@lockenddate={model.Lockenddate}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                          );
                    }

                }
                success = true;
            }
            return success;
        }

        public bool DeleteCryptoLock(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Cryptolocktable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
    }
}
