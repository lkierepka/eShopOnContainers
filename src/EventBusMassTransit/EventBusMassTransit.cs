using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Microsoft.eShopOnContainers.BuildingBlocks.EventBusMassTransit
{
    public class EventBusMassTransit : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<EventBusMassTransit> _logger;

        public EventBusMassTransit(IPublishEndpoint publishEndpoint, ILogger<EventBusMassTransit> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public void Publish(IntegrationEvent @event)
        {
            _logger.LogInformation("Publishing event {Event}", @event.GetType().Name);
            _publishEndpoint.Publish((object) @event).GetAwaiter().GetResult();
        }

        public void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler
        {
            throw new NotImplementedException();
        }
    }
}