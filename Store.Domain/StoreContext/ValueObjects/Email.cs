namespace Store.Domain.StoreComtext.ValueObjects
{
  public class Email
  {
    public Email(string address)
    {
      Address = address;
    }

    public string Address { get; private set; }

    public override string ToString()
    {
      return Address;
    }
  }
}