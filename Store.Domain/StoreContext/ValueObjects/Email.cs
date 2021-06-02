using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreComtext.ValueObjects
{
  public class Email : Notifiable
  {
    public Email(string address)
    {
      Address = address;

      AddNotifications(new ValidationContract().Requires()
    .IsEmail(Address, "Address", "O E-mail é invalido")
    );
    }

    public string Address { get; private set; }

    public override string ToString()
    {
      return Address;
    }
  }
}