using MachineServer.DTOs;

namespace MachineServer.DataAccess.Repository.IRepository;

public interface ILocationRepo
{
    Task<LocationDto> CreateLocationAsync(Location model);    
    Task<IEnumerable<LocationDto>> GetLocationsAsync();
    Task<LocationDto> UpdateLocationAsync(Location model);    
    Task<LocationDto> GetLocationAsync(Guid LocationId);
}