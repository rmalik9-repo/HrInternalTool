using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using MediatR;

namespace HrInternalTool.Application.Queries
{
    public record GetEmployeeByIdQuery(int employeeId) : IRequest<EmployeesEntity>;
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeesEntity>
    {
        public async Task<EmployeesEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetByIdAsync(request.employeeId);
        }
    }
}
