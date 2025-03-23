using EmployeeManagementSystem.Mappers;
using EmployeeManagementSystem.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EMSDbContext _context;

    public EmployeeRepository(EMSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(EmployeeInfo employeeInfo)
    {
        var employeeDetail = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeInfo.Id);
        var employee = employeeDetail.UpdateEmployee(employeeInfo);

        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        return id;
    }
}
