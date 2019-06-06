using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class QoSOptions : Entity<int>
    {
        public virtual long ItemId { get; private set; }

        public virtual int? ExceptionsAllowedBeforeBreaking { get; private set; }

        public virtual int? DurationOfBreak { get; private set; }

        public virtual int? TimeoutValue { get; private set; }

        protected QoSOptions()
        {

        }

        public QoSOptions(long itemId)
        {
            ItemId = itemId;
        }

        public void ApplyQosOptions(int? exceptionBreaking, int? duration, int? timeout)
        {
            ExceptionsAllowedBeforeBreaking = exceptionBreaking;
            DurationOfBreak = duration;
            TimeoutValue = timeout;
        }
    }
}
