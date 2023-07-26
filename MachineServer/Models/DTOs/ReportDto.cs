namespace MachineServer.DTOs;

public class ReportDto
{
    public Guid ReportId { get; set; } = Guid.Empty;

    public DateOnly? ServiceRequestDate { get; set; } = DateOnly.MinValue;

    public DateOnly? ServiceWantedDate { get; set; } = DateOnly.MinValue;

    public Guid? TenantId { get; set; } = Guid.Empty;

    public string? Description { get; set; } = string.Empty;

    public int? LocationId { get; set; } = Int32.MinValue;

    public Guid? FixtureId { get; set; } = Guid.Empty;

    public int? ProblemId { get; set; } = Int32.MinValue;
}