using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace Store.Tests.Commands
{
  [TestClass]
  public class CreateCustomerCommandTest
  {
    public CreateCustomerCommandTest()
    {
    }

    [TestMethod]
    public void ShouldValidateWhenCommnadIsValid()
    {
      var commnad = new CreateCustomerCommand();
      commnad.FirstName = "João";
      commnad.LastName = "Silva";
      commnad.Document = "28659170377";
      commnad.Email = "joao@email.com";
      commnad.Phone = "11999999997";

      Assert.AreEqual(true, commnad.Valid());
    }
  }
}