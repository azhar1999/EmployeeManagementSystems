using System.Net;
using System.Net.Http.Json;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Models.DTOs;
using Newtonsoft.Json;

namespace EmployeeManagementsystem.IntegrationTests.ControllerTests
{
    public class EmployeeControllerTests : IDisposable
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        public EmployeeControllerTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllEmployees_Always_ReturnAllEmployees()
        {
            // Act
            var response = await _client.GetAsync("/api/Employee");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(responseString);
            Assert.NotEmpty(employees);
        }

        [Fact]
        public async Task GetEmployeeById_ValidId_ReturnEmployeeById()
        {
            //Arrange
            int validId = 11;

            // Act
            var response = await _client.GetAsync($"/api/Employee/{validId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeInfo>(responseString);
            Assert.Equal(employee.Id, validId);
        }

        [Fact]
        public async Task GetEmployeeById_InvalidId_ReturnsNotFound()
        {
            //Arrange
            int InvalidId = 10;

            // Act
            var response = await _client.GetAsync($"/api/Employee/{InvalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Post_WithValidData_SavesEmployee()
        {
            //Arrange
            var validEmployee = new EmployeeInfo
            {
                FirstName = "Mohammed",
                LastName = "Azhar",
                ContactNumber = "1234567891",
                DateOfBirth = new DateTime(1999, 1, 1),
                Gender = Gender.Male,
                Email = "azhar@gmail.com"
            };

            // Act
            var response = await _client.PostAsJsonAsync($"/api/Employee", validEmployee);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostExistingEmployee_WithInValidData_UpdateEmployee()
        {
            //Arrange
            int validId = 11;

            var validEmployee = new EmployeeInfo
            {
                Id = validId,
                FirstName = "Mohammed",
                LastName = "Azhar",
                ContactNumber = "1234567891",
                DateOfBirth = new DateTime(1999, 1, 1),
                Gender = Gender.Male,
                Email = "azhar@gmail.com"
            };

            // Act
            var response = await _client.PostAsJsonAsync($"/api/Employee", validEmployee);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteEmployeeById_WithValidId_ReturnsOk()
        {
            //Arrange
            int validId = 11;

            // Act
            var response = await _client.DeleteAsync($"/api/Employee/{validId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }





        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
