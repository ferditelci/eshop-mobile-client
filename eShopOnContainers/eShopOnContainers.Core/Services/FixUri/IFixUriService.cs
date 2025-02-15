﻿using System.Collections.Generic;
using eShopOnContainers.Core.Models.AnaSayfa;
using eShopOnContainers.Core.Models.Basket;
using eShopOnContainers.Core.Models.Catalog;
using eShopOnContainers.Core.Models.Marketing;
using eShopOnContainers.Core.Models.Pazarlama;
using eShopOnContainers.Core.Models.Sepetim;

namespace eShopOnContainers.Core.Services.FixUri
{
    public interface IFixUriService
    {
        void FixCatalogItemPictureUri(IEnumerable<CatalogItem> catalogItems);
        void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
        void FixCampaignItemPictureUri(IEnumerable<CampaignItem> campaignItems);
        void FixAnaSayfaItemPictureUri(IEnumerable<AnaSayfaItem> anasayfaItems);
        void FixSepetimItemPictureUri(IEnumerable<SepetimItem> sepetimItems);
        void FixKampanyaItemPictureUri(IEnumerable<KampanyaItem> kampanyaItems);
    }
}
