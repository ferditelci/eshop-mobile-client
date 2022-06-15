using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.AnaSayfa;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Services.AnaSayfa
{
    public class AnaSayfaMockService : IAnaSayfaService
    {
        private ObservableCollection<AnaSayfaItem> MockAnaSayfa = new ObservableCollection<AnaSayfaItem>
        {
            new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId01, PictureUri = "fake_product_01.png", Name = ".NET Bot Blue Sweatshirt (M)", Price = 19},
            new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId02, PictureUri = "fake_product_02.png", Name = ".NET Bot Purple Sweatshirt (M)", Price = 19},
            new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId03, PictureUri = "fake_product_03.png", Name = ".NET Bot Black Sweatshirt (M)", Price = 19},
            new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId04, PictureUri = "fake_product_04.png", Name = ".NET Black Cupt", Price = 17},
            new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId05, PictureUri = "fake_product_05.png", Name = "Azure Black Sweatshirt (M)", Price = 19}
        };

        public async Task<ObservableCollection<AnaSayfaItem>> GetAnaSayfaAsync()
        {
            await Task.Delay(10);

            return MockAnaSayfa;
        }
    }
}