using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.User;
using eShopOnContainers.Core.Services.RequestProvider;
using System;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Kullanici
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IRequestProvider _requestProvider;

        public KullaniciService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<UserInfo> GetUserInfoAsync(string authToken)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.UserInfoEndpoint);

            var userInfo = await _requestProvider.GetAsync<UserInfo>(uri, authToken);
            return userInfo;
        }
    }
}