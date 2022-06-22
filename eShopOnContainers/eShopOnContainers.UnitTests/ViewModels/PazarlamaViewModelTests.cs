using eShopOnContainers.Core.Models.Pazarlama;
using eShopOnContainers.Core.Services.Dependency;
using eShopOnContainers.Core.Services.Pazarlama;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xunit;

namespace eShopOnContainers.UnitTests.ViewModels
{
    public class PazarlamaViewModelTests
    {
        public PazarlamaViewModelTests()
        {
            ViewModelLocator.UpdateDependencies(true);
        }

        [Fact]
        public void GetKampanyalarIsNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
            var kampanyaViewModel = new KampanyaViewModel();
            Assert.Null(kampanyaViewModel.Kampanyalar);
        }

        [Fact]
        public async Task GetKampanyalarIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
            var kampanyaViewModel = new KampanyaViewModel();

            await kampanyaViewModel.InitializeAsync(null);

            Assert.NotNull(kampanyaViewModel.Kampanyalar);
        }

        [Fact]
        public void GetKampanyaDetaylarCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
            var kampanyaViewModel = new KampanyaViewModel();

            Assert.NotNull(kampanyaViewModel.GetKampanyaDetaylarCommand);
        }

        [Fact]
        public void GetKampanyaDetaylarByIdIsNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
            var kampanyaViewModel = new KampanyaDetaylarViewModel();
            Assert.Null(kampanyaViewModel.Kampanya);
        }

        [Fact]
        public async Task GetKampanyaDetaylarByIdIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
            var kampanyaDetaylarViewModel = new KampanyaDetaylarViewModel();

            await kampanyaDetaylarViewModel.InitializeAsync(new Dictionary<string, string> { { nameof(Kampanya.Id), "1" } });

            Assert.NotNull(kampanyaDetaylarViewModel.Kampanya);
        }
    }
}