using eShopOnContainers.Core.Models.AnaSayfa;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.AnaSayfa
{
    public interface IAnaSayfaService
    {
        Task<ObservableCollection<AnaSayfaItem>> GetAnaSayfaAsync();
    }
}
