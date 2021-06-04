using Store.Domain.StoreComtext.Entities;

namespace Store.Domain.StoreContext.Repositories
{
  public interface ICustomerRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(Customer customer);
  }
}