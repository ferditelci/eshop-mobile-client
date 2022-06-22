using eShopOnContainers.Core.Models.Catalog;
using eShopOnContainers.Core.Services.Catalog;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.UnitTests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using eShopOnContainers.Core.Services.UyeGirisi;

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
            var UyeGirisiViewModel = new UyeGirisiViewModel();

            Assert.NotNull(UyeGirisiViewModel.MockSignInCommand);
        }
    }
}
