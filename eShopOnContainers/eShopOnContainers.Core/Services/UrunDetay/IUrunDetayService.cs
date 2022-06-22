using eShopOnContainers.Core.Models.UrunDetay;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.UrunDetay
{
    public interface IUrunDetayService
    {
        Task<ObservableCollection<UrunMarkasi>> GetUrunMarkasiAsync();
        Task<ObservableCollection<UrunTuru>> GetUrunTuruAsync();
    }
}
