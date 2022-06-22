using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.Basket;
using eShopOnContainers.Core.Models.Siparisler;
using eShopOnContainers.Core.Services.RequestProvider;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Siparis
{
    public class SiparisService : ISiparisService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "o/api/v1/orders";

        public SiparisService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task CreateSiparisAsync(Models.Siparisler.Siparis newSiparis, string token)
        {
            throw new Exception("Only available in Mock Services!");
        }

        public async Task<ObservableCollection<Models.Siparisler.Siparis>> GetSiparislerAsync(string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, ApiUrlBase);

            ObservableCollection<Models.Siparisler.Siparis> siparisler =
                await _requestProvider.GetAsync<ObservableCollection<Models.Siparisler.Siparis>>(uri, token);

            return siparisler;

        }

        public async Task<Models.Siparisler.Siparis> GetSiparisAsync(int siparisId, string token)
        {
            try
            {
                var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{siparisId}");

                Models.Siparisler.Siparis siparis =
                    await _requestProvider.GetAsync<Models.Siparisler.Siparis>(uri, token);

                return siparis;
            }
            catch
            {
                return new Models.Siparisler.Siparis();
            }
        }

        public BasketCheckout MapSiparisToBasket(Models.Siparisler.Siparis siparis)
        {
            return new BasketCheckout()
            {
                CardExpiration = siparis.CardExpiration,
                CardHolderName = siparis.CardHolderName,
                CardNumber = siparis.CardNumber,
                CardSecurityNumber = siparis.CardSecurityNumber,
                CardTypeId = siparis.CardTypeId,
                City = siparis.ShippingCity,
                State = siparis.ShippingState,
                Country = siparis.ShippingCountry,
                ZipCode = siparis.ShippingZipCode,
                Street = siparis.ShippingStreet
            };
        }

        public async Task<bool> CancelSiparisAsync(int siparisId, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/cancel");

            var cancelSiparisCommand = new CancelSiparisCommand(siparisId);

            var header = "x-requestid";

            try
            {
                await _requestProvider.PutAsync(uri, cancelSiparisCommand, token, header);
            }
            //If the status of the order has changed before to click cancel button, we will get
            //a BadRequest HttpStatus
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;
        }
    }
}