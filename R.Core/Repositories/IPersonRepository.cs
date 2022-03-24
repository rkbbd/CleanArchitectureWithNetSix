using R.Core.Entities;
using R.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.Core.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        //filter
        public Task<IEnumerable<Person>> GetPersonByName(string name);
    }
}
