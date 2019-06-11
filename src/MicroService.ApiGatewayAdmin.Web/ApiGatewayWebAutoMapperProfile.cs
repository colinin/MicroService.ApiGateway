using AutoMapper;
using MicroService.ApiGateway.Ocelot.Dto;

namespace MicroService.ApiGateway
{
    public class ApiGatewayWebAutoMapperProfile : Profile
    {
        public ApiGatewayWebAutoMapperProfile()
        {
            //Configure your AutoMapper mapping configuration here...
            CreateMap<AggregateReRouteDto, AggregateReRouteModel>();
            CreateMap<DynamicReRouteDto, DynamicReRouteModel>();
            CreateMap<ReRouteDto, ReRouteModel>();
            CreateMap<GlobalConfigurationDto, GlobalConfigurationModel>();
        }
    }
}
