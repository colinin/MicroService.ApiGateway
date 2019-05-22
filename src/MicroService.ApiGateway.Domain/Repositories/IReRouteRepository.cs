using MicroService.ApiGateway.Entites.Ocelot;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MicroService.ApiGateway.Repositories
{
    public interface IReRouteRepository : IBasicRepository<ReRoute, int>
    {
        Task<ReRoute> GetByNameAsync(string routeName);

        Task<ReRoute> GetByReRouteIdAsync(long routeId);

        Task<(List<ReRoute> routes, long total)> GetPagedListAsync(int skipCount = 1, int maxResultCount = 100);
    }
}
