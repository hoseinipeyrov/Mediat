using Mediat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByID(int id);
        Task<List<Customer>> GetByRegistrationDate(DateTime registrationDate);
        Task<List<Customer>> GetAll();

        
    }
}
