using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class CryptoLoanDAL
    {
        public List<Cryptoloantable> GetList()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Cryptoloantables.FromSqlInterpolated($"Exec Cryptoloantable_SP @Flag={1}").ToList();
            }
        }
        public bool AddUpdateCryptoLoan(Cryptoloantable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptoloantable_SP  @userid={model.Userid}, @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinamount={model.Coinamount},@loanstartdate={model.Loanstartdate},@loanenddate={model.Loanenddate},@loadfrequency={model.Loadfrequency},@ccprofileid={model.Ccprofileid}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                   );
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Cryptoloantable_SP @ID={model.Id} @userid={model.Userid}, @cryptowalletid={model.Cryptowalletid}, @coinname={model.Coinname}, @coinamount={model.Coinamount},@loanstartdate={model.Loanstartdate},@loanenddate={model.Loanenddate},@loadfrequency={model.Loadfrequency},@ccprofileid={model.Ccprofileid}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid}, @Flag={2}"
               );
                    }

                }
                success = true;
            }
            return success;
        }
        public bool DeleteCryptoLoan(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Cryptoloantable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
    }
}
