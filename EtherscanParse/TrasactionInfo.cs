using System;
using System.Collections.Generic;
using System.Text;

namespace EtherscanParse
{
    //https://api.etherscan.io/api?module=account&action=txlist&address=0xc2bd9ef5433d239d6a36029d78fffd18d59f1877&startblock=6653217&endblock=6653217&page=1&offset=10&sort=asc&apikey=YourApiKeyToken

    public class TrasactionInfo
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public Result result { get; set; }
        public Error error { get; set; }


        public class Error
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class Result
        {
            public string blockHash { get; set; }
            public string blockNumber { get; set; }
            public string from { get; set; }
            public string gas { get; set; }
            public string gasPrice { get; set; }
            public string hash { get; set; }
            public string input { get; set; }
            public string nonce { get; set; }
            public string to { get; set; }
            public string transactionIndex { get; set; }
            public string value { get; set; }
            public string v { get; set; }
            public string r { get; set; }
            public string s { get; set; }
        }

    }

}
