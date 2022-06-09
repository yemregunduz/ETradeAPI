using Common.Application.BusinessRules;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using Common.Security.Dtos;
using Common.Security.Entities;
using Common.Security.Jwt;
using ETradeAPI.Application.Features.Authorizations.Rules;
using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Application.Services.Auth;
using ETradeAPI.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Authorizations.Commands
{
    public class LoginCommand:IRequest<IDataResult<AccessToken>>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, IDataResult<AccessToken>>
        {
            private readonly IUserReadRepository _userReadRepository;
            private readonly AuthorizationBusinessRules _authorizationBusinessRules;
            private readonly IAuthService _authService;
            public LoginCommandHandler(IUserReadRepository userReadRepository,  AuthorizationBusinessRules authorizationBusinessRules,IAuthService authService)
            {
                _userReadRepository = userReadRepository;
                _authorizationBusinessRules = authorizationBusinessRules;
                _authService = authService;
            }

            public async Task<IDataResult<AccessToken>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var userToCheck = await _userReadRepository.GetSingleAsync(u => u.Email == request.UserForLoginDto.Email);
                if (userToCheck== null)
                {
                    return new ErrorDataResult<AccessToken>(Messages.UserNotFound);
                }
                IResult result = BusinessRules.Run(
                    _authorizationBusinessRules.VerifyPasswordHash(request.UserForLoginDto,userToCheck),
                    _authorizationBusinessRules.CheckUserStatus(userToCheck.Status)
                    );
                if (result != null)
                {
                    return new ErrorDataResult<AccessToken>(result.Message);
                }
                var token = await _authService.CreateAccessToken(userToCheck);
                return new SuccessDataResult<AccessToken>(token, Messages.SuccessfulLogin);
            }
        }
    }
}
