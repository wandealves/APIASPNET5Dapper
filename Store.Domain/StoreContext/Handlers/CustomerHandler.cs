using FluentValidator;
using Store.Domain.StoreComtext.Entities;
using Store.Domain.StoreComtext.ValueObjects;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
  public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
  {
    private readonly ICustomerRepository _repository;
    private readonly IEmailService _emailService;

    public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
    {
      _repository = repository;
      _emailService = emailService;
    }

    public ICommandResult Handle(CreateCustomerCommand command)
    {
      if (_repository.CheckDocument(command.Document))
        AddNotification("Document", "Este CPF já está em uso");
      if (_repository.CheckEmail(command.Email))
        AddNotification("Email", "este e-mail já está em uso");

      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document);
      var email = new Email(command.Email);

      var customer = new Customer(name, document, email, command.Phone);

      AddNotifications(name.Notifications);
      AddNotifications(document.Notifications);
      AddNotifications(email.Notifications);
      AddNotifications(customer.Notifications);

      if (Invalid) return null;

      _repository.Save(customer);

      _emailService.Send(email.Address, "hello@email.com", "Bem vindo", "seja bem vindo ao Store.io");

      return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
    }

    public ICommandResult Handle(AddAddressCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}