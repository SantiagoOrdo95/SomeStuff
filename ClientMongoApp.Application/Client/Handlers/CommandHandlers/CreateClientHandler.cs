using ClientMongoApp.Application.Client.Commands;
using ClientMongoApp.Application.Client.Responses;
using ClientMongoApp.Application.Common.Constant;
using ClientMongoApp.Application.Common.Mapper;
using ClientMongoApp.Application.Common.Response;
using ClientMongoApp.Infrastructure.Services;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientMongoApp.Application.Client.Handlers.CommandHandlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Response<ClientResponse>>
    {
        private readonly ClientService _clientService;

        public CreateClientHandler(ClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<Response<ClientResponse>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<ClientResponse>();
            try
            {
                // Mapping
                var entity = AppMapper.Mapper.Map<Core.Entities.Client>(request);

                // Register date creation
                entity.Creation_date = DateTime.Now;

                await _clientService.CreateAsync(entity);

                response.Success = true;
                response.Message = Constants.CreateClientOk_EN;
                response.Result = AppMapper.Mapper.Map<ClientResponse>(entity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = new StringBuilder(Constants.CreateClientNoResult_EN, 50).Append($"{request.Document_id} --> {ex.Message}").ToString();
            }

            return response;
        }
    }
}
