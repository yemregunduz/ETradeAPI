using Common.Security.Extensions;
using ETradeAPI.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor; 
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            bool isClaimRolesMatchedWithRequestRoles = roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
            if (isClaimRolesMatchedWithRequestRoles)
                throw new Exception(Messages.AuthorizationDenied);

            TResponse response = await next();
            return response;
        }
    }
}
