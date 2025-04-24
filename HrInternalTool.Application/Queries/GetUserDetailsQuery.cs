using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Queries
{
    public record GetUserDetailQuery(UsersEntity user) : IRequest<UsersEntity>;

    public class GetUserDetailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserDetailQuery, UsersEntity>
    {
        public async Task<UsersEntity> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.AuthenticateAsync(request.user);
        }
    }
}
