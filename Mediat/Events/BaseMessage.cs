using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Events
{
    public abstract class BaseMessage : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected BaseMessage()
        {
            MessageType = GetType().Name;
        }
    }
}
