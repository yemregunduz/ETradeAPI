using Common.Application.BusinessRules;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using Common.Security.Dtos;
using Common.Security.Entities;
using Common.Security.Hashing;
using ETradeAPI.Application.Features.Authorizations.Rules;
using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Authorizations.Commands
{
    public class PasswordChangeCommand:IRequest<IDataResult<User>>
    {
        public UserForPasswordChangeDto UserForPasswordChangeDto { get; set; }
        public class PasswordChangeCommandHandler : IRequestHandler<PasswordChangeCommand, IDataResult<User>>
        {
            private readonly IUserReadRepository _userReadRepository;
            private readonly IUserWriteRepository _userWriteRepository;
            private readonly AuthorizationBusinessRules _authorizationBusinessRules;
            public PasswordChangeCommandHandler(IUserReadRepository userReadRepository, AuthorizationBusinessRules authorizationBusinessRules, IUserWriteRepository userWriteRepository)
            {
                _userReadRepository = userReadRepository;
                _userWriteRepository = userWriteRepository;
                _authorizationBusinessRules = authorizationBusinessRules;
            }
            public async Task<IDataResult<User>> Handle(PasswordChangeCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    _authorizationBusinessRules.ComparePreviousAndNewPassword(request.UserForPasswordChangeDto.NewPassword, request.UserForPasswordChangeDto.Password),
                    await _authorizationBusinessRules.CheckPreviousPassword(request.UserForPasswordChangeDto)
                    );

                if (result!=null)
                {
                    return new ErrorDataResult<User>(result.Message);
                }
                var userToUpdate = await _userReadRepository.GetSingleAsync(u => u.Email == request.UserForPasswordChangeDto.Email);
                HashingHelper.CreatePasswordHash(request.UserForPasswordChangeDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                userToUpdate.PasswordSalt = passwordSalt;
                userToUpdate.PasswordHash = passwordHash;
                var user = await _userWriteRepository.Update(userToUpdate);
                return new SuccessDataResult<User>(user, Messages.PasswordChanged);
            }
        }
    }
}
