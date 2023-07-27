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
    [HttpPost("CreateEmployee")]
    public async Task<ActionResult<EmployeeDto>> CreateEmployeeAsync(Employee model)
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
    [HttpGet("GetEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
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
    [HttpGet("GetEmployee")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeAsync(Guid employeeId)
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
    [HttpPut("UpdateEmployee")]
    public async Task<ActionResult<EmployeeDto>> UpdateEmployeeAsync(Employee model)
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
    [HttpGet("GetNearbyEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetNearbyEmployeesAsync(Guid reportLocationId, double maxDistanceInMeters)
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
    /*[HttpPost("CreateEmployee")]
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
    [HttpGet("GetEmployees")]
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
    [HttpGet("GetEmployee")]
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
    [HttpPut("UpdateEmployee")]
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
    [HttpGet("GetNearbyEmployees")]
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
    }*/

}