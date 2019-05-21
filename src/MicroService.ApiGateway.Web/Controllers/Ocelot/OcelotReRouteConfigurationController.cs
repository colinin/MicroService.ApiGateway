using MicroService.ApiGateway.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace MicroService.ApiGateway.Controllers.Ocelot
{
    [Route("Ocelot/Configuration")]
    public class OcelotReRouteConfigurationController : AbpController
    {
        private readonly IReRouteAppService _reRouteAppService;
        public OcelotReRouteConfigurationController(
            IReRouteAppService reRouteAppService
            )
        {
            _reRouteAppService = reRouteAppService;
        }

        [HttpGet]
        [Route("ReRoutes")]
        public async Task<IActionResult> ReRoutes()
        {
            return await Task.FromResult(View("/Views/Ocelot/ReRoutes.cshtml"));
        }
    }
}
