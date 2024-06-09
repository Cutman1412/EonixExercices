using Api.Controllers;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class DeletePersonTest
    {
        private readonly Mock<IPersonRepository> _mockRepository;
        private readonly PersonController _controller;

        public DeletePersonTest()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _controller = new PersonController(_mockRepository.Object);
        }

        [Fact]
        public async Task DeletePerson_ReturnsNotFound()
        {
            _mockRepository.Setup(repo => repo.DeletePersonAsync(1)).ReturnsAsync(false);

            var result = await _controller.DeletePerson(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeletePerson_ReturnsNotContent()
        {
            var mockRepository = new Mock<IPersonRepository>();
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.DeletePersonAsync(1)).ReturnsAsync(true);

            _mockRepository.Setup(repo => repo.GetPersonByIdAsync(1)).ReturnsAsync(person);

            var result = await _controller.DeletePerson(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
