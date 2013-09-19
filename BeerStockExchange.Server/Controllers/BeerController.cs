using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
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

        public HttpResponseMessage Get(int id)
        {
            Beer beer = beerRepository.GetBeer(id);

            if (!IsImageRequest())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new ObjectContent<BeerModel>(Mapper.Map(beer), new JsonMediaTypeFormatter());
                return response;
            }
            else
            {
                string imagePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + beer.ImageUrl);

                if (File.Exists(imagePath))
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response.Content = new StreamContent(new FileStream(imagePath, FileMode.Open, FileAccess.Read));
                    //response.Content = new StreamContent(new FileStream(@"c:\temp\duvel.png", FileMode.Open, FileAccess.Read));
                    return response;
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
        }

        private bool IsImageRequest()
        {
            return Request.Headers.Accept.Count > 0 && Request.Headers.Accept.First().MediaType == "application/png";
        }
    }
}