using Mediat.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediat.EventHandlers
{
    public class CustomerCreatedLoggerEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        readonly ILogger<CustomerCreatedLoggerEventHandler> _logger;

        public CustomerCreatedLoggerEventHandler(ILogger<CustomerCreatedLoggerEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at {notification.RegistrationDate}: {notification.FirstName} {notification.LastName}");

            return Task.CompletedTask;
        }
    }
}
