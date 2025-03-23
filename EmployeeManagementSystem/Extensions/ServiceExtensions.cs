using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EMSDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EMSDb")));
    }

    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDbContext(configuration);
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}