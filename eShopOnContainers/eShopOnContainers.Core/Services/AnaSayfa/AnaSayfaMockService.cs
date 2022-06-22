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
            //new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId01, /*PictureUri = "fake_product_01.png",*/ Name = ".NET Bot Blue Sweatshirt (M)", Price = 19},
            //new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId02, /*PictureUri = "fake_product_02.png",*/ Name = ".NET Bot Purple Sweatshirt (M)", Price = 19},
            //new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId03, /*PictureUri = "fake_product_03.png",*/ Name = ".NET Bot Black Sweatshirt (M)", Price = 19},
            //new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId04, /*PictureUri = "fake_product_04.png",*/ Name = ".NET Black Cupt", Price = 17},
            //new AnaSayfaItem { Id = Common.Common.MockAnaSayfaItemId05, /*PictureUri = "fake_product_05.png",*/ Name = "Azure Black Sweatshirt (M)", Price = 19}

            new AnaSayfaItem { Id = Common.Common.MockCatalogItemId01, PictureUri = "https://www.cilekbutik.net/cdn/1/300/500/images/urunler/62b2f803a231f-586036.jpeg", Name = "Oversize Kalıp Tişört", Price = 110},
            new AnaSayfaItem { Id = Common.Common.MockCatalogItemId02, PictureUri = "https://www.cilekbutik.net/cdn/1/300/500/images/urunler/62b2f7d3a46cb-441271.jpeg", Name = "Yeni Sezon Tişört", Price = 65},
            new AnaSayfaItem { Id = Common.Common.MockCatalogItemId03, PictureUri = "https://www.cilekbutik.net/cdn/1/300/500/images/urunler/62b2f769d0c84-321774.jpeg", Name = "Oversize Kalıp Tişört", Price = 85},
            new AnaSayfaItem { Id = Common.Common.MockCatalogItemId04, PictureUri = "https://www.cilekbutik.net/cdn/1/300/500/images/urunler/62ad7fd7dd8b7-329001.jpeg", Name = "Yeni Sezon Tişört", Price = 90},
            new AnaSayfaItem { Id = Common.Common.MockCatalogItemId05, PictureUri = "https://www.cilekbutik.net/cdn/1/300/500/images/urunler/62b0a8cf149cb-570616.jpeg", Name = "Nakış Detay Tişört", Price = 110}
        };

        public async Task<ObservableCollection<AnaSayfaItem>> GetAnaSayfaAsync()
        {
            await Task.Delay(10);

            return MockAnaSayfa;
        }
    }
}