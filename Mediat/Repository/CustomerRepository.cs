using Dapper;
using Mediat.Context.Dapper;
using Mediat.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _config;

        public CustomerRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MediatDbContext"));
            }
        }

        public async Task<Customer> GetByID(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Customers WHERE Id = @Id";
                conn.Open();
                var result = await conn.QueryAsync<Customer>(sQuery, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Customer>> GetByRegistrationDate(DateTime registrationDate)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Customers WHERE RegistrationDate = @RegistrationDate";
                conn.Open();
                var result = await conn.QueryAsync<Customer>(sQuery, new { RegistrationDate = registrationDate });
                return result.ToList();
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Customers";
                conn.Open();
                var result = await conn.QueryAsync<Customer>(sQuery);
                return result.ToList();
            }
        }
    }
}
