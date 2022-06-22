using eShopOnContainers.Core.Models.AnaSayfa;
using eShopOnContainers.Core.Services.AnaSayfa;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class AnaSayfaViewModelTests
    {
        public AnaSayfaViewModelTests()
        {
            ViewModelLocator.UpdateDependencies(true);
        }

        [Fact]
        public void AddAnaSayfaItemCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaMockService());
            var anasayfaViewModel = new AnaSayfaViewModel();

            Assert.NotNull(anasayfaViewModel.AddCatalogItemCommand);
        }

        [Fact]
        public void ProductsPropertyIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaMockService());
            var anasayfaViewModel = new AnaSayfaViewModel();

            Assert.Null(anasayfaViewModel.Products);
        }

        [Fact]
        public async Task ProductsPropertyIsNotNullAfterViewModelInitializationTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaMockService());
            var anasayfaViewModel = new AnaSayfaViewModel();

            await anasayfaViewModel.InitializeAsync(null);

            Assert.NotNull(anasayfaViewModel.Products);
        }

        [Fact]
        public async Task SettingProductsPropertyShouldRaisePropertyChanged()
        {
            bool invoked = false;

            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaMockService());
            var anasayfaViewModel = new AnaSayfaViewModel();

            anasayfaViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Products"))
                    invoked = true;
            };
            await anasayfaViewModel.InitializeAsync(null);

            Assert.True(invoked);
        }
    }
}
