using MicroService.ApiGateway.Entites.Ocelot;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MicroService.ApiGateway.Repositories
{
    public interface IDynamicReRouteRepository : IBasicRepository<DynamicReRoute, int>
    {
        Task<DynamicReRoute> GetByItemIdAsync(int itemId);
    }
}
