using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eShopOnContainers.Core.Models.Siparisler
{
    public class Siparis
    {
        public Siparis()
        {
            SequenceNumber = 1;
            SiparisItems = new List<SiparisItem>();
        }

        public string BuyerId { get; set; }

        public int SequenceNumber { get; set; }

        [JsonProperty("date")]
        public DateTime SiparisDate { get; set; }

        [JsonProperty("status")]
        public SiparisStatus SiparisStatus { get; set; }

        [JsonProperty("city")]
        public string ShippingCity { get; set; }

        [JsonProperty("street")]
        public string ShippingStreet { get; set; }

        [JsonProperty("state")]
        public string ShippingState { get; set; }

        [JsonProperty("country")]
        public string ShippingCountry { get; set; }

        [JsonProperty("zipCode")]
        public string ShippingZipCode { get; set; }

        public int CardTypeId { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public DateTime CardExpiration { get; set; }

        public string CardSecurityNumber { get; set; }

        [JsonProperty("orderitems")]
        public List<SiparisItem> SiparisItems { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("ordernumber")]
        public int SiparisNumber { get; set; }
    }
}