using eShopOnContainers.Core.Models.Pazarlama;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Pazarlama
{
    public interface IKampanyaService
    {
        Task<ObservableCollection<KampanyaItem>> GetAllKampanyalarAsync(string token);
        Task<KampanyaItem> GetKampanyaByIdAsync(int id, string token);
    }
}