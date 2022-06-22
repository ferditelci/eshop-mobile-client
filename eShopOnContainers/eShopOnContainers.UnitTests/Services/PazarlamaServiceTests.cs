using eShopOnContainers.Core;
using eShopOnContainers.Core.Services.Pazarlama;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests.Services
{
    public class PazarlamaServiceTests
    {
        [Fact]
        public async Task GetFakeKampanyaTest()
        {
            var kampanyaMockService = new KampanyaMockService();
            var order = await kampanyaMockService.GetKampanyaByIdAsync(1, GlobalSetting.Instance.AuthToken);

            Assert.NotNull(order);
        }

        [Fact]
        public async Task GetFakeKampanyalarTest()
        {
            var kampanyaMockService = new KampanyaMockService();
            var result = await kampanyaMockService.GetAllKampanyalarAsync(GlobalSetting.Instance.AuthToken);

            Assert.NotEmpty(result);
        }
    }
}