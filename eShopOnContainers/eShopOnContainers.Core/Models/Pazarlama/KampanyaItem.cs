﻿using System;

namespace eShopOnContainers.Core.Models.Pazarlama
{
    public class KampanyaItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string PictureUri { get; set; }

        public string DetailsUri { get; set; }
    }
}