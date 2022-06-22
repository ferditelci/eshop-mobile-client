using eShopOnContainers.Core;
using eShopOnContainers.Core.Services.Siparis;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class SiparislerServiceTests
    {
        [Fact]
        public async Task GetFakeSiparisTest()
        {
            var siparislerMockService = new SiparisMockService();
            var siparis = await siparislerMockService.GetSiparisAsync(1, GlobalSetting.Instance.AuthToken);

            Assert.NotNull(siparis);
        }

        [Fact]
        public async Task GetFakeSiparislerTest()
        {
            var siparislerMockService = new SiparisMockService();
            var result = await siparislerMockService.GetSiparislerAsync(GlobalSetting.Instance.AuthToken);

            Assert.NotEmpty(result);
        }
    }
}