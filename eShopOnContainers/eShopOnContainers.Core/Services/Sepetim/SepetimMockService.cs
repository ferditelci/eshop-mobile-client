using eShopOnContainers.Core.Models.Sepetim;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace eShopOnContainers.Core.Services.Sepetim
{
    public class SepetimMockService : ISepetimService
    {
        public IEnumerable<SepetimItem> LocalSepetimItems { get; set; }

        private CustomerSepetim MockCustomSepetim = new CustomerSepetim
        {
            BuyerId = "9245fe4a-d402-451c-b9ed-9c1a04247482",
            Items = new List<SepetimItem>
                {
                    new SepetimItem { Id = "1", PictureUrl = "fake_product_01.png", ProductId = Common.Common.MockCatalogItemId01, ProductName = ".NET Bot Blue Sweatshirt (M)", Quantity = 1, UnitPrice = 19.50M },
                    new SepetimItem { Id = "2", PictureUrl = "fake_product_04.png", ProductId = Common.Common.MockCatalogItemId04, ProductName = ".NET Black Cup", Quantity = 1, UnitPrice = 17.00M }
                }
        };

        public async Task<CustomerSepetim> GetSepetimAsync(string guidUser, string token)
        {
            await Task.Delay(10);

            if (string.IsNullOrEmpty(guidUser) || string.IsNullOrEmpty(token))
            {
                return new CustomerSepetim();
            }

            return MockCustomSepetim;
        }

        public async Task<CustomerSepetim> UpdateSepetimAsync(CustomerSepetim customerSepetim, string token)
        {
            await Task.Delay(10);

            if (string.IsNullOrEmpty(token))
            {
                return new CustomerSepetim();
            }

            MockCustomSepetim = customerSepetim;

            return MockCustomSepetim;
        }

        public async Task ClearSepetimAsync(string guidUser, string token)
        {
            await Task.Delay(10);

            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            if (!string.IsNullOrEmpty(guidUser))
            {
                MockCustomSepetim.Items.Clear();

                LocalSepetimItems = null;
            }
        }

        public Task CheckoutAsync(SepetimCheckout sepetimCheckout, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return Task.FromResult(0);
            }

            if (sepetimCheckout != null)
            {
                MockCustomSepetim.Items.Clear();
            }

            return Task.FromResult(0);
        }
    }
}