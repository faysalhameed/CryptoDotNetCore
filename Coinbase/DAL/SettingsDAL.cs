using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Coinbase.DAL
{
    public class SettingsDAL
    {
        public List<Settingtable> GetSettingtables()
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Settingtables.FromSqlInterpolated($"Exec Settingtable_SP @Flag={1}").ToList();
            }
        }

        public bool AddUpdateSettings(Settingtable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        //var parameter = new List<SqlParameter>();
                        //parameter.Add(new SqlParameter("@Id", model.Id));
                        //parameter.Add(new SqlParameter("@settingkey", model.Settingkey));
                        //parameter.Add(new SqlParameter("@settingvalue", model.Settingvalue));
                        //parameter.Add(new SqlParameter("@description", model.Description));
                        //parameter.Add(new SqlParameter("@createddate", DateTime.Now.Date));
                        //parameter.Add(new SqlParameter("@modifieddate", DateTime.Now.Date));
                        //parameter.Add(new SqlParameter("@createdbyid", model.Createdbyid));
                        //parameter.Add(new SqlParameter("@modifiedbyid", model.Modifiedbyid));
                        //parameter.Add(new SqlParameter("@Flag", 2));
                        //db.Database.ExecuteSqlRaw(
                        //    "Exec Settingtable_SP  @Id, @settingkey, @settingvalue, @description, @createddate,@modifieddate,@createdbyid,@modifiedbyid,@Flag", parameter.ToArray()
                        //);
                        db.Database.ExecuteSqlInterpolated($"Exec Settingtable_SP  @settingkey={model.Settingkey}, @settingvalue={model.Settingvalue}, @description={model.Description}, @createddate={DateTime.Now.Date}, @modifieddate={DateTime.Now.Date}, @createdbyid={model.Createdbyid}, @modifiedbyid={model.Modifiedbyid}, @Flag={2}"
                   );
                    }
                  
                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec Settingtable_SP  @Id={model.Id}, @settingkey={model.Settingkey}, @settingvalue={model.Settingvalue}, @description={model.Description}, @createddate={model.Createddate}, @modifieddate={DateTime.Now}, @createdbyid={model.Createdbyid}, @modifiedbyid={model.Modifiedbyid}, @Flag={3}"
                   );
                        //var parameter = new List<SqlParameter>();
                        //parameter.Add(new SqlParameter("@Id", model.Id));
                        //parameter.Add(new SqlParameter("@settingkey", model.Settingkey));
                        //parameter.Add(new SqlParameter("@settingvalue", model.Settingvalue));
                        //parameter.Add(new SqlParameter("@description", model.Description));
                        //parameter.Add(new SqlParameter("@createddate", model.Createddate));
                        //parameter.Add(new SqlParameter("@modifieddate", DateTime.Now.Date));
                        //parameter.Add(new SqlParameter("@createdbyid", model.Createdbyid));
                        //parameter.Add(new SqlParameter("@modifiedbyid", model.Modifiedbyid));
                        //parameter.Add(new SqlParameter("@Flag", 3));
                        ////db.Settingtables.FromSqlRaw($"Exec Settingtable_SP  @Id={model.Id}, @settingkey={model.Settingkey}, @settingvalue={model.Settingvalue}, @description={model.Description}, @createddate={DateTime.Now.Date}, @modifieddate={model.Createddate}, @createdbyid={model.Createdbyid}, @modifiedbyid={model.Modifiedbyid}, @Flag={3}");
                        //db.Database.ExecuteSqlRaw(
                        //    "Exec Settingtable_SP  @Id, @settingkey, @settingvalue, @description, @createddate,@modifieddate,@createdbyid,@modifiedbyid,@Flag", parameter.ToArray()
                        //);
                    }
                        
                }
                success = true;
            }
            return success;
        }

        public bool DeleteSettings(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
               using (var db = new CryptocoinbaseDbContext())
               {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec Settingtable_SP  @Id={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
        public Settingtable GetSettingByID(int ID)
        {
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    var checkSetting = db.Settingtables.FromSqlInterpolated(
                          $"Exec Settingtable_SP  @ID={ID},@Flag={5}"
                      ).AsEnumerable().FirstOrDefault();
                    return checkSetting;

                }
            }

            return null;
        }
    }
}
