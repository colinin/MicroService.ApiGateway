using MicroService.ApiGateway.Entites.Ocelot;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MicroService.ApiGateway.Repositories
{
    public interface IGlobalConfigRepository : IBasicRepository<GlobalConfiguration, int>
    {
        Task<GlobalConfiguration> GetOneAsync();
        Task<GlobalConfiguration> GetByItemIdAsync(int itemId);
    }
}
