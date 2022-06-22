using eShopOnContainers.Core.Models.UrunDetay;
using eShopOnContainers.Core.Services.UrunDetay;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class UrunDetayViewModelTests
    {
        public UrunDetayViewModelTests()
        {
            ViewModelLocator.UpdateDependencies(true);
        }

        [Fact]
        public void MarkalarIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            Assert.Null(urunDetayViewModel.Markalar);
        }

        [Fact]
        public void MarkaIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            Assert.Null(urunDetayViewModel.Marka);
        }

        [Fact]
        public void TurlerIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            Assert.Null(urunDetayViewModel.Turler);
        }

        [Fact]
        public void TurIsNullWhenViewModelInstantiatedTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            Assert.Null(urunDetayViewModel.Tur);
        }
  
        [Fact]
        public async Task MarkalarIsNotNullAfterViewModelInitializationTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            await urunDetayViewModel.InitializeAsync(null);

            Assert.NotNull(urunDetayViewModel.Markalar);
        }

        [Fact]
        public async Task TurlerIsNotNullAfterViewModelInitializationTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            await urunDetayViewModel.InitializeAsync(null);

            Assert.NotNull(urunDetayViewModel.Turler);
        }


        [Fact]
        public async Task SettingMarkalarShouldRaisePropertyChanged()
        {
            bool invoked = false;

            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            urunDetayViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Markalar"))
                    invoked = true;
            };
            await urunDetayViewModel.InitializeAsync(null);

            Assert.True(invoked);
        }

        [Fact]
        public async Task SettingTurlerShouldRaisePropertyChanged()
        {
            bool invoked = false;

            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());
            var urunDetayViewModel = new UrunDetayViewModel();

            urunDetayViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Turler"))
                    invoked = true;
            };
            await urunDetayViewModel.InitializeAsync(null);

            Assert.True(invoked);
        }
    }
}
