using AutoMapper;
using ClientMongoApp.Application.Client.Commands;
using ClientMongoApp.Application.Client.Responses;

namespace ClientMongoApp.Application.Common.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Core.Entities.Client, CreateClientCommand>().ReverseMap();
            CreateMap<Core.Entities.Client, ClientResponse>().ReverseMap();
        }
    }
}
