﻿namespace FashionFlows.BuildingBlock.Domain.Events.Interface;

public interface IOrderFailedEvent
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
}