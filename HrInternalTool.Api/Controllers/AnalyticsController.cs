using HrInternalTool.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly HrDataDBContext _context;

        public AnalyticsController(HrDataDBContext context)
        {
            _context = context;
        }

        [HttpGet("average-score-by-department")]
        public async Task<IActionResult> GetAverageScoreByDepartment()
        {
            var result = await _context.PerformanceReviews
                .Include(pr => pr.Employee)
                .GroupBy(pr => pr.Employee.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageScore = g.Average(pr => pr.Score)
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("top-5-performing-employees")]
        public async Task<IActionResult> GetTop5PerformingEmployees()
        {
            var result = await _context.PerformanceReviews
                .Include(pr => pr.Employee)
                .GroupBy(pr => new { pr.EmployeeId, pr.Employee.Name })
                .Select(g => new
                {
                    EmployeeId = g.Key.EmployeeId,
                    Name = g.Key.Name,
                    AverageScore = g.Average(pr => pr.Score)
                })
                .OrderByDescending(x => x.AverageScore)
                .Take(5)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("monthly-performance-trend")]
        public async Task<IActionResult> GetMonthlyPerformanceTrend()
        {
            var result = await _context.PerformanceReviews
                .GroupBy(pr => new { pr.ReviewDate.Year, pr.ReviewDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    AverageScore = g.Average(pr => pr.Score)
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToListAsync();

            return Ok(result);
        }
    }
}
