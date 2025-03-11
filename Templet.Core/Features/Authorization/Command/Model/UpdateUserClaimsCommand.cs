using Templet.Core.Bases;
using Templet.Data.DTOs;
using MediatR;

namespace Templet.Core.Features.Authorization.Command.Model
{
    public class UpdateUserClaimsCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public List<UserClaims> UserClaims { get; set; }// data -Dto
    }
}
