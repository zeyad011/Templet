﻿using Templet.Core.Bases;
using MediatR;

namespace Templet.Core.Features.Users.Command.Model
{
    public class AddUserCommand : IRequest<Response<string>>
    {

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }


    }
}
