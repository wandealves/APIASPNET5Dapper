using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Handlers;
using Store.Tests.Fakes;

namespace Store.Tests.Handlers
{
  [TestClass]
  public class CustomerHandlerTests
  {

    public CustomerHandlerTests()
    {
    }

    [TestMethod]
    public void ShouldRegisterCustomerWhenCommandIsValid()
    {
      var commnad = new CreateCustomerCommand();
      commnad.FirstName = "João";
      commnad.LastName = "Silva";
      commnad.Document = "28659170377";
      commnad.Email = "joao@email.com";
      commnad.Phone = "11999999997";

      Assert.AreEqual(true, commnad.Valid());

      var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
    }
  }
}