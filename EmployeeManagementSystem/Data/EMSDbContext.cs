using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data;

public class EMSDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EMSDbContext(DbContextOptions options) : base(options)
    {

    }
}
