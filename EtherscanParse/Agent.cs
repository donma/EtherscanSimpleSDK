using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace EtherscanParse
{
    public class TrasactionAgent
    {

        private string Token { get; set; }

        public TrasactionAgent(string token)
        {
            Token = token;
        }

        public BlockrewardInfo GetBlockrewardWalletInfo(string blockNumber, string wallet)
        {


            if (string.IsNullOrEmpty(blockNumber))
            {
                throw new Exception("Null blockNumber");
            }
            if (string.IsNullOrEmpty(wallet))
            {
                throw new Exception("Null wallet");
            }

            var url = "https://api.etherscan.io/api?module=account&action=txlist&address=" + wallet + "&startblock=" + blockNumber + "&endblock=" + blockNumber + "&page=1&offset=9999&sort=asc&apikey=" + Token;

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;


                var r = JsonConvert.DeserializeObject<BlockrewardInfo>(res);
                if (r.error != null)
                {
                    throw new Exception(r.error.message);
                }
                else
                {
                    return r;

                }
            }

        }

        public TrasactionInfo GetTrasactionInfo(string txid)
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new Exception("Null Token");
            }
            if (string.IsNullOrEmpty(txid))
            {
                throw new Exception("Null txid");
            }
            using (HttpClient client = new HttpClient())
            {
                //https://api.etherscan.io/api?module=proxy&action=eth_getTransactionByHash&txhash=0x58d6ac3734ce06cb1a84f54fd1ab86658168a6e7ecdbe2d16638a4e2459ac35b&apikey=YourApiKeyToken
                HttpResponseMessage response = client.GetAsync("https://api.etherscan.io/api?module=proxy&action=eth_getTransactionByHash&txhash=" + txid + "&apikey=" + Token).Result;

                var res = response.Content.ReadAsStringAsync().Result;


                var r = JsonConvert.DeserializeObject<TrasactionInfo>(res);

                if (r.error != null)
                {
                    throw new Exception(r.error.message);
                }
                else
                {
                    return r;

                }
            }

        }


    }
}
