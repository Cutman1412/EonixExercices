using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApiContext _context;

        public PersonRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>?> GetPersonsByFilterAsync(string? filter)
        {
            if (filter == null)
            {
                return await _context.Persons.ToListAsync();
            }
            else
            {
                return await _context.Persons
                    .Where(p => p.FirstName != null && p.FirstName.ToLower().Contains(filter.ToLower()) ||
                                p.LastName != null && p.LastName.ToLower().Contains(filter.ToLower()))
                    .ToListAsync();
            }
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person> AddPersonAsync(Person Person)
        {
            _context.Persons.Add(Person);
            await _context.SaveChangesAsync();
            return Person;
        }

        public async Task<Person> UpdatePersonAsync(Person Person)
        {
            _context.Entry(Person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Person;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var Person = await _context.Persons.FindAsync(id);
            if (Person == null)
            {
                return false;
            }

            _context.Persons.Remove(Person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}