using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace MicroService.ApiGateway.Controllers
{
    //[Authorize]
    public class HomeController : AbpController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
