﻿using Newtonsoft.Json;

namespace eShopOnContainers.Core.Models.AnaSayfa
{
    public class AnaSayfaItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PictureUri { get; set; }
        [JsonIgnore]
        public string Key { get; set; }
    }
}