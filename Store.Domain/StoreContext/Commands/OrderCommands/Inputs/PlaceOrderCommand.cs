using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Inputs
{
  public class PlaceOrderCommand : Notifiable, ICommand
  {
    public PlaceOrderCommand()
    {
      OrderItems = new List<OrderItemCommnad>();
    }

    public Guid Customer { get; set; }
    public IList<OrderItemCommnad> OrderItems { get; set; }

    public bool Valid()
    {
      AddNotifications(new ValidationContract().Requires()
        .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inváliudo")
        .IsGreaterThan(OrderItems.Count, 0, "Item", "Nunhum item do pedido encontrado")
      );

      return IsValid;
    }
  }

  public class OrderItemCommnad
  {
    public Guid Product { get; set; }
    public decimal quatity { get; set; }
  }
}