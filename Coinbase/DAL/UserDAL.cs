using Microsoft.EntityFrameworkCore;

namespace Coinbase.DAL
{
    public class UserDAL
    {
        public List<Usertable> GetUsers()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Usertables.FromSqlInterpolated($"Exec Usertable_SP @Flag={1}").ToList();
            }
        }
        public bool AddUpdateUser(Usertable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Usertable_SP  @name={model.Name}, @age={model.Age}, @Address={model.Address}, @City={model.City}, @Country={model.Country}, @Emailaddress={model.Emailaddress}, @Phone={model.Phone},@Password={model.Password}, @Flag={2}");
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Usertable_SP @ID={model.Id}  ,@name={model.Name}, @age={model.Age}, @Address={model.Address}, @City={model.City}, @Country={model.Country}, @Emailaddress={model.Emailaddress}, @Phone={model.Phone},@Password={model.Password}, @Flag={3}");
                    }

                }
                success = true;
            }
            return success;
        }
        public bool DeleteUser(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Usertable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }

        public bool CheckEmailExist(string Email)
        {
            bool success = true;
            if (!string.IsNullOrEmpty(Email))
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                  var checkEmail =  db.Usertables.FromSqlInterpolated(
                        $"Exec Usertable_SP  @Emailaddress={Email},@Flag={5}"
                    ).AsEnumerable().FirstOrDefault();
                    if (checkEmail != null)
                    {
                      return  success = false;
                    }
                }
            }
                
            return success;
        }

        public Usertable CheckLogin(string email,string password)
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                var Check_Login = db.Usertables.FromSqlInterpolated($"Exec Usertable_SP @Emailaddress={email},@Password={password}, @Flag={6}").AsEnumerable().FirstOrDefault();
                return Check_Login;
            }
        }

        public Usertable GetUserByID(int ID)
        {
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    var checkUser= db.Usertables.FromSqlInterpolated(
                          $"Exec Usertable_SP  @ID={ID},@Flag={7}"
                      ).AsEnumerable().FirstOrDefault();
                    return checkUser;

                }
            }

            return null;
        }
    }
}
