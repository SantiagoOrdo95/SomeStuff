using ClientMongoApp.Application.Client.Responses;
using ClientMongoApp.Application.Common.Response;
using MediatR;

namespace ClientMongoApp.Application.Client.Commands
{
    public record CreateClientCommand : IRequest<Response<ClientResponse>>
    {
        public string Name { get; init; }
        public string Last_name { get; init; }
        public string Document_id { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
    }
}
