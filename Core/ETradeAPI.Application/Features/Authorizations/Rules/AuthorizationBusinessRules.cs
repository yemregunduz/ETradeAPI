using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using Common.Security.Dtos;
using Common.Security.Entities;
using Common.Security.Hashing;
using ETradeAPI.Application.Features.Authorizations.Commands;
using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Domain.Constants;
using MediatR;

namespace ETradeAPI.Application.Features.Authorizations.Rules
{
    public class AuthorizationBusinessRules
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMediator _mediator;
        public AuthorizationBusinessRules(IUserReadRepository userReadRepository, IMediator mediator)
        {
            _userReadRepository = userReadRepository;
            _mediator = mediator;
        }
        #region RegisterRules
        public async Task<IResult> UserExist(string email)
        {
            var result = await _userReadRepository.GetSingleAsync(u => u.Email == email);
            if (result != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);

            }
            return new SuccessResult();
        }
        #endregion
        #region LoginRules
        public IResult VerifyPasswordHash(UserForLoginDto userForLoginDto,User user)
        {
            
            var result = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!result)
            {
                return  new ErrorResult(Messages.PasswordError);
            }
            return new SuccessResult();
        }

        public IResult CheckUserStatus(bool status)
        {
            if (!status)
            {
                return new ErrorResult(Messages.UserStatusIsInactive);
            }
            return new SuccessResult();
        }
        #endregion
        #region PasswordChangeRules
        public IResult ComparePreviousAndNewPassword(string newPassword,string previousPassword)
        {
            if (newPassword == previousPassword)
            {
                return new ErrorResult(Messages.SamePasswordError);
            }
            return new SuccessResult();
        }
        public async Task<IResult> CheckPreviousPassword(UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto };
            var result =await _mediator.Send(loginCommand);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
