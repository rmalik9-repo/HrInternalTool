using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Entities;

namespace HrInternalTool.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UsersEntity?> AuthenticateAsync(UsersEntity user);
        Task<UsersEntity> RegisterAsync(UsersEntity dto);
    }
}
