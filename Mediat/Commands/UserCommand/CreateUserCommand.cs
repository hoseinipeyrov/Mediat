using Mediat.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
