using eShopOnContainers.Core.Services.AnaSayfa;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class AnaSayfaServiceTests
    {
        [Fact]
        public async Task GetFakeAnaSayfaTest()
        {
            var anasayfaMockService = new AnaSayfaMockService();
            var anasayfa = await anasayfaMockService.GetAnaSayfaAsync();

            Assert.NotEmpty(anasayfa);
        }
    }
}