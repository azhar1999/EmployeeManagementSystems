using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Mappers;
using EmployeeManagementSystem.Models.DTOs;

namespace EmployeeManagementSystem.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync()
    {
        var employees = await _repository.GetAllEmployeesAsync();
        var employeeInfos = new List<EmployeeInfo>();
        foreach (var employee in employees)
        {
            var employeeInfo = employee.ToEmployeeInfo();
            employeeInfos.Add(employeeInfo);
        }
        return employeeInfos;
    }

    public async Task<EmployeeInfo?> GetEmployeeByIdAsync(int id)
    {
        var employee = await _repository.GetEmployeeByIdAsync(id);
        var employeeInfo = employee.ToEmployeeInfo();
        return employeeInfo;
    }

    public async Task<IEnumerable<EmployeeInfo>> AddEmployeeAsync(EmployeeInfo employee)
    {
        var employeeData = employee.ToEmployeeData();
        await _repository.AddEmployeeAsync(employeeData);
        return await GetAllEmployeesAsync();
    }

    public async Task<IEnumerable<EmployeeInfo>> UpdateEmployeeAsync(EmployeeInfo employee)
    {
        await _repository.UpdateEmployeeAsync(employee);
        return await GetAllEmployeesAsync();
    }

    public async Task<IEnumerable<EmployeeInfo>> DeleteEmployeeAsync(int id)
    {
        await _repository.DeleteEmployeeAsync(id);
        return await GetAllEmployeesAsync();
    }
}
