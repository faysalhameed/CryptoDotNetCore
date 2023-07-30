using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class CryptoWalletDAL
    {
        public List<Cryptowallettable> GetList(int UserID)
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Cryptowallettables.FromSqlInterpolated($"Exec Cryptowallettable_SP  @userid={UserID},@Flag={1}").ToList();
            }
        }
        public bool AddUpdateCryptoWallet(Cryptowallettable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptowallettable_SP  @userid={model.Userid}, @walletaddress={model.Walletaddress}, @publickey={model.Publickey}, @privatekey={model.Privatekey}, @token={model.Token},@createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                   );
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptowallettable_SP @ID={model.Id}, @userid={model.Userid}, @walletaddress={model.Walletaddress}, @publickey={model.Publickey}, @privatekey={model.Privatekey}, @token={model.Token},@createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                 );
                    }

                }
                success = true;
            }
            return success;
        }
        public bool DeleteCryptoWallet(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Cryptowallettable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
    }
}
