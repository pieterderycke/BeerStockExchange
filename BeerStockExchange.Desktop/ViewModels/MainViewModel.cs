using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BeerStockExchange.Desktop.Proxy;
using GalaSoft.MvvmLight;

namespace BeerStockExchange.Desktop.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.Beers = new ObservableCollection<BeerModel>();
            LoadData();
        }

        public ObservableCollection<BeerModel> Beers { get; private set; }

        private async Task LoadData()
        {
            BeerClient client = new BeerClient("http://localhost:35993/");
            IEnumerable<BeerModel> beers = await client.GetBeers();

            foreach (BeerModel beer in beers)
            {
                this.Beers.Add(beer);
            }
        }
    }
}