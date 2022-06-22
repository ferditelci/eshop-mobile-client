using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class UyeGirisiViewModelTests
    {
        public UyeGirisiViewModelTests()
        {
            ViewModelLocator.UpdateDependencies(true);
        }

        [Fact]
        public void MockSignInCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.MockSignInCommand);
        }

        [Fact]
        public void SignInCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.SignInCommand);
        }

        [Fact]
        public void RegisterCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.RegisterCommand);
        }

        [Fact]
        public void NavigateCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.NavigateCommand);
        }

        [Fact]
        public void SettingsCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.SettingsCommand);
        }

        [Fact]
        public void ValidateUserNameCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.ValidateUserNameCommand);
        }

        [Fact]
        public void ValidatePasswordCommandIsNotNullTest()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(new MockSettingsService());
            var uyegirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(uyegirisiViewModel.ValidatePasswordCommand);
        }

    }
}
