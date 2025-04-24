using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Commands
{
    public record AddUserCommand(UsersEntity user) : IRequest<UsersEntity>;

    public class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, UsersEntity>
    {
        public async Task<UsersEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.RegisterAsync(request.user);
        }
    }
}
