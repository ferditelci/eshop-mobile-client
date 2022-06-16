using System;
using System.Threading.Tasks;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Models.Sepetim;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Helpers;
using System.Collections.Generic;

namespace eShopOnContainers.Core.Services.Sepetim
{
    public class SepetimService : ISepetimService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

        private const string ApiUrlBase = "b/api/v1/basket";

        public IEnumerable<SepetimItem> LocalSepetimItems { get; set; }

        public SepetimService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<CustomerSepetim> GetSepetimAsync(string guidUser, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{guidUser}");

            CustomerSepetim sepetim;

            try
            {
                sepetim = await _requestProvider.GetAsync<CustomerSepetim>(uri, token);
            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound)
            {
                sepetim = null;
            }

            _fixUriService.FixSepetimItemPictureUri(sepetim?.Items);
            return sepetim;
        }

        public async Task<CustomerSepetim> UpdateSepetimAsync(CustomerSepetim customerSepetim, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, ApiUrlBase);

            var result = await _requestProvider.PostAsync(uri, customerSepetim, token);
            return result;
        }

        public async Task CheckoutAsync(SepetimCheckout sepetimCheckout, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/checkout");

            await _requestProvider.PostAsync(uri, sepetimCheckout, token);
        }

        public async Task ClearSepetimAsync(string guidUser, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{guidUser}");

            await _requestProvider.DeleteAsync(uri, token);

            LocalSepetimItems = null;
        }
    }
}