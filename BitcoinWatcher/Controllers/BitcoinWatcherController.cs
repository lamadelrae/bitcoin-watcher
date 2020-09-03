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
using System.Windows;
using System.Timers;

namespace BitcoinWatcher.Controllers
{
    public class BitcoinWatcherController
    {
        Timer Timer { get; set; }
        public MainWindow Main { get; set; }

        public async Task GetBitcoinPrice()
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

                Main.BitcoinDataGrid.Items.Add(Bitcoin);
            }
            catch (Exception Exc)
            {
                MessageBox.Show($"An error occured : {Exc}");

                return;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GetBitcoinPrice();
        }

        public void SetTimer()
        {
            Timer = new Timer(2000);

            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }
    }
}
