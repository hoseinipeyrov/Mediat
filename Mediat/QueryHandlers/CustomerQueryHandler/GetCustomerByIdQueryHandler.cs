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

namespace Mediat.QueryHandlers.CustomerQueryHandler
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        readonly MediatDbContext _context;
        readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(MediatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _context.Customers
                .FindAsync(request.CustomerId);

            if (customer == null)
            {
                // throw new RestException(HttpStatusCode.NotFound, "Customer with given ID is not found.");
            }

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
