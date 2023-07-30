using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class CryptoWalletDetailDAL
    {
        public List<Cryptowalletdetailtable> GetList()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Cryptowalletdetailtables.FromSqlInterpolated($"Exec Cryptowalletdetailtable_SP @Flag={1}").ToList();
            }
        }
        public bool AddUpdateCryptoWalletDetail(Cryptowalletdetailtable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptowalletdetailtable_SP  @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinamount={model.Coinamount},@createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                   );
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptowalletdetailtable_SP @ID={model.Id}  @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinamount={model.Coinamount},@createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                    );
                    }

                }
                success = true;
            }
            return success;
        }
        public bool DeleteCryptoWalletDetail(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Cryptowalletdetailtable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
    }
}
