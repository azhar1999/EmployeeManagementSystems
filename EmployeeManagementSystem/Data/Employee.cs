namespace EmployeeManagementSystem.Data;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsDeleted { get; set; }
}
