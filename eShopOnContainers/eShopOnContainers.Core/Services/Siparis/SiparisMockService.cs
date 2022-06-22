using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Basket;
using eShopOnContainers.Core.Models.Siparisler;
using eShopOnContainers.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Services.Siparis
{
    public class SiparisMockService : ISiparisService
    {
        private static DateTime MockExpirationDate = DateTime.Now.AddYears(5);

        private static Address MockAdress = new Address
        {
            Id = Guid.NewGuid(),
            City = "Seattle, WA",
            Street = "120 E 87th Street",
            CountryCode = "98122",
            Country = "United States",
            Latitude = 40.785091,
            Longitude = -73.968285,
            State = "Seattle",
            StateCode = "WA",
            ZipCode = "98101"
        };

        private static OdemeInfo MockOdemeInfo = new OdemeInfo
        {
            Id = Guid.NewGuid(),
            CardHolderName = "American Express",
            CardNumber = "378282246310005",
            CardType = new CardType
            {
                Id = 3,
                Name = "MasterCard"
            },
            Expiration = MockExpirationDate.ToString(),
            ExpirationMonth = MockExpirationDate.Month,
            ExpirationYear = MockExpirationDate.Year,
            SecurityNumber = "123"
        };

        private List<Models.Siparisler.Siparis> MockSiparisler = new List<Models.Siparisler.Siparis>()
        {
            new Models.Siparisler.Siparis { SiparisNumber = 1, SequenceNumber = 123, SiparisDate = DateTime.Now, SiparisStatus = SiparisStatus.Submitted, SiparisItems = MockSiparisItems, CardTypeId = MockOdemeInfo.CardType.Id, CardHolderName = MockOdemeInfo.CardHolderName, CardNumber = MockOdemeInfo.CardNumber, CardSecurityNumber = MockOdemeInfo.SecurityNumber, CardExpiration = new DateTime(MockOdemeInfo.ExpirationYear, MockOdemeInfo.ExpirationMonth, 1), ShippingCity = MockAdress.City, ShippingState = MockAdress.State, ShippingCountry = MockAdress.Country, ShippingStreet = MockAdress.Street, Total = 36.46M },
            new Models.Siparisler.Siparis { SiparisNumber = 2, SequenceNumber = 132, SiparisDate = DateTime.Now, SiparisStatus = SiparisStatus.Paid, SiparisItems = MockSiparisItems, CardTypeId = MockOdemeInfo.CardType.Id, CardHolderName = MockOdemeInfo.CardHolderName, CardNumber = MockOdemeInfo.CardNumber, CardSecurityNumber = MockOdemeInfo.SecurityNumber, CardExpiration = new DateTime(MockOdemeInfo.ExpirationYear, MockOdemeInfo.ExpirationMonth, 1), ShippingCity = MockAdress.City, ShippingState = MockAdress.State, ShippingCountry = MockAdress.Country, ShippingStreet = MockAdress.Street, Total = 36.46M },
            new Models.Siparisler.Siparis { SiparisNumber = 3, SequenceNumber = 231, SiparisDate = DateTime.Now, SiparisStatus = SiparisStatus.Cancelled, SiparisItems = MockSiparisItems, CardTypeId = MockOdemeInfo.CardType.Id, CardHolderName = MockOdemeInfo.CardHolderName, CardNumber = MockOdemeInfo.CardNumber, CardSecurityNumber = MockOdemeInfo.SecurityNumber, CardExpiration = new DateTime(MockOdemeInfo.ExpirationYear, MockOdemeInfo.ExpirationMonth, 1), ShippingCity = MockAdress.City, ShippingState = MockAdress.State, ShippingCountry = MockAdress.Country, ShippingStreet = MockAdress.Street, Total = 36.46M },
            new Models.Siparisler.Siparis { SiparisNumber = 4, SequenceNumber = 131, SiparisDate = DateTime.Now, SiparisStatus = SiparisStatus.Shipped, SiparisItems = MockSiparisItems, CardTypeId = MockOdemeInfo.CardType.Id, CardHolderName = MockOdemeInfo.CardHolderName, CardNumber = MockOdemeInfo.CardNumber, CardSecurityNumber = MockOdemeInfo.SecurityNumber, CardExpiration = new DateTime(MockOdemeInfo.ExpirationYear, MockOdemeInfo.ExpirationMonth, 1), ShippingCity = MockAdress.City, ShippingState = MockAdress.State, ShippingCountry = MockAdress.Country, ShippingStreet = MockAdress.Street, Total = 36.46M }
        };

        private static List<SiparisItem> MockSiparisItems = new List<SiparisItem>()
        {
            new SiparisItem { SiparisId = Guid.NewGuid(), ProductId = Common.Common.MockCatalogItemId01, Discount = 15, ProductName = ".NET Bot Blue Sweatshirt (M)", Quantity = 1, UnitPrice = 16.50M, PictureUrl = "fake_product_01.png" },
            new SiparisItem { SiparisId = Guid.NewGuid(), ProductId = Common.Common.MockCatalogItemId03, Discount = 0, ProductName = ".NET Bot Black Sweatshirt (M)", Quantity = 2, UnitPrice = 19.95M, PictureUrl = "fake_product_03.png" }
        };

        private static BasketCheckout MockBasketCheckout = new BasketCheckout()
        {
            CardExpiration = DateTime.UtcNow,
            CardHolderName = "FakeCardHolderName",
            CardNumber = "122333423224",
            CardSecurityNumber = "1234",
            CardTypeId = 1,
            City = "FakeCity",
            Country = "FakeCountry",
            ZipCode = "FakeZipCode",
            Street = "FakeStreet"
        };

        public async Task<ObservableCollection<Models.Siparisler.Siparis>> GetSiparislerAsync(string token)
        {
            await Task.Delay(10);

            if (!string.IsNullOrEmpty(token))
            {
                return MockSiparisler
                    .OrderByDescending(o => o.SiparisNumber)
                    .ToObservableCollection();
            }
            else
                return new ObservableCollection<Models.Siparisler.Siparis>();
        }

        public async Task<Models.Siparisler.Siparis> GetSiparisAsync(int siparisId, string token)
        {
            await Task.Delay(10);

            if (!string.IsNullOrEmpty(token))
                return MockSiparisler
                    .FirstOrDefault(o => o.SiparisNumber.Equals(siparisId));
            else
                return new Models.Siparisler.Siparis();
        }

        public async Task CreateSiparisAsync(Models.Siparisler.Siparis newSiparis, string token)
        {
            await Task.Delay(10);

            if (!string.IsNullOrEmpty(token))
            {
                MockSiparisler.Add(newSiparis);
            }
        }

        public BasketCheckout MapSiparisToBasket(Models.Siparisler.Siparis siparis)
        {
            return MockBasketCheckout;
        }

        public Task<bool> CancelSiparisAsync(int siparisId, string token)
        {
            return Task.FromResult(true);
        }
    }
}