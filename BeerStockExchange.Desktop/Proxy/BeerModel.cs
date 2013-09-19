using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Media;

namespace BeerStockExchange.Desktop.Proxy
{
    public class BeerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageSource Image { get; set; }
    }
}