using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerStockExchange.Domain;

namespace BeerStockExchange.DataLayer
{
    public class EntityFrameworkBeerRepository : IBeerRepository
    {
        public IEnumerable<Domain.Beer> GetBeers()
        {
            using (BeerContainer db = new BeerContainer())
            {
                return db.Beers.Select(b => new Domain.Beer() { Id = b.Id, Name = b.Name, ImageUrl = b.Photo }).ToList();
            }
        }

        public Domain.Beer GetBeer(int id)
        {
            using (BeerContainer db = new BeerContainer())
            {
                Beer dbBeer = db.Beers.SingleOrDefault(b => b.Id == id);
                return (dbBeer != null) ? new Domain.Beer() { Id = dbBeer.Id, Name = dbBeer.Name, ImageUrl = dbBeer.Photo } : null;
            }
        }
    }
}
