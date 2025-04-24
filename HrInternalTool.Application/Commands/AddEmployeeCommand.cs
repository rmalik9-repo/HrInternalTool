using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Commands
{
    public record AddEmployeeCommand(EmployeesEntity employee) : IRequest<EmployeesEntity>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<AddEmployeeCommand, EmployeesEntity>
    {
        public async Task<EmployeesEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.AddAsync(request.employee);
        }
    }
}
