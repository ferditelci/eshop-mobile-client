using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class AltGiyimViewModel : ContentView
    {
        public AltGiyimViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}