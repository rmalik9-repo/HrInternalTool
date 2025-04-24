using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Commands
{
    public record DeleteEmployeeCommand(int employeeId) : IRequest<bool>;

    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteAsync(request.employeeId);
        }
    }
}
