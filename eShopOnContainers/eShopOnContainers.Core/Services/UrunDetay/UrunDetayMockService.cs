using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.UrunDetay;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Services.UrunDetay
{
    public class UrunDetayMockService : IUrunDetayService
    {
        private ObservableCollection<UrunMarkasi> MockUrunMarkasi = new ObservableCollection<UrunMarkasi>
        {
            new UrunMarkasi { Id = 1, Marka = "CilekButik" },
        };

        private ObservableCollection<UrunTuru> MockUrunTuru = new ObservableCollection<UrunTuru>
        {
            new UrunTuru { Id = 2, Tur = "T-Shirt" }
        };

        public async Task<ObservableCollection<UrunMarkasi>> GetUrunMarkasiAsync()
        {
            await Task.Delay(10);

            return MockUrunMarkasi;
        }

        public async Task<ObservableCollection<UrunTuru>> GetUrunTuruAsync()
        {
            await Task.Delay(10);

            return MockUrunTuru;
        }
    }
}