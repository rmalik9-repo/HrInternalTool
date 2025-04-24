using HrInternalTool.Application.Commands;
using HrInternalTool.Application.Queries;
using HrInternalTool.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrInternalTool.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EmployeesController(ISender sender) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await sender.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeesEntity employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeesEntity employee)
        {
            
            var result = await sender.Send(new UpdateEmployeeCommand(id, employee));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
