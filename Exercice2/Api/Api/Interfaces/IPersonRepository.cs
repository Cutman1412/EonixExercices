using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>?> GetPersonsByFilterAsync(string? filter);
        Task<Person?> GetPersonByIdAsync(int id);
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(int id);
    }
}
