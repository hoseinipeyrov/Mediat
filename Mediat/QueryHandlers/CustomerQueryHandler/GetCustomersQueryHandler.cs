using AutoMapper;
using Mediat.Context;
using Mediat.Models;
using Mediat.Queries.CustomerQuery;
using Mediat.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mediat.QueryHandlers.CustomerQueryHandler
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
    {
        readonly MediatDbContext _context;
        readonly IMapper _mapper;

        public GetCustomersQueryHandler(MediatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers.ToListAsync();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return customersDto;
        }
    }
}
