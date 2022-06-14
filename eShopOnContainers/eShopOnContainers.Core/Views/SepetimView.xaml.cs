using eShopOnContainers.Core.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Views
{
    public partial class SepetimView : ContentPage
    {
        private bool _animate;

        public SepetimView()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            _animate = false;
        }



        private async Task AnimateItem(View uiElement, uint duration)
        {
            try
            {
                while (_animate)
                {
					await uiElement.ScaleTo(1.05, duration, Easing.SinInOut);
					await Task.WhenAll(
						uiElement.FadeTo(1, duration, Easing.SinInOut),
						uiElement.LayoutTo(new Rectangle(new Point(0, 0), new Size(uiElement.Width, uiElement.Height))),
						uiElement.FadeTo(.9, duration, Easing.SinInOut),
						uiElement.ScaleTo(1.15, duration, Easing.SinInOut)
					);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}