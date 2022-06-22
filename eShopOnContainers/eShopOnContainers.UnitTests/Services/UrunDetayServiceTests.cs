using eShopOnContainers.Core.Services.UrunDetay;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class UrunDetayServiceTests

    {
        [Fact]
        public async Task GetFakeUrunMarkasiTest()
        {
            var urunDetayMockService = new UrunDetayMockService();
            var urunMarkasi = await urunDetayMockService.GetUrunMarkasiAsync();

            Assert.NotEmpty(urunMarkasi);
        }

        [Fact]
        public async Task GetFakeUrunTuruTest()
        {
            var urunDetayMockService = new UrunDetayMockService();
            var urunTuru = await urunDetayMockService.GetUrunTuruAsync();

            Assert.NotEmpty(urunTuru);
        }
    }
}