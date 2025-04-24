using HrInternalTool.Application.Commands;
using HrInternalTool.Application.Queries;
using HrInternalTool.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrInternalTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewsController(ISender sender) : ControllerBase
    {
        [HttpGet("employees/{employeeId}/reviews")]
        public async Task<IActionResult> GetByEmployeeId(int employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            return Ok(result);
        }

        [HttpPost("reviews")]
        public async Task<IActionResult> AddPerformanceReview([FromBody] PerformanceReviewsEntity review)
        {
            var result = await sender.Send(new AddPerformanceReviewCommand(review));
            return Ok(result);
        }

    }
}
