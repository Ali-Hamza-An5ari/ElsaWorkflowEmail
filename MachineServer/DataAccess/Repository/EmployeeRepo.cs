using MachineServer.DataAccess.Repository.IRepository;
using MachineServer.DTOs;
using Microsoft.EntityFrameworkCore;

using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace MachineServer.DataAccess.Repository;

public class EmployeeRepo: IEmployeeRepo
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(Employee model)
    {
        _context.Employees.Add(model);
        await _context.SaveChangesAsync();
        return MapEmployeeToDto(model);
    }


    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
    {
        var employees = await _context.Employees.ToListAsync();

        return employees.Select(e => MapEmployeeToDto(e));
    }

    public async Task<IEnumerable<EmployeeNearbyDto>> GetNearbyEmployeesAsync(Guid reportLocationId, double maxDistanceInMeters)
    {
        var reportLocation = await _context.Locations.FindAsync(reportLocationId);
        if (reportLocation == null)
        {
            throw new ArgumentException("Report location not found.");
        }

        var reportPoint = GeometryFactory.Default.CreatePoint(new Coordinate(reportLocation.Longitude, reportLocation.Latitude));

        var employees = await _context.Employees.ToListAsync();

        var nearbyEmployees = new List<EmployeeNearbyDto>();

        foreach (var employee in employees)
        {
            var employeeLocation = await _context.Locations.FindAsync(employee.LocationId);
            var employeePoint = GeometryFactory.Default.CreatePoint(new Coordinate(employeeLocation.Longitude, employeeLocation.Latitude));

            double distanceInMeters = employeePoint.Distance(reportPoint) * 1000; // Multiply by 1000 to convert to meters

            if (distanceInMeters <= maxDistanceInMeters)
            {
                nearbyEmployees.Add(new EmployeeNearbyDto()
                {
                    UserId = employee.UserId,
                    EmployeeId = employee.EmployeeId,
                    EmployeeTitle = employee.EmployeeTitle,
                    EmployeeAddress = employee.EmployeeAddress,
                    EmployeeAge = employee.EmployeeAge,
                    EmployeeSalary = employee.EmployeeSalary,
                    DistanceToReportLocationInMeters = distanceInMeters
                });
            }
        }

        return nearbyEmployees;
    }

    public async Task<EmployeeDto> UpdateEmployeeAsync(Employee model)
    {
        var existingEmployee = await _context.Employees.FindAsync(model.UserId);

        if (existingEmployee == null)
        {
            throw new ArgumentException("Employee with the specified UserId not found.");
        }

        existingEmployee.EmployeeTitle = model.EmployeeTitle;
        existingEmployee.EmployeeAddress = model.EmployeeAddress;
        existingEmployee.EmployeeAge = model.EmployeeAge;
        existingEmployee.EmployeeSalary = model.EmployeeSalary;

        await _context.SaveChangesAsync();
        return MapEmployeeToDto(existingEmployee);
    }


    public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);

        if (employee == null)
        {
            throw new ArgumentException("Employee with the specified employeeId not found.");
        }

        return MapEmployeeToDto(employee);
    }


    private EmployeeDto MapEmployeeToDto(Employee model)
    {
        return new EmployeeDto
        {
            UserId = model.UserId,
            EmployeeId = model.EmployeeId,
            EmployeeTitle = model.EmployeeTitle,
            EmployeeAddress = model.EmployeeAddress,
            EmployeeAge = model.EmployeeAge,
            EmployeeSalary = model.EmployeeSalary
        };
    }
}