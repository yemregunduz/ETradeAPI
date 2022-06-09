using Common.Security.Entities;
using Common.Security.Jwt;

namespace ETradeAPI.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
    }
}
