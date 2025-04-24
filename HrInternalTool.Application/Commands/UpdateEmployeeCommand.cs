using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Commands
{
    public record UpdateEmployeeCommand(int employeeId, EmployeesEntity employee) : IRequest<EmployeesEntity>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEmployeeCommand, EmployeesEntity>
    {
        public async Task<EmployeesEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateAsync(request.employeeId, request.employee);
        }
    }
}
