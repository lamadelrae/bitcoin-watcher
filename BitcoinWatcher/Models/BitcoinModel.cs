using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWatcher.Models
{
    public class BitcoinModel
    {
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
