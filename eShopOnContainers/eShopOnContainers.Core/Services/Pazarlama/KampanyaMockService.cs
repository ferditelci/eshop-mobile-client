using eShopOnContainers.Core.Models.Pazarlama;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Services.Pazarlama
{
    public class KampanyaMockService : IKampanyaService
    {
        private readonly ObservableCollection<KampanyaItem> _mockKampanya = new ObservableCollection<KampanyaItem>
        {
            new KampanyaItem
            {
                Id = Common.Common.MockKampanyaId01,
                PictureUri = "fake_campaign_01.png",
                Name = ".NET Bot Black Hoodie 50% OFF",
                Description = "Campaign Description 1",
                From = DateTime.Now,
                To = DateTime.Now.AddDays(7)
            },

            new KampanyaItem
            {
                Id = Common.Common.MockKampanyaId02,
                PictureUri = "fake_campaign_02.png",
                Name = "Roslyn Red T-Shirt 3x2",
                Description = "Campaign Description 2",
                From = DateTime.Now.AddDays(-7),
                To = DateTime.Now.AddDays(14)
            }
        };

        public async Task<ObservableCollection<KampanyaItem>> GetAllKampanyalarAsync(string token)
        {
            await Task.Delay(10);
            return _mockKampanya;
        }

        public async Task<KampanyaItem> GetKampanyaByIdAsync(int kampanyaId, string token)
        {
            await Task.Delay(10);
            return _mockKampanya.SingleOrDefault(c => c.Id == kampanyaId);
        }
    }
}