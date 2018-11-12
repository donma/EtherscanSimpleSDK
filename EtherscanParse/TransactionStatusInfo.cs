using System;
using System.Collections.Generic;
using System.Text;

namespace EtherscanParse
{
   


    public class TransactionStatusInfo
    {
        public string status { get; set; }
        public string message { get; set; }
        public Result result { get; set; }
        public class Result
        {
            public string status { get; set; }
        }

        public Error error { get; set; }


        public class Error
        {
            public int code { get; set; }
            public string message { get; set; }
        }
    }
}
