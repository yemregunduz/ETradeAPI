using ETradeAPI.Application.Repositories.UserOperationClaimRepository;
using ETradeAPI.Application.Services.Auth;
using ETradeAPI.Application.Wrappers.Paging;
using ETradeAPI.Common.Security.Jwt;
using ETradeAPI.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly ITokenHelper _tokenHelper;
        public AuthService(IUserOperationClaimReadRepository userOperationClaimReadRepository, ITokenHelper tokenHelper)
        {
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _tokenHelper = tokenHelper;
        }
        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimReadRepository.GetListAsync(u => u.UserId == user.Id, include: u => u.Include(u => u.OperationClaim));
            List<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }
    }
}
