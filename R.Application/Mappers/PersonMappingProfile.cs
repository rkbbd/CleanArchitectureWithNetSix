using AutoMapper;
using R.Application.Commands;
using R.Application.Responses;
using R.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.Application.Mappers
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
        }
    }

}
