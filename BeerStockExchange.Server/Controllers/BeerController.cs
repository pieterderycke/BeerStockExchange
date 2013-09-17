using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeerStockExchange.Domain;
using BeerStockExchange.Server.Models;
using BeerStockExchange.Server.Util;

namespace BeerStockExchange.Server.Controllers
{
    public class BeerController : ApiController
    {
        private readonly IBeerRepository beerRepository;

        public BeerController(IBeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }

        public IEnumerable<BeerModel> GetAll()
        {
            return Mapper.Map(beerRepository.GetBeers());
        }

        public BeerModel Get(int id)
        {
            return Mapper.Map(beerRepository.GetBeer(id));
        }
    }
}