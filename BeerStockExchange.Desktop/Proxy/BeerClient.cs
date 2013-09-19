using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Windows.Media.Imaging;

namespace BeerStockExchange.Desktop.Proxy
{
    public class BeerClient
    {
        private readonly string rootUrl;

        public BeerClient(string url)
        {
            this.rootUrl = url;
        }

        public async Task<IEnumerable<BeerModel>> GetBeers()
        {
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync(rootUrl + "/api/beer/");
            IEnumerable<BeerModel> beers = await response.Content.ReadAsAsync<IEnumerable<BeerModel>>();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/png"));

            foreach (BeerModel beer in beers)
            {
                response = await client.GetAsync(rootUrl + "/api/beer/" + beer.Id);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    byte[] data = await response.Content.ReadAsByteArrayAsync();

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(data);
                    image.EndInit();

                    beer.Image = image;
                }
            }

            return beers;
        }
    }
}
