using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Store.Domain.StoreComtext.ValueObjects;

namespace Store.Domain.StoreComtext.Entities
{
  public class Customer : Notifiable
  {
    private readonly IList<Address> _addresses;

    public Customer(
      Name name,
      string lastName,
      Document document,
      Email email,
      string phone)
    {
      Name = name;
      Document = document;
      Email = email;
      Phone = phone;
      _addresses = new List<Address>();
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public string Phone { get; private set; }
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
    public Email Email { get; private set; }

    public void AddAddress(Address address)
    {
      _addresses.Add(address);
    }

    public override string ToString()
    {
      return Name.ToString();
    }
  }
}