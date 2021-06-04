using System;
using Store.Domain.StoreComtext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreComtext.Entities
{
  public class Delivery : Entity
  {
    public Delivery(DateTime estimatedDeleveryDate)
    {
      EstimatedDeleveryDate = estimatedDeleveryDate;
      CreateDate = DateTime.Now;
      Status = EDeliveryStatus.Waiting;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDeleveryDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }

    public void Ship()
    {
      Status = EDeliveryStatus.Shipped;
    }

    public void Cancel()
    {
      Status = EDeliveryStatus.Canceled;
    }
  }
}