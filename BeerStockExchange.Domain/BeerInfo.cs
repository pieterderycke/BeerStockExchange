using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStockExchange.Domain
{
    public class BeerInfo
    {
        public BeerInfo(string name, double minimumPrice)
        {
            this.Name = name;
            this.MinimumPrice = minimumPrice;
        }

        public string Name { get; private set; }
        public double MinimumPrice { get; private set; }
        public List<DateTime> History { get; private set; }
    }
}
