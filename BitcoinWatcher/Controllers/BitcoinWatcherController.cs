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
using System.Windows.Threading;

namespace BitcoinWatcher.Controllers
{
    public class BitcoinWatcherController
    {
        Timer Timer { get; set; }

        private MainWindow Main { get; set; }

        public BitcoinWatcherController(MainWindow main)
        {
            Main = main;
        }

        public async Task GetBitcoinPrice()
        {
            BitcoinModel bitcoinObj = null;

            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync($@"https://api.coindesk.com/v1/bpi/currentprice.json");

                if (response.IsSuccessStatusCode)
                {
                    var Json = await response.Content.ReadAsStringAsync();

                    bitcoinObj = JsonConvert.DeserializeObject<BitcoinModel>(Json);
                }

                Main.Dispatcher.Invoke(() =>
                {
                    Main.BitcoinDataGrid.Items.Add(bitcoinObj);
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured : {ex}");

                return;
            }
        }

        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            await GetBitcoinPrice();
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
