using Microsoft.EntityFrameworkCore;
using R.Core.Entities;
using R.Core.Repositories;
using R.Infrastructure.Data;
using R.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonContext personContext) : base(personContext) { }
        public async Task<IEnumerable<Person>> GetPersonByName(string name)
        {
            return await _personContext.Persons.Where(m => m.Name == name).ToListAsync();
        }
    }
}
