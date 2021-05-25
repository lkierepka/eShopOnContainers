namespace IntegrationEvents
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

    public record OrderPaymentFailedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentFailedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}