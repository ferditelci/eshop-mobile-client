using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eShopOnContainers.Core.Models.AnaSayfa;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Extensions;
using System.Collections.Generic;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Helpers;
using Firebase.Database;
using Firebase.Database.Query;
namespace eShopOnContainers.Core.Services.AnaSayfa
{
    public class AnaSayfaService : IAnaSayfaService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

        private const string ApiUrlBase = "c/api/v1/catalog";

        public AnaSayfaService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<AnaSayfaItem>> GetAnaSayfaAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            AnaSayfaRoot anasayfa = await _requestProvider.GetAsync<AnaSayfaRoot>(uri);

            if (anasayfa?.Data != null)
            {
                _fixUriService.FixAnaSayfaItemPictureUri(anasayfa?.Data);
                return anasayfa?.Data.ToObservableCollection();
            }
            else
                return new ObservableCollection<AnaSayfaItem>();
        }

    }
}
