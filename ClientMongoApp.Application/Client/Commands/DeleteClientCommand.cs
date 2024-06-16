using ClientMongoApp.Application.Client.Responses;
using ClientMongoApp.Application.Common.Response;
using MediatR;

namespace ClientMongoApp.Application.Client.Commands
{
    public class DeleteClientCommand(string Document_id) : IRequest<Response<ClientResponse>>;
}
