using Api.Controllers;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class PatchPersonTest
    {
        private readonly Mock<IPersonRepository> _mockRepository;
        private readonly PersonController _controller;

        public PatchPersonTest()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _controller = new PersonController(_mockRepository.Object);
        }

        [Fact]
        public async Task PatchPerson_ReturnsNoContent()
        {
            var personToUpdate = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.UpdatePersonAsync(personToUpdate)).ReturnsAsync(personToUpdate);

            var result = await _controller.PatchPerson(personToUpdate);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PatchPerson_ReturnsNotFound()
        {
            var personToUpdate = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.UpdatePersonAsync(personToUpdate)).ReturnsAsync((Person)null);

            var result = await _controller.PatchPerson(personToUpdate);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
