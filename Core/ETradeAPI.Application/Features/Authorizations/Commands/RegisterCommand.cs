using Common.Application.BusinessRules;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using Common.Security.Dtos;
using Common.Security.Entities;
using Common.Security.Hashing;
using Common.Security.Jwt;
using ETradeAPI.Application.Features.Authorizations.Dtos;
using ETradeAPI.Application.Features.Authorizations.Rules;
using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Application.Services.Auth;
using ETradeAPI.Domain.Constants;
using MediatR;

namespace ETradeAPI.Application.Features.Authorizations.Commands
{
    public class RegisterCommand:IRequest<IDataResult<RegisteredDto>>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IDataResult<RegisteredDto>>
        {
            private readonly IUserWriteRepository _userWriteRepository;
            private readonly IAuthService _authService;
            private readonly AuthorizationBusinessRules _authorizationBusinessRules;

            public RegisterCommandHandler(IUserWriteRepository userWriteRepository, IAuthService authService,AuthorizationBusinessRules authorizationBusinessRules)
            {
                _userWriteRepository = userWriteRepository;
                _authService = authService;
                _authorizationBusinessRules = authorizationBusinessRules;
            }
            public async Task<IDataResult<RegisteredDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                IResult result = BusinessRules.Run(await _authorizationBusinessRules.UserExist(request.UserForRegisterDto.Email));
                if (result!=null)
                {
                    return new ErrorDataResult<RegisteredDto>(result.Message);
                }
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
                User user = new ()
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                };
                User createdUser = await _userWriteRepository.AddAsync(user);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RegisteredDto registeredDto = new ()
                {
                    AccessToken = createdAccessToken
                };
                return new SuccessDataResult<RegisteredDto>(registeredDto,Messages.UserRegistered);
            }

        } 
    }
}
