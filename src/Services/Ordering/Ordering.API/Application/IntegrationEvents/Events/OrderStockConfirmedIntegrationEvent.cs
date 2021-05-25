﻿namespace IntegrationEvents
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

    public record OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderStockConfirmedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}