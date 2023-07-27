namespace MachineServer.DTOs;

public class LocationDto
{
    public Guid LocationId { get; set; } = Guid.Empty;
    public double Longitude { get; set; } = double.MinValue;
    public double Latitude { get; set; } = double.MinValue;
    
    public string ProblemOfLocation { get; set; } = string.Empty;
}