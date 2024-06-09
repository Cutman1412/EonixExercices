using Api.Controllers;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class GetPersonByIdTest
    {
        private readonly Mock<IPersonRepository> _mockRepository;
        private readonly PersonController _controller;

        public GetPersonByIdTest()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _controller = new PersonController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetPersonById_ReturnsPerson()
        {
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.GetPersonByIdAsync(1)).ReturnsAsync(person);

            var result = await _controller.GetPersonById(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<Person>(okResult.Value);
            Assert.Equal(person, model);
        }

        [Fact]
        public async Task GetPersonById_ReturnsNotFound()
        {
            Person? person = null;
            _mockRepository.Setup(repo => repo.GetPersonByIdAsync(1)).ReturnsAsync(person);

            var result = await _controller.GetPersonById(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
