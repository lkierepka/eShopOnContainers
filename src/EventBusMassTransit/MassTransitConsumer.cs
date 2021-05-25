using System.Threading.Tasks;
using MassTransit;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace EventBusMassTransit
{
    public class MassTransitConsumer<T, TH> : IConsumer<T>
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        private readonly TH _consumer;

        public MassTransitConsumer(TH consumer)
        {
            _consumer = consumer;
        }

        public Task Consume(ConsumeContext<T> context)
        {
            return _consumer.Handle(context.Message);
        }
    }
}