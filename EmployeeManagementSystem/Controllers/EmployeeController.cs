using EmployeeManagementSystem.Models.DTOs;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeeAsync()
    {
        return await _employeeService.GetAllEmployeesAsync();
    }

    [HttpGet("{id}")]
    public async Task<EmployeeInfo> GetEmployeeByIdAsync(int id)
    {
        return await _employeeService.GetEmployeeByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdatemployeeAsync(EmployeeInfo employee)
    {
        if (employee.Id == 0)
        {
            await _employeeService.AddEmployeeAsync(employee);
        }
        else
        {
            await _employeeService.UpdateEmployeeAsync(employee);
        }

        var employees = await _employeeService.GetAllEmployeesAsync();
        return PartialView("_EmployeeList", employees);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeAsync(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);

        var employees = await _employeeService.GetAllEmployeesAsync();
        return PartialView("_EmployeeList", employees);
    }
}
