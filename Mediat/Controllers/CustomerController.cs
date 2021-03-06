﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mediat.ViewModels;
using Mediat.Commands;
using MediatR;
using Mediat.Queries.CustomerQuery;

namespace Mediat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCustomers()
        {
            //var customers = await _mediator.Send(new GetCustomersDapperQuery());
            var customers = await _mediator.Send(new GetCustomersQuery());

            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int customerId)
        {
            CustomerDto customer = await _mediator.Send(new GetCustomerByIdQuery(customerId));
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var customer = await _mediator.Send(createCustomerCommand);
            //var customer = new CustomerDto { Id = 1, FirstName = "hadi", LastName = "hoseini", RegistrationDate = "1398/12/12" };
            // return CreatedAtAction("GetCustomerById", new { customerId = customer.Id }, customer);
            return Ok("OK");
        }

        //private readonly ApplicationDbContext _context;

        //public CustomersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Customers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        //{
        //    return await _context.Customer.ToListAsync();
        //}

        //// GET: api/Customers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //    var customer = await _context.Customer.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}

        //// PUT: api/Customers/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Customers
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        //{
        //    _context.Customer.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        //}

        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        //{
        //    var customer = await _context.Customer.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customer.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return customer;
        //}

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customer.Any(e => e.Id == id);
        //}
    }
}
