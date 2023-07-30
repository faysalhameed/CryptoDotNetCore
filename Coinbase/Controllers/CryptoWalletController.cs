using Coinbase.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Nethereum.Web3;
using Nethereum.Util;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;

namespace Coinbase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CryptoWalletController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList(int UserID)
        {
            CryptoWalletDAL dAL = new CryptoWalletDAL();
            try
            {
                var result = dAL.GetList(UserID);
                var Response = new { StatusCode = HttpStatusCode.OK, Data = result };
                await Task.Delay(1);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "No Record Found." };
                await Task.Delay(1);
                return Ok(Response);

            }

        }
        [HttpPost]
        public async Task<IActionResult> AddupdateCryptoWallet(Cryptowallettable model)
        {
            CryptoWalletDAL dAL = new CryptoWalletDAL();
            try
            {
                model = model.Id==0? CreateWallet(model.Userid):model;
                var result = dAL.AddUpdateCryptoWallet(model);
                if (result == true)
                {
                    var Addupdate = model.Id > 0 ? "Update " : "Add ";
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record " + Addupdate + "Successfully." };
                    await Task.Delay(1);
                    return Ok(Response);
                }
                else
                {
                    var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Please Try Again" };
                    return Ok(Response);
                }

            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                await Task.Delay(1);
                return Ok(Response);

            }

        }
        public IActionResult DeleteCryptoWallet(int ID)
        {
            CryptoWalletDAL dAL = new CryptoWalletDAL();
            try
            {
                var result = dAL.DeleteCryptoWallet(ID);
                if (result == true)
                {
                    var Response = new { StatusCode = HttpStatusCode.OK, Data = "Record Delete Successfully." };
                    return Ok(Response);
                }
                else
                {
                    var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = "Please Try Again" };
                    return Ok(Response);
                }

            }
            catch (Exception ex)
            {
                var Response = new { StatusCode = HttpStatusCode.BadRequest, Data = ex.Message };
                return Ok(Response);

            }

        }

        public Cryptowallettable CreateWallet(int userid)
        {
            try
            {
                // Generate a new Ethereum key pair
                var ecKey = EthECKey.GenerateKey();

                // Retrieve the private key
                var privateKey = ecKey.GetPrivateKey();

                // Retrieve the public key
                var publicKey = ecKey.GetPubKey().ToHex();

                // Generate the Ethereum address from the public key
                var address = new AddressUtil().ConvertToChecksumAddress(ecKey.GetPublicAddress());

                // Retrieve the chain ID
                //var chainId = GetChainId();

                var result = new
                {
                    PrivateKey = privateKey,
                    PublicKey = publicKey,
                    Address = address,
                };


                return new Cryptowallettable() {
                Id=0,
                Walletaddress= address,
                Privatekey = privateKey,
                Publickey= publicKey,
                Userid= userid,
                Modifieddate= DateTime.Now,
                Createddate= DateTime.Now,
                Createdbyid =userid,
                Modifiedbyid=userid,
                Token="",
                };
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
        private int GetChainId()
        {
            try
            {
                var web3 = new Web3();
                var networkId = web3.Net.Version.SendRequestAsync().Result;
                return int.Parse(networkId);
            }
            catch(Exception ex)
            {

                return-1;
            }
            
        }
        private string ChainIdToToken(int chainId)
        {
            switch (chainId)
            {
                case 1:
                    return "ETH";  // Ethereum mainnet
                case 3:
                    return "ROPSTEN";  // Ropsten testnet
                // Add more cases for other chain IDs if needed
                default:
                    return "UNKNOWN";
            }
        }
    }
}
