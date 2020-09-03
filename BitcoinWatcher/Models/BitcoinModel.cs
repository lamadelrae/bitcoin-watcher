using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWatcher.Models
{
    public partial class BitcoinModel
    {
        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("chartName")]
        public string ChartName { get; set; }

        [JsonProperty("bpi")]
        public Bpi Bpi { get; set; }
    }

    public partial class Bpi
    {
        [JsonProperty("USD")]
        public Eur Usd { get; set; }

        [JsonProperty("GBP")]
        public Eur Gbp { get; set; }

        [JsonProperty("EUR")]
        public Eur Eur { get; set; }
    }

    public partial class Eur
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rate_float")]
        public double RateFloat { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("updatedISO")]
        public DateTimeOffset UpdatedIso { get; set; }

        [JsonProperty("updateduk")]
        public string Updateduk { get; set; }
    }
}
