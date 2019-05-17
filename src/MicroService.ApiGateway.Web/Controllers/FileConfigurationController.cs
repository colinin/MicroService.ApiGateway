using Microsoft.AspNetCore.Mvc;
using Ocelot.Configuration.Repository;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace MicroService.ApiGateway.Controllers
{
    [Area("customade")]
    [Route("TestConfig")]
    public class TestConfigurationController : AbpController
    {
        private readonly IFileConfigurationRepository _repo;
        private readonly IServiceProvider _provider;

        public TestConfigurationController(IFileConfigurationRepository repo, IServiceProvider provider)
        {
            _repo = repo;
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _repo.Get();

            if (response.IsError)
            {
                return new BadRequestObjectResult(response.Errors);
            }

            return new OkObjectResult(response.Data);
        }
    }
}
