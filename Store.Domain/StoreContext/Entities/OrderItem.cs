using System;

namespace Store.Domain.StoreComtext.Entities
{
  public class OrderItem
  {
    public Product Product { get; set; }
    public string Quantity { get; set; }
    public string Price { get; set; }
  }
}