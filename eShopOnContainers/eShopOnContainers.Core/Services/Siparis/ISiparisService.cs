using eShopOnContainers.Core.Models.Basket;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Siparis
{
    public interface ISiparisService
    {
        Task CreateSiparisAsync(Models.Siparisler.Siparis newSiparis, string token);
        Task<ObservableCollection<Models.Siparisler.Siparis>> GetSiparislerAsync(string token);
        Task<Models.Siparisler.Siparis> GetSiparisAsync(int siparisId, string token);
        Task<bool> CancelSiparisAsync(int siparisId, string token);
        BasketCheckout MapSiparisToBasket(Models.Siparisler.Siparis siparis);
    }
}