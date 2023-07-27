using MachineServer.DataAccess.Repository.IRepository;
using MachineServer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MachineServer.DataAccess.Repository;

public class ReportRepo: IReportRepo
{
    private readonly ApplicationDbContext _context;

    public ReportRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReportDto> CreateReportAsync(Report model)
    {
        
        _context.Reports.Add(model);
        await _context.SaveChangesAsync();
        return MapReportToDto(model);
    }

    public async Task<IEnumerable<ReportDto>> GetReportsAsync()
    {
        var reports = await _context.Reports.ToListAsync();
        return reports.Select(r => MapReportToDto(r));
    }

    public async Task<ReportDto> GetReportAsync(Guid reportId)
    {
        var Report = await _context.Reports.FindAsync(reportId);
        if (Report == null)
        {
            throw new ArgumentException("Report with the specified ReportId not found.");
        }
        return MapReportToDto(Report);
        
    }
    public async Task<ReportDto> UpdateReportAsync(Report model)
    {
        var existingReport = await _context.Reports.FindAsync(model.ReportId);

        if (existingReport == null)
        {
            throw new ArgumentException("Report with the specified UserId not found.");
        }

        existingReport.ServiceRequestDate = model.ServiceRequestDate;
        existingReport.ServiceWantedDate = model.ServiceWantedDate;
        existingReport.TenantId = model.TenantId;
        existingReport.Description = model.Description;
        existingReport.FixtureId = model.FixtureId;
        existingReport.ProblemId = model.ProblemId;

        await _context.SaveChangesAsync();
        return MapReportToDto(existingReport);
    }

    
    private ReportDto MapReportToDto(Report model)
    {
        return new ReportDto
        {
            ReportId = model.ReportId,
            ServiceRequestDate = model.ServiceRequestDate,
            ServiceWantedDate = model.ServiceWantedDate,
            TenantId = model.TenantId,
            Description = model.Description,
            FixtureId = model.FixtureId,
            ProblemId = model.ProblemId
        };
    }
}