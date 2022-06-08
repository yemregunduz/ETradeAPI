using ETradeAPI.Common.Security.Jwt;
using ETradeAPI.Domain.Entities.Identity;


namespace ETradeAPI.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
    }
}
