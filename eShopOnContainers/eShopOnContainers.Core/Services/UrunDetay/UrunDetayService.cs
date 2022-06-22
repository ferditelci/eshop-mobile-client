using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eShopOnContainers.Core.Models.UrunDetay;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Extensions;
using System.Collections.Generic;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Helpers;

namespace eShopOnContainers.Core.Services.UrunDetay
{
    public class UrunDetayService : IUrunDetayService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;
		
        private const string ApiUrlBase = "c/api/v1/catalog";

        public UrunDetayService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<UrunMarkasi>> GetUrunMarkasiAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogbrands");

            IEnumerable<UrunMarkasi> brands = await _requestProvider.GetAsync<IEnumerable<UrunMarkasi>>(uri);

            if (brands != null)
                return brands?.ToObservableCollection();
            else
                return new ObservableCollection<UrunMarkasi>();
        }

        public async Task<ObservableCollection<UrunTuru>> GetUrunTuruAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogtypes");

            IEnumerable<UrunTuru> types = await _requestProvider.GetAsync<IEnumerable<UrunTuru>>(uri);

            if (types != null)
                return types.ToObservableCollection();
            else
                return new ObservableCollection<UrunTuru>();
        }
    }
}
