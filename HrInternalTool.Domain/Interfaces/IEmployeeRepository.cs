using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Entities;

namespace HrInternalTool.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeesEntity>> GetAllAsync();
        Task<EmployeesEntity?> GetByIdAsync(int id);
        Task<EmployeesEntity> AddAsync(EmployeesEntity employee);
        Task<EmployeesEntity> UpdateAsync(int employeeid, EmployeesEntity employee);
        Task<bool> DeleteAsync(int id);
    }
}
