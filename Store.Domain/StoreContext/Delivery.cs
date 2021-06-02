using System;

namespace Store.Domain.StoreComtext
{
  public class Delivery
  {
    public DateTime CreateDate { get; set; }
    public DateTime EstimatedDeleveryDate { get; set; }
    public string Status { get; set; }
  }
}