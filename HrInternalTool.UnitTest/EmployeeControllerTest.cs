using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using HrInternalTool.Api.Controllers;
using HrInternalTool.Application.Commands;
using HrInternalTool.Application.Queries;
using HrInternalTool.Domain.Entities;

public class EmployeesControllerTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly EmployeesController _controller;

    public EmployeesControllerTests()
    {
        _mockSender = new Mock<ISender>();
        _controller = new EmployeesController(_mockSender.Object);
    }

    [Fact]
    public async Task GetAllEmployeesAsync_ReturnsOkResult_WithListOfEmployees()
    {
        // Arrange
        var employees = new List<EmployeesEntity> { new EmployeesEntity { Id = 1, Name = "John" } };
        _mockSender.Setup(s => s.Send(It.IsAny<GetAllEmployeesQuery>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(employees);

        // Act
        var result = await _controller.GetAllEmployeesAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(employees, okResult.Value);
    }

    [Fact]
    public async Task GetEmployeeById_ReturnsOkResult_WithEmployee()
    {
        var employee = new EmployeesEntity { Id = 1, Name = "John" };
        _mockSender.Setup(s => s.Send(It.Is<GetEmployeeByIdQuery>(q => q.employeeId == 1), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(employee);

        var result = await _controller.GetEmployeeById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(employee, okResult.Value);
    }

    [Fact]
    public async Task AddEmployeeAsync_ReturnsOkResult_WithCreatedEmployee()
    {
        var newEmployee = new EmployeesEntity { Id = 2, Name = "Jane" };
        _mockSender.Setup(s => s.Send(It.IsAny<AddEmployeeCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(newEmployee);

        var result = await _controller.AddEmployeeAsync(newEmployee);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(newEmployee, okResult.Value);
    }

    [Fact]
    public async Task UpdateEmployeeAsync_ReturnsOkResult_WithUpdatedEmployee()
    {
        var updatedEmployee = new EmployeesEntity { Id = 1, Name = "Updated" };
        _mockSender.Setup(s => s.Send(It.IsAny<UpdateEmployeeCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(updatedEmployee);

        var result = await _controller.UpdateEmployeeAsync(1, updatedEmployee);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(updatedEmployee, okResult.Value);
    }

    [Fact]
    public async Task DeleteEmployeeAsync_ReturnsOkResult_WithDeletedEmployeeResult()
    {
        var deletedResult = true;
        _mockSender.Setup(s => s.Send(It.IsAny<DeleteEmployeeCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(deletedResult);

        var result = await _controller.DeleteEmployeeAsync(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(deletedResult, okResult.Value);
    }
}
