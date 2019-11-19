using Mediat.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mediat.Bus
{
    public interface IMediatorHandler
    {
        Task Send<T>(T command);// where T : Command;
        Task Publish<T>(T @event) where T : Event;
    }
}
