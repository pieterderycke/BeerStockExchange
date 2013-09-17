using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerStockExchange.Domain;
using BeerStockExchange.Server.Models;

namespace BeerStockExchange.Server.Util
{
    public static class Mapper
    {
        public static IEnumerable<BeerModel> Map(IEnumerable<Beer> beers)
        {
            return beers.Select(b => Map(b));
        }

        public static BeerModel Map(Beer beer)
        {
            if (beer == null)
                return null;
            else
            {
                return new BeerModel() { Id = beer.Id, Name = beer.Name };
            }
        }
    }
}