using Api.Controllers;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class PostPersonTest
    {
        private readonly Mock<IPersonRepository> _mockRepository;
        private readonly PersonController _controller;

        public PostPersonTest()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _controller = new PersonController(_mockRepository.Object);
        }

        [Fact]
        public async Task PostPerson_ReturnsCreatedAtAction()
        {
            var newPerson = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.AddPersonAsync(newPerson)).ReturnsAsync(newPerson);

            var result = await _controller.PostPerson(newPerson);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(PersonController.GetPersonById), createdAtActionResult.ActionName);
            Assert.Equal(newPerson.Id, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(newPerson, createdAtActionResult.Value);
        }

        [Fact]
        public async Task PostPerson_ReturnsError()
        {
            var newPerson = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.AddPersonAsync(newPerson)).ThrowsAsync(new Exception("Error adding person"));

            await Assert.ThrowsAsync<Exception>(() => _controller.PostPerson(newPerson));
        }
    }
}
