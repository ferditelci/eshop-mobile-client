using eShopOnContainers.Core.Models.User;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Kullanici

{
    public interface IKullaniciService

    {
        Task<UserInfo> GetUserInfoAsync(string authToken);
    }
}
