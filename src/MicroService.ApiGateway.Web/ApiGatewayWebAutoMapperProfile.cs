using AutoMapper;
using MicroService.ApiGateway.Ocelot.Dto;
using Ocelot.Configuration.File;

namespace MicroService.ApiGateway
{
    public class ApiGatewayWebAutoMapperProfile : Profile
    {
        public ApiGatewayWebAutoMapperProfile()
        {
            //Configure your AutoMapper mapping configuration here...
            CreateMap<ReRouteDto, FileReRoute>();

            CreateMap<GlobalConfigurationDto, FileGlobalConfiguration>();

            CreateMap<DynamicReRouteDto, FileDynamicReRoute>();
        }
    }
}
