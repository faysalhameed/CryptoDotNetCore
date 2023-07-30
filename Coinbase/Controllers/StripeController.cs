using Coinbase.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Coinbase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StripeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSettingList()
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51HiJeRLjLXoDdI5bMW0Oj6Gdc79gamkRPdOyNfthe5IJfLPj5jYmbsKgATnBMrIHgDumre96uwJNJalMl1vRwAje008iKRutZF";
                string Token_CreditCard = "";
                var token_options_CreditCard = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = "4242424242424242",
                        ExpYear = "2024",
                        ExpMonth = "04",
                        Cvc = "123"
                    }
                };

                var token_service_CreditCard = new TokenService();
                Token stripeToken_CC = token_service_CreditCard.Create(token_options_CreditCard);
                Token_CreditCard = stripeToken_CC.Id;

                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt64(10 * 100), //$1 
                    Currency = "usd",
                    Source = Token_CreditCard,
                    Description = "Credit Card Charge"

                };
                //var options = new ChargeCreateOptions
                //{
                //    Amount = 200,
                //    Currency = "usd",
                //    Source = "tok_amex",
                //    Description = "My First Test Charge (created for API docs at https://www.stripe.com/docs/api)",
                //};
                var service = new ChargeService();
                var charge = service.Create(options);
                if (charge != null)
                {
                    if (charge.Status == "succeeded")
                    {
                        var ss = true;
                        var dsad = charge;
                    }
                }
                return Ok(Response);
            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                return Ok(Response);

            }

        }
    }
}
