using eShopOnContainers.Core.Services.AnaSayfa;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class SepetServiceTests
    {
        [Fact]
        public async Task GetFakeSepetTest()
        {
            var anasayfaMockService = new AnaSayfaMockService();
            var result = await anasayfaMockService.GetAnaSayfaAsync();
            Assert.NotEmpty(result);
        }
    }
}