using MachineServer.DataAccess.Repository.IRepository;
using MachineServer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MachineServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeRepo _employeeRepo;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepo employeeRepo)
    {
        _logger = logger;
        _employeeRepo = employeeRepo;
    }

    async Task<ActionResult<EmployeeDto>> CreateEmployeeAsync(Employee model)
    {
        try
        {
            var employee =  await _employeeRepo.CreateEmployeeAsync(model);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating an employee.");
            return StatusCode(500, $"An error occurred while adding employee: {ex.Message}");
        }
    }

    async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
    {   try
        {
            var employees = await _employeeRepo.GetEmployeesAsync();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting employees.");
            return StatusCode(500,$"Error occurred while getting employees.{ex.Message}");
        }
    }

    async Task<ActionResult<EmployeeDto>> GetEmployeeAsync(Guid employeeId)
    {
        try
        {
            var employee = await _employeeRepo.GetEmployeeAsync(employeeId);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting an employee.");
            return StatusCode(500,$"Error occurred while getting an employee.{ex.Message}");
        }
    }
    async Task<ActionResult<EmployeeDto>> UpdateEmployeeAsync(Employee model)
    {
        try
        {
            var employee =  await _employeeRepo.UpdateEmployeeAsync(model);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating an employee.");
            return StatusCode(500,$"Error occurred while updating an employee.{ex.Message}");
        }
    }

    async Task<ActionResult<IEnumerable<EmployeeNearbyDto>>> GetNearbyEmployeesAsync(Guid reportLocationId, double maxDistanceInMeters)
    {
        try
        {
            var employees = await _employeeRepo.GetNearbyEmployeesAsync(reportLocationId, maxDistanceInMeters);
            return Ok(employees);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting nearby employees.");
            return StatusCode(500,$"Error occurred while getting nearby employees.{ex.Message}");
        }
    }

}