using EmployeeApp.Core;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EmployeeApp.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeService> _mockService;
        private IEmployeeService _service;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IEmployeeService>();
            _service = _mockService.Object;
        }

        [Test]
        public void GetEmployeeOrThrow_WithValidId_ReturnsEmployee()
        {
            // Arrange
            var expectedEmployee = new Employee { Id = 1, Name = "Ravi", Email = "ravi@example.com", IsActive = true };
            _mockService.Setup(s => s.GetEmployeeOrThrow(1)).Returns(expectedEmployee);

            // Act
            var result = _service.GetEmployeeOrThrow(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Ravi"));
            _mockService.Verify(s => s.GetEmployeeOrThrow(1), Times.Once);
        }

        [Test]
        public void GetEmployeeOrThrow_WithNegativeId_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            _mockService
                .Setup(s => s.GetEmployeeOrThrow(invalidId))
                .Throws(new ArgumentOutOfRangeException("id", "Id must be positive"));

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetEmployeeOrThrow(invalidId));
            Assert.That(ex.ParamName, Is.EqualTo("id"));
            Assert.That(ex.Message, Does.Contain("Id must be positive"));
        }

        [Test]
        public void GetEmployeeOrThrow_WithNonExistentId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nonExistentId = 999;
            _mockService
                .Setup(s => s.GetEmployeeOrThrow(nonExistentId))
                .Throws(new KeyNotFoundException($"Employee with {nonExistentId} not found"));

            // Act & Assert
            var ex = Assert.Throws<KeyNotFoundException>(() => _service.GetEmployeeOrThrow(nonExistentId));
            Assert.That(ex.Message, Does.Contain($"Employee with {nonExistentId} not found"));
            _mockService.Verify(s => s.GetEmployeeOrThrow(nonExistentId), Times.Once);
        }

        [Test]
        public void GetEmployeeOrThrow_WithZeroId_ReturnsEmployee()
        {
            // Arrange
            var expectedEmployee = new Employee { Id = 0, Name = "Test", Email = "test@example.com", IsActive = true };
            _mockService.Setup(s => s.GetEmployeeOrThrow(0)).Returns(expectedEmployee);

            // Act
            var result = _service.GetEmployeeOrThrow(0);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(0));
        }

        [Test]
        public void Add()
        {
            var repo = new EmployeeRepository();
            var emp = new Employee { Id = 1, Name = "Ravi", Email = "ravi@example.com", IsActive = true };
            repo.Add(emp);

            Assert.That(repo.emp, Is.SameAs(emp));
        }
    }
}