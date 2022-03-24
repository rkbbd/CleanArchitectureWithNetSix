using MediatR;
using R.Application.Queries;
using R.Core.Entities;
using R.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.Application.Handlers
{
    public class GetPersonsHandler : IRequestHandler<GetPersonsQuery, List<Person>>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonsHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<List<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return (List<Person>)await _personRepository.GetAllAsync();
        }
    }
}
