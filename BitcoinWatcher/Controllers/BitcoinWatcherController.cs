using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using BitcoinWatcher.Models;
using Newtonsoft.Json;

namespace BitcoinWatcher.Controllers
{
    public class BitcoinWatcherController
    {

        public async Task<BitcoinModel> GetBitcoinPrice()
        {
            BitcoinModel Bitcoin = null;

            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync($@"https://api.coindesk.com/v1/bpi/currentprice.json");

                if (response.IsSuccessStatusCode)
                {
                    var Json = await response.Content.ReadAsStringAsync();

                    Bitcoin = JsonConvert.DeserializeObject<BitcoinModel>(Json);
                }

                return Bitcoin;
            }
            catch (Exception)
            {
                return Bitcoin;
            }

        }
    }
}
