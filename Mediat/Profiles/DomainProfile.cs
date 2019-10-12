using AutoMapper;
using Mediat.Commands;
using Mediat.Models;
using Mediat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(c => c.RegistrationDate, opt =>
                    opt.MapFrom(_ => DateTime.Now));

            CreateMap<Customer, CustomerDto>()
                .ForMember(cd => cd.RegistrationDate, opt =>
                    opt.MapFrom(c => c.RegistrationDate.ToShortDateString()));
        }
    }
}
