using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreComtext.Entities;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Api.Controllers
{
  public class CustomerController : Controller
  {
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
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
    public Customer Post([FromBody] CreateCustomerCommand command)
    {
      return null;
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