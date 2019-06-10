using MicroService.ApiGateway.Entites.Ocelot;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MicroService.ApiGateway.Repositories
{
    public interface IReRouteRepository : IBasicRepository<ReRoute, int>
    {
        Task<ReRoute> GetByNameAsync(string routeName);

        Task<ReRoute> GetByReRouteIdAsync(long routeId);

        Task<(List<ReRoute> routes, long total)> GetPagedListAsync(int skipCount = 1, int maxResultCount = 100);

        Task DeleteAsync(Expression<Func<ReRoute, bool>> predicate, bool autoSave = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task RemoveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
