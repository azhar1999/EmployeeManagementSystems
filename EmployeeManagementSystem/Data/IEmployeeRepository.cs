using EmployeeManagementSystem.Models.DTOs;

namespace EmployeeManagementSystem.Data;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(EmployeeInfo employee);
    Task<int> DeleteEmployeeAsync(int id);
}
