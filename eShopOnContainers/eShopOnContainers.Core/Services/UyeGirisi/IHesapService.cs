﻿using eShopOnContainers.Core.Models.Token;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.UyeGirisi

{
    public interface IHesapService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);
    }
}