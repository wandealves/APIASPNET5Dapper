using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Store.Domain.StoreComtext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Infra.StoreContext.DataContexts;

namespace Store.Infra.StoreContext.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly StoreDataContext _context;

    public CustomerRepository(StoreDataContext context)
    {
      _context = context;
    }

    public bool CheckDocument(string document)
    {
      return
          _context
          .Connection
          .Query<bool>(
              "spCheckDocument",
              new { Document = document },
              commandType: CommandType.StoredProcedure)
          .FirstOrDefault();
    }

    public bool CheckEmail(string email)
    {
      return _context
          .Connection
          .Query<bool>(
              "spCheckEmail",
              new { Email = email },
              commandType: CommandType.StoredProcedure)
          .FirstOrDefault();
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      return _context
         .Connection
         .Query<CustomerOrdersCountResult>(
             "spGetCustomerOrdersCount",
             new { Document = document },
             commandType: CommandType.StoredProcedure)
         .FirstOrDefault();
    }

    public IEnumerable<ListCustomerQueryResult> Get()
    {
      return _context.Connection
      .Query<ListCustomerQueryResult>("select [Id], CONCAT([FirstName], ' ', [LastName]) AS Name,[Document], [Email] FROM Customer", new { });
    }

    public GetCustomerQueryResult Get(Guid id)
    {
      return _context.Connection
      .Query<GetCustomerQueryResult>("select [Id], CONCAT([FirstName], ' ', [LastName]) AS Name,[Document], [Email] FROM Customer WHERE [Id]=@id", new { id })
      .FirstOrDefault();
    }

    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      return _context.Connection
      .Query<ListCustomerOrdersQueryResult>("", new { id });
    }

    public void Save(Customer customer)
    {
      _context.Connection.Execute("spCreateCustomer",
            new
            {
              Id = customer.Id,
              FirstName = customer.Name.FirstName,
              LastName = customer.Name.LastName,
              Document = customer.Document.Number,
              Email = customer.Email.Address,
              Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

      foreach (var address in customer.Addresses)
      {
        _context.Connection.Execute("spCreateAddress",
        new
        {
          Id = address.Id,
          CustomerId = customer.Id,
          Number = address.Number,
          Complement = address.Complement,
          District = address.District,
          City = address.City,
          State = address.State,
          Country = address.Country,
          ZipCode = address.ZipCode,
          Type = address.Type,
        }, commandType: CommandType.StoredProcedure);
      }
    }
  }
}