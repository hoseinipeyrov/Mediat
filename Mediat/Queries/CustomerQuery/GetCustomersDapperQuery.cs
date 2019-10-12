﻿using Mediat.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Queries.CustomerQuery
{
    public class GetCustomersDapperQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public GetCustomersDapperQuery()
        {}
    }
}