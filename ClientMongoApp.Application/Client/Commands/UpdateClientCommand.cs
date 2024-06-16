using ClientMongoApp.Application.Client.Responses;
using ClientMongoApp.Application.Common.Response;
using MediatR;

namespace ClientMongoApp.Application.Client.Commands
{
    public class UpdateClientCommand : IRequest<Response<ClientResponse>>
    {
        public string Name { get; init; }
        public string Last_name { get; init; }
        public string Document_id { get; init; }
        public string Address { get; init; }
    }
}
