using AutoMapper;
using Mediat.Commands;
using Mediat.Context;
using Mediat.Events;
using Mediat.Models;
using Mediat.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediat.CommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        readonly MediatDbContext _context;
        readonly IMapper _mapper;
        // added
        readonly IMediator _mediator;

        public CreateCustomerCommandHandler(MediatDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            // added
            _mediator = mediator;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(createCustomerCommand);

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // Raising Event ...
            await _mediator.Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, customer.RegistrationDate), cancellationToken);


            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
