using Mediat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Services.PersonService
{
    public interface IUserApplicationService : IDisposable
    {
        Task<UserDto> CreateAsync(UserDto userDto);
    }
}
