namespace MachineServer.DTOs;

public class EmployeeNearbyDto
{
    
    public Guid UserId { get; set; } = Guid.Empty;

    public Guid EmployeeId { get; set; } = Guid.Empty;

    public string? EmployeeTitle { get; set; } = string.Empty;

    public string? EmployeeAddress { get; set; } = string.Empty;

    public int? EmployeeAge { get; set; } = int.MinValue;

    public double? EmployeeSalary { get; set; } = double.MinValue;
    public Guid LocationId { get; set; } = Guid.Empty;
    public double DistanceToReportLocationInMeters { get; set; } = double.MinValue;
}