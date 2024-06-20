using MediatR;

using Microsoft.EntityFrameworkCore;

using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;
using StoreManagement.Domain.Services;

namespace StoreManagement.Application.Commands.Auth
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Accounts.Where(u => u.Username == request.Username).AnyAsync(cancellationToken))
            {
                throw new Exception("Username already exists.");
            }

            _commonService.CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);

            var account = new Account
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _unitOfWork.Accounts.AddAsync(account);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
