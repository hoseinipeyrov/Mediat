using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mediat.Bus;
using Mediat.Commands.UserCommand;
using Mediat.ViewModels;
using MediatR;

namespace Mediat.Services.PersonService
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserApplicationService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var createUserCommand = _mapper.Map<CreateUserCommand>(userDto);
            return await _mediator.Send(createUserCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
