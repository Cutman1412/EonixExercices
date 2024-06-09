using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Interfaces;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("filter/{filter?}")]
        public async Task<ActionResult<Person>> GetPersonByFilter(string? filter)
        {
            var persons = await _personRepository.GetPersonsByFilterAsync(filter);

            if (persons == null || persons.Count() == 0)
            {
                return NotFound();
            }

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            var newPerson = await _personRepository.AddPersonAsync(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = newPerson.Id }, newPerson);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchPerson(Person person)
        {
            var updatedPerson = await _personRepository.UpdatePersonAsync(person);

            if (updatedPerson == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var success = await _personRepository.DeletePersonAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
