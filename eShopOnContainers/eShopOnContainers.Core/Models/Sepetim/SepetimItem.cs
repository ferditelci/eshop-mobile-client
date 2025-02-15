﻿using System;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Models.Sepetim
{
    public class SepetimItem : BindableObject
    {
        private int _quantity;

        public string Id { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OldUnitPrice { get; set; }

        public bool HasNewPrice
        {
            get
            {
                return OldUnitPrice != 0.0m;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public string PictureUrl { get; set; }

        public decimal Total { get { return Quantity * UnitPrice; } }

        public override string ToString()
        {
            return String.Format("Product Id: {0}, Quantity: {1}", ProductId, Quantity);
        }
    }
}