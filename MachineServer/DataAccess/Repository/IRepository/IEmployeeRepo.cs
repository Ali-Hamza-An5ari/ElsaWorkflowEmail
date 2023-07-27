using MachineServer.DTOs;

namespace MachineServer.DataAccess.Repository.IRepository;

public interface IEmployeeRepo
{
    Task<EmployeeDto> CreateEmployeeAsync(Employee model);    
    Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    Task<EmployeeDto> GetEmployeeAsync(Guid employeeId);
    Task<IEnumerable<EmployeeNearbyDto>> GetNearbyEmployeesAsync(Guid reportLocationId, double maxDistanceInMeters);
    Task<EmployeeDto> UpdateEmployeeAsync(Employee model);    
}