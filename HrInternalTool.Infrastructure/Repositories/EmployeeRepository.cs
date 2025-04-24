using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using HrInternalTool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrDataDBContext _context;

        public EmployeeRepository(HrDataDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeesEntity>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeesEntity?> GetByIdAsync(int id)
        {
           return  await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<EmployeesEntity>  AddAsync(EmployeesEntity employee)
        {
             _context.Employees.Add(employee);
            
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeesEntity> UpdateAsync(int id, EmployeesEntity employeeEntity)
        {

            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee is not null)
            {
                employee.Name = employeeEntity.Name;
                employee.Email = employeeEntity.Email;
                employee.Department = employeeEntity.Department;
                employee.DateOfJoining = employeeEntity.DateOfJoining;
                employee.IsActive = employeeEntity.IsActive;

                await _context.SaveChangesAsync();

            }
            return employee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }

}
