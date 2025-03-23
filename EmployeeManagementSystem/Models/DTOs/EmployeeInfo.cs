using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EmployeeManagementSystem.Enums;

namespace EmployeeManagementSystem.Models.DTOs;

public class EmployeeInfo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Contact Number is required.")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number must be numeric and exactly 10 digits.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be numeric and exactly 10 digits.")]
    public string ContactNumber { get; set; }
}
