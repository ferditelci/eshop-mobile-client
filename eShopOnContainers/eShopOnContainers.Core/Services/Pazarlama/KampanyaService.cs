using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.Pazarlama;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.RequestProvider;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Pazarlama
{
    public class KampanyaService : IKampanyaService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

        private const string ApiUrlBase = "m/api/v1/campaigns";

        public KampanyaService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<KampanyaItem>> GetAllKampanyalarAsync(string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayMarketingEndpoint, $"{ApiUrlBase}/user");

            KampanyaRoot kampanya = await _requestProvider.GetAsync<KampanyaRoot>(uri, token);

            if (kampanya?.Data != null)
            {
                _fixUriService.FixKampanyaItemPictureUri(kampanya?.Data);
                return kampanya?.Data.ToObservableCollection();
            }

            return new ObservableCollection<KampanyaItem>();
        }

        public async Task<KampanyaItem> GetKampanyaByIdAsync(int kampanyaId, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayMarketingEndpoint, $"{ApiUrlBase}/{kampanyaId}");

            return await _requestProvider.GetAsync<KampanyaItem>(uri, token);
        }
    }
}