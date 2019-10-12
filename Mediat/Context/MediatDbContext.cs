using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediat.Models;
using Microsoft.EntityFrameworkCore;

namespace Mediat.Context
{
    public class MediatDbContext : DbContext
    {
        public MediatDbContext (DbContextOptions<MediatDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
