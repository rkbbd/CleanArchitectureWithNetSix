using MediatR;
using R.Application.Commands;
using R.Application.Mappers;
using R.Application.Responses;
using R.Core.Entities;
using R.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.Application.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonResponse>
    {
        private readonly IPersonRepository _personRepository;
        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entitiy = PersonMapper.Mapper.Map<Person>(request);
            if (entitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var person = await _personRepository.AddAsync(entitiy);
            var response = PersonMapper.Mapper.Map<PersonResponse>(person);
            return response;
        }
    }
}
