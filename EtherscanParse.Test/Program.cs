using Newtonsoft.Json;
using System;
using System.Globalization;

namespace EtherscanParse.Test
{
    public class Program
    {
        static void Main(string[] args) {


            var YOUR_TOKEN = "YourApiKeyToken";
            var TXID = "0xe9156fcd7ea1122bd97fd2cc58784b83e66385da41333753f0e1d584002aaf2c";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Test Start...");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\r\n-----------------------------------------\r\n");


            var service = new EtherscanParse.TrasactionAgent(YOUR_TOKEN);

            var info = service.GetTrasactionInfo(TXID);
            Console.WriteLine("Gas Limit:" + Convert.ToInt32(info.result.gas, 16).ToString());
            Console.WriteLine("Gas Price:" + ((decimal)Int64.Parse(info.result.gasPrice.Replace("0x", ""), NumberStyles.AllowHexSpecifier) / 1000000000000000000).ToString(""));
           
            Console.WriteLine("From:"+info.result.from);
            Console.WriteLine("To:" + info.result.to);

            Console.WriteLine("hash(TXID):" + info.result.hash);
            Console.WriteLine("value:" + ((decimal)Int64.Parse(info.result.value.Replace("0x", ""), NumberStyles.AllowHexSpecifier) / 1000000000000000000).ToString(""));
            Console.WriteLine("blockHash:" + info.result.blockHash);
            Console.WriteLine("blockNumber:" + Convert.ToInt32(info.result.blockNumber, 16).ToString());
            
            Console.WriteLine("\r\n-----------------------------------------\r\n");


            var TEST_WALLET_ADDRESS = "0xc2bd9ef5433d239d6a36029d78fffd18d59f1877";


            var brInfo= service.GetBlockrewardWalletInfo(Convert.ToInt32(info.result.blockNumber, 16).ToString(), TEST_WALLET_ADDRESS);

            Console.WriteLine("\r\n Wallet Data : \r\n");
            Console.WriteLine("\r\n-----------------------------------------");

            foreach (var wt in brInfo.result) {

                Console.WriteLine("Source :"+JsonConvert.SerializeObject(wt));
                Console.WriteLine("");
                Console.WriteLine("TimeStamp:"+ ConvertTimestampToDateTime(double.Parse(wt.timeStamp)).ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("Confirmations:" + wt.confirmations);
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--TEST END--");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ReadLine();
        }


         static DateTime ConvertTimestampToDateTime(double timestamp)
        {
           
            long unixTimeStampInTicks = (long)(timestamp * TimeSpan.TicksPerSecond);
            return new DateTime(new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }
    }
}
