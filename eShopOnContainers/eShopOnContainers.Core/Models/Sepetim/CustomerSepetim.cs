using System.Collections.Generic;

namespace eShopOnContainers.Core.Models.Sepetim
{
    public class CustomerSepetim
    {
        public string BuyerId { get; set; }
        public List<SepetimItem> Items { get; set; }
    }
}
