using eShopOnContainers.Core;
using eShopOnContainers.Core.Models.Siparisler;
using eShopOnContainers.Core.Services.Siparis;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class SiparisViewModelTests
    {
        public SiparisViewModelTests()
        {
            ViewModelLocator.UpdateDependencies(true);
        }

        [Fact]
        public void SiparisPropertyIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<ISiparisService>(new SiparisMockService());
            var siparisViewModel = new SiparisDetayViewModel();

            Assert.Null(siparisViewModel.Siparis);
        }

        [Fact]
        public async Task SiparisPropertyIsNotNullAfterViewModelInitializationTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var siparisService = new SiparisMockService();
            Xamarin.Forms.DependencyService.RegisterSingleton<ISiparisService>(siparisService);
            var siparisViewModel = new SiparisDetayViewModel();

            var siparis = await siparisService.GetSiparisAsync(1, GlobalSetting.Instance.AuthToken);
            await siparisViewModel.InitializeAsync(new Dictionary<string, string> { { nameof(Siparis.SiparisNumber), siparis.SiparisNumber.ToString() } });

            Assert.NotNull(siparisViewModel.Siparis);
        }

        [Fact]
        public async Task SettingSiparisPropertyShouldRaisePropertyChanged()
        {
            bool invoked = false;
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var siparisService = new SiparisMockService();
            Xamarin.Forms.DependencyService.RegisterSingleton<ISiparisService>(siparisService);
            var siparisViewModel = new SiparisDetayViewModel();

            siparisViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Siparis"))
                    invoked = true;
            };
            var siparis = await siparisService.GetSiparisAsync(1, GlobalSetting.Instance.AuthToken);
            await siparisViewModel.InitializeAsync(new Dictionary<string, string> { { nameof(Siparis.SiparisNumber), siparis.SiparisNumber.ToString() } });

            Assert.True(invoked);
        }
    }
}