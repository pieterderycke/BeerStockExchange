using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

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
            return await response.Content.ReadAsAsync<IEnumerable<BeerModel>>();
        }
    }
}
