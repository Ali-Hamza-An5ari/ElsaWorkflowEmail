using MachineServer.DTOs;

namespace MachineServer.DataAccess.Repository.IRepository;

public interface IReportRepo
{
    Task<ReportDto> CreateReportAsync(Report model);    
    Task<IEnumerable<ReportDto>> GetReportsAsync();
    Task<ReportDto> UpdateReportAsync(Report model);    
    Task<ReportDto> GetReportAsync(Guid reportId);
}