using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Models.DTOs;

namespace EmployeeManagementSystem.Mappers;

public static class EmployeeMapper
{
    public static EmployeeInfo ToEmployeeInfo(this Employee employee)
    {
        return new EmployeeInfo
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Gender = Enum.Parse<Gender>(employee.Gender),
            ContactNumber = employee.ContactNumber,
            DateOfBirth = employee.DateOfBirth
        };
    }

    public static Employee ToEmployeeData(this EmployeeInfo employeeInfo)
    {
        return new Employee
        {
            Id = employeeInfo.Id,
            FirstName = employeeInfo.FirstName,
            LastName = employeeInfo.LastName,
            Email = employeeInfo.Email,
            Gender = employeeInfo.Gender.ToString(),
            ContactNumber = employeeInfo.ContactNumber,
            IsDeleted = false,
            DateOfBirth = employeeInfo.DateOfBirth
        };
    }

    public static Employee UpdateEmployee(this Employee employee, EmployeeInfo employeeInfo)
    {
        employee.FirstName = employeeInfo.FirstName;
        employee.LastName = employeeInfo.LastName;
        employee.Email = employeeInfo.Email;
        employee.Gender = employeeInfo.Gender.ToString();
        employee.ContactNumber = employeeInfo.ContactNumber;
        employee.DateOfBirth = employeeInfo.DateOfBirth;
        return employee;
    }
}
