using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStockExchange.Domain
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetBeers();
        Beer GetBeer(int id);
    }
}
