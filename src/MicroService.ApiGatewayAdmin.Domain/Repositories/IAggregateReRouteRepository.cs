using MicroService.ApiGateway.Entites.Ocelot;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MicroService.ApiGateway.Repositories
{
    public interface IAggregateReRouteRepository : IBasicRepository<AggregateReRoute, int>
    {
        Task<(List<AggregateReRoute> routes, long total)> GetPagedListAsync(int skipCount = 1, int maxResultCount = 100);
    }
}
