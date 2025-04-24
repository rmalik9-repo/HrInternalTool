using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using HrInternalTool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Infrastructure.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly HrDataDBContext _context;

        public PerformanceReviewRepository(HrDataDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PerformanceReviewsEntity>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.PerformanceReviews.Where(r => r.EmployeeId == employeeId).ToListAsync();
        }
        
        public async Task<PerformanceReviewsEntity> AddPerformanceReviewAsync(PerformanceReviewsEntity review)
        {
            _context.PerformanceReviews.Add(review);

            await _context.SaveChangesAsync();
            return review;
        }
    }
}
