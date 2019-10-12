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
using Microsoft.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using Mediat.Repository;

namespace Mediat.QueryHandlers.CustomerQueryHandler
{
    public class GetCustomersQueryDapperHandler : IRequestHandler<GetCustomersDapperQuery, IEnumerable<CustomerDto>>
    {
        readonly IMapper _mapper;
        readonly string connectionString = "Data Source=;Initial Catalog=MediatDb;Trusted_Connection=True";
        readonly ICustomerRepository _customerRepository;
        public GetCustomersQueryDapperHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersDapperQuery request, CancellationToken cancellationToken)
        {
            //using var connection = new SqlConnection(connectionString);
            //var customers = await connection.GetAsync<Customer>("SELECT * FROM Customers");
            //var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            //return customersDto;
            var customers = await _customerRepository.GetAll();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return customersDto;
        }
    }
}
