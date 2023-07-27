using MachineServer.DataAccess.Repository;
using MachineServer.DataAccess.Repository.IRepository;

namespace MachineServer;

public static class DependencyInjection
{
    public static void InjectedServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepo, EmployeeRepo>();
        services.AddScoped<IReportRepo, ReportRepo>();
    }

}