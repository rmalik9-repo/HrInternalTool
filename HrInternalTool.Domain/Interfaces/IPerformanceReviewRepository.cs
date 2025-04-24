using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Entities;

namespace HrInternalTool.Domain.Interfaces
{
    public interface IPerformanceReviewRepository
    {
        Task<IEnumerable<PerformanceReviewsEntity>> GetByEmployeeIdAsync(int employeeId);
        Task<PerformanceReviewsEntity> AddPerformanceReviewAsync(PerformanceReviewsEntity review);
    }
}
