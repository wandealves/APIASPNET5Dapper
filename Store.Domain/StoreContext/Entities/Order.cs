using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Store.Domain.StoreComtext.Enums;

namespace Store.Domain.StoreComtext.Entities
{
  public class Order : Notifiable
  {
    private readonly IList<OrderItem> _items;
    private readonly IList<Delivery> _deliveries;

    public Order(Customer customer)
    {
      Customer = customer;
      CreateDate = DateTime.Now;
      Status = EOrderStatus.Created;
      _items = new List<OrderItem>();
      _deliveries = new List<Delivery>();
    }

    public Customer Customer { get; private set; }
    public string Number { get; private set; }
    public DateTime CreateDate { get; private set; }
    public EOrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
    public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

    public void AddItem(OrderItem item)
    {
      _items.Add(item);
    }

    public void Place()
    {
      Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

      if (_items.Count == 0)
        AddNotification("Order", "Este pedido não possui itens");
    }

    public void Pay()
    {
      Status = EOrderStatus.Paid;
    }

    public void Ship()
    {
      var deliveries = new List<Delivery>();
      deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
      var count = 1;
      foreach (var item in _items)
      {
        if (count == 5)
        {
          count = 1;
          deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
        }
        count++;
      }

      deliveries.ForEach(x => x.Ship());
      deliveries.ForEach(x => _deliveries.Add(x));
    }

    public void Cancel()
    {
      Status = EOrderStatus.Canceled;
      _deliveries.ToList().ForEach(x => x.Cancel());
    }
  }
}