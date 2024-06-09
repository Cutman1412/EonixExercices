using Moq;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers;
using Api.Models;
using Api.Interfaces;

namespace UnitTests
{
    public class PersonControllerTests
    {
        private readonly Mock<IPersonRepository> _mockRepository;
        private readonly PersonController _controller;

        public PersonControllerTests()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _controller = new PersonController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetPersonsByFilter_ReturnsPersonsContaintJo()
        {
            var filter = "Jo";
            var persons = new List<Person> {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" }
            };
            _mockRepository.Setup(repo => repo.GetPersonsByFilterAsync(filter)).ReturnsAsync(persons);

            var result = await _controller.GetPersonByFilter(filter);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
            Assert.Equal(persons, model);     
        }

        [Fact]
        public async Task GetPersonsByFilter_ReturnsAllPersons()
        {
            var filter = "";
            var persons = new List<Person> {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" },
                new Person { Id = 1, FirstName = "Bryce", LastName = "Molitor" }
            };
            _mockRepository.Setup(repo => repo.GetPersonsByFilterAsync(filter)).ReturnsAsync(persons);

            var result = await _controller.GetPersonByFilter(filter);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
            Assert.Equal(persons, model);
        }
    }
}