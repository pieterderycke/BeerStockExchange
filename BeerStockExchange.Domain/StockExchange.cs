using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStockExchange.Domain
{
    public class StockExchange
    {
        private double growthRate;
        private Dictionary<string, BeerInfo> stock;

        public StockExchange()
        {
            this.stock = new Dictionary<string, BeerInfo>();
        }

        //public double BuyBeer(string beer, int quantity)
        //{
            
        //}
    }
}
