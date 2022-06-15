using System.Collections.Generic;

namespace eShopOnContainers.Core.Models.AnaSayfa
{
    public class AnaSayfaRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<AnaSayfaItem> Data { get; set; }
    }
}
