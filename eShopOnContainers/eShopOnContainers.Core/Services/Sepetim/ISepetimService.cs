using eShopOnContainers.Core.Models.Sepetim;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Sepetim
{
    public interface ISepetimService
    {
        IEnumerable<SepetimItem> LocalSepetimItems { get; set; }
        Task<CustomerSepetim> GetSepetimAsync(string guidUser, string token);
        Task<CustomerSepetim> UpdateSepetimAsync(CustomerSepetim customerSepetim, string token);
        Task CheckoutAsync(SepetimCheckout sepetimCheckout, string token);
        Task ClearSepetimAsync(string guidUser, string token);
    }
}