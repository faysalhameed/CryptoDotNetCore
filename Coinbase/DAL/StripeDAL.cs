using Coinbase.Models;
using Stripe;

namespace Coinbase.DAL
{
    public class StripeDAL
    {
        public string GenerateCardToken(CreditCardModel model)
        {
            string Token_CreditCard = string.Empty;
            StripeConfiguration.ApiKey = "sk_test_51HiJeRLjLXoDdI5bMW0Oj6Gdc79gamkRPdOyNfthe5IJfLPj5jYmbsKgATnBMrIHgDumre96uwJNJalMl1vRwAje008iKRutZF";
            DateTime date = Convert.ToDateTime(model.Expirydate);
            var options = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = model.Ccnumber,
                    ExpMonth = date.Month.ToString(),
                    ExpYear = date.Year.ToString(),
                    Cvc = model.CVV,
                },
            };
            var token_service_CreditCard = new TokenService();
            Token stripeToken_CC = token_service_CreditCard.Create(options);
            Token_CreditCard = stripeToken_CC.Id;
     
           
            return Token_CreditCard;
        }
    }
}
