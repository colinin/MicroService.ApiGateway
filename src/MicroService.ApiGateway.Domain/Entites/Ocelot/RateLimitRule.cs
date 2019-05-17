using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class RateLimitRule : Entity<int>
    {
        public virtual int ReRouteId { get; private set; }
        /// <summary>
        /// 客户端白名单列表,多个以分号分隔
        /// </summary>
        public virtual string ClientWhitelist { get; private set; }
        /// <summary>
        /// 是否启用流量现值
        /// </summary>
        public virtual bool EnableRateLimiting { get; private set; }

        public virtual string Period { get; private set; }
        /// <summary>
        /// 速率极限周期
        /// </summary>
        public virtual double PeriodTimespan { get; private set; }
        /// <summary>
        /// 客户端在定义的时间内可以发出的最大请求数
        /// </summary>
        public virtual long Limit { get; private set; }

        protected RateLimitRule()
        {

        }
        public RateLimitRule(int rerouteId)
        {
            ReRouteId = rerouteId;
        }

        public void EnableRateLimit()
        {
            EnableRateLimiting = true;
        }

        public void DisableRateLimit()
        {
            EnableRateLimiting = false;
        }

        public void AddClientWhileList(params string[] clientWhileList)
        {
            foreach(var clientWhile in clientWhileList)
            {
                ClientWhitelist += clientWhile + ";";
            }
        }

        public void SetPeriodTimespan(string period, double timeSpan, long limit)
        {
            Period = period;
            PeriodTimespan = timeSpan;
            Limit = limit;
        }
    }
}
