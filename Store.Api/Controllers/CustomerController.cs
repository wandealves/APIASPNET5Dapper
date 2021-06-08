using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreComtext.Entities;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Api.Controllers
{
  public class CustomerController : Controller
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerHandler _handler;
    public CustomerController(ICustomerRepository customerRepository, CustomerHandler handler)
    {
      _customerRepository = customerRepository;
      _handler = handler;
    }

    [HttpGet]
    [Route("customers")]
    public IEnumerable<ListCustomerQueryResult> Get()
    {
      return _customerRepository.Get();
    }

    [HttpGet]
    [Route("customers/{id}")]
    public GetCustomerQueryResult GetById(Guid id)
    {
      return _customerRepository.Get(id);
    }


    [HttpGet]
    [Route("customers/{id}/orders")]
    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      return _customerRepository.GetOrders(id);
    }

    [HttpPost]
    [Route("customers")]
    public object Post([FromBody] CreateCustomerCommand command)
    {
      var result = (CreateCustomerCommandResult)_handler.Handle(command);
      if (_handler.Invalid) return BadRequest(_handler.Notifications);
      return result;
    }


    [HttpPut]
    [Route("customers/{id}")]
    public Customer Put([FromBody] CreateCustomerCommand command, int id)
    {
      return null;
    }

    [HttpDelete]
    [Route("customers/{id}")]
    public object Delete(int id)
    {
      return null;
    }
  }
}