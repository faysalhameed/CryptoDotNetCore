using Coinbase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace Coinbase.DAL
{
    public class CCProfileDAL
    {
        public List<Ccprofiletable> ProfileList(int id)
        {
            using (var db = new CryptocoinbaseDbContext())
            {
                return db.Ccprofiletables.FromSqlInterpolated($"Exec CCProfiletable_SP  @userid={id},@Flag={1}").ToList();
            }
        }
        public bool AddUpdateCCProfile(Ccprofiletable model)
        {
            bool success = false;
            if (model != null)
            {
                if (model.Id == 0)
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        StripeDAL stripe = new StripeDAL(); 
                        CreditCardModel credit = new CreditCardModel();
                        credit.Ccnumber = model.Ccnumber;
                        credit.Expirydate = model.Expirydate.ToString();
                        credit.CVV = model.Cvv;
                        var ProfileToken = stripe.GenerateCardToken(credit);
                        db.Database.ExecuteSqlInterpolated($"Exec CCProfiletable_SP  @userid={model.Userid}, @ccnumber={model.Ccnumber}, @expirydate={model.Expirydate}, @profiletoken={ProfileToken}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid},@cvv={model.Cvv}, @Flag={2}"
                   );
                    }

                }
                else
                {
                    using (var db = new CryptocoinbaseDbContext())
                    {
                        db.Database.ExecuteSqlInterpolated($"Exec CCProfiletable_SP @ID={model.Id}, @userid={model.Userid}, @ccnumber={model.Ccnumber}, @expirydate={model.Expirydate}, @profiletoken={model.Profiletoken}, @createddate={model.Createddate}, @modifieddate={model.Modifieddate}, @createdbyid={model.Createdbyid},@modifiedbyid={model.Modifiedbyid},@cvv={model.Cvv}, @Flag={3}"
                 
                   );
                    }

                }
                success = true;
            }
            return success;
        }

        public bool DeleteCCProfile(int ID)
        {
            bool success = false;
            if (ID > 0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    db.Database.ExecuteSqlInterpolated(
                        $"Exec CCProfiletable_SP  @ID={ID},@Flag={4}"
                    );
                }
                success = true;
            }
            return success;
        }
        public bool CheckCardExist(string ccNumber)
        {
            bool success = true;
            if (!string.IsNullOrEmpty(ccNumber))
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    var checkccNumber = db.Ccprofiletables.FromSqlInterpolated(
                          $"Exec CCProfiletable_SP  @ccnumber={ccNumber},@Flag={5}"
                      ).AsEnumerable().FirstOrDefault();
                    if (checkccNumber != null)
                    {
                        return success = false;
                    }
                }
            }

            return success;
        }

        public Ccprofiletable GetCreditCardByID(int ID)
        {
            if (ID>0)
            {
                using (var db = new CryptocoinbaseDbContext())
                {
                    var checkccNumber = db.Ccprofiletables.FromSqlInterpolated(
                          $"Exec CCProfiletable_SP  @ID={ID},@Flag={6}"
                      ).AsEnumerable().FirstOrDefault();
                    return checkccNumber;

                }
            }

            return null;
        }
        public string GetAccountID(string BankCode)
        {
            string Account_ID = string.Empty;
            var client = new RestClient("https://api.withmono.com/account/auth");
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("mono-sec-key", "test_sk_dw77lb53x27msalov5gy");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"code\":\""+ BankCode + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                JObject jsonData = JObject.Parse(response.Content);
                Account_ID = (string)jsonData["id"];
                return Account_ID;
            }
            else
            {
                Account_ID = response.ErrorMessage;
                return Account_ID;
            }
         
        }

        

        public bool AddmonoAccount(string BankCode,int Userid)
        {
            bool IsSuccess = false;
            try
            {
               var getAccountID = GetAccountID(BankCode);
                if (getAccountID != null)
                {
                    var client = new RestClient("https://api.withmono.com/accounts/"+ getAccountID);
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("accept", "application/json");
                    request.AddHeader("mono-sec-key", "test_sk_dw77lb53x27msalov5gy");
                    IRestResponse response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        JObject jsonData = JObject.Parse(response.Content);
                        var AccountDetail = jsonData["account"];
                        var AccountBVN = AccountDetail["bvn"];
                        var AccountNumber = AccountDetail["accountNumber"];

                        Ccprofiletable ccprofiletable = new Ccprofiletable();
                        ccprofiletable.Profiletoken = getAccountID;
                        ccprofiletable.Expirydate = DateTime.Now;
                        ccprofiletable.Createddate = DateTime.Now;
                        ccprofiletable.Modifieddate = DateTime.Now;
                        ccprofiletable.Ccnumber = AccountNumber.ToString();
                        ccprofiletable.Cvv = AccountBVN.ToString();
                        ccprofiletable.Userid = Userid;
                        ccprofiletable.Modifiedbyid = Userid;
                        ccprofiletable.Createdbyid = Userid;



                        using (var db = new CryptocoinbaseDbContext())
                        {

                            var checkAccount = db.Ccprofiletables.FromSqlInterpolated(
                        $"Exec CCProfiletable_SP  @ccnumber={AccountNumber.ToString()},@Flag={5}"
                    ).AsEnumerable().FirstOrDefault();
                            if (checkAccount != null&& checkAccount.Id>0)
                            {
                                db.Database.ExecuteSqlInterpolated($"Exec CCProfiletable_SP @ID={checkAccount.Id}, @userid={checkAccount.Userid}, @ccnumber={checkAccount.Ccnumber}, @expirydate={checkAccount.Expirydate}, @profiletoken={getAccountID}, @createddate={checkAccount.Createddate}, @modifieddate={ccprofiletable.Modifieddate}, @createdbyid={checkAccount.Createdbyid},@modifiedbyid={ccprofiletable.Modifiedbyid},@cvv={checkAccount.Cvv}, @Flag={3}"

);
                            }
                            else
                            {
                                db.Database.ExecuteSqlInterpolated($"Exec CCProfiletable_SP  @userid={Userid}, @ccnumber={AccountNumber.ToString()}, @expirydate={DateTime.Now}, @profiletoken={getAccountID}, @createddate={DateTime.Now}, @modifieddate={DateTime.Now}, @createdbyid={Userid},@modifiedbyid={Userid},@cvv={AccountBVN.ToString()}, @Flag={2}"
                   );
                            }

                        
                        }
                    }
                    else
                    {
                       
                    }
                }
                return IsSuccess;
            }
            catch(Exception ex)
            {
                return IsSuccess = false;
            }

        }
    }
}
