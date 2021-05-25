using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace IntegrationEvents
{
    public record OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderStockConfirmedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}