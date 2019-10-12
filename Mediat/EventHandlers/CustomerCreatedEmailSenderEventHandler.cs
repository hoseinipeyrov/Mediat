using Mediat.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediat.EventHandlers
{
    public class CustomerCreatedEmailSenderEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // IMessageSender.Send($"Welcome {notification.FirstName} {notification.LastName} !");
            return Task.CompletedTask;
        }
    }
}
