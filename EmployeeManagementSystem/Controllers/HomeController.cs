using EmployeeManagementSystem.Models.DTOs;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers;

public class HomeController : Controller
{

    private readonly IEmployeeService _employeeService;

    public HomeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Home()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return View(employees);
    }

    public async Task<IActionResult> AddEditEmployee(int? id)
    {
        var employee = id.HasValue
            ? await _employeeService.GetEmployeeByIdAsync(id.Value)
            : new EmployeeInfo();

        return PartialView("_AddUpdateEmployee", employee);
    }

}
