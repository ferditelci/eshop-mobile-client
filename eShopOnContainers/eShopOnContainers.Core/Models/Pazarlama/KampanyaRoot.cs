using System.Collections.Generic;

namespace eShopOnContainers.Core.Models.Pazarlama
{
    public class KampanyaRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<KampanyaItem> Data { get; set; }
    }
}