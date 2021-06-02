using System;
using Store.Domain.StoreComtext.Enums;

namespace Store.Domain.StoreComtext.Entities
{
  public class Delivery
  {
    public Delivery(DateTime estimatedDeleveryDate)
    {
      EstimatedDeleveryDate = estimatedDeleveryDate;
      CreateDate = DateTime.Now;
      Status = EDeleveryStatus.Waiting;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDeleveryDate { get; private set; }
    public EDeleveryStatus Status { get; private set; }
  }
}