using EmployeeManagementSystem.Models.DTOs;

namespace EmployeeManagementSystem.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync();
    Task<EmployeeInfo?> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<EmployeeInfo>> AddEmployeeAsync(EmployeeInfo employee);
    Task<IEnumerable<EmployeeInfo>> UpdateEmployeeAsync(EmployeeInfo employee);
    Task<IEnumerable<EmployeeInfo>> DeleteEmployeeAsync(int id);
}
