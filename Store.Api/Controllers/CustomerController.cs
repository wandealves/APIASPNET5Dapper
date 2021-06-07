using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreComtext.Entities;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace Store.Api.Controllers
{
  public class CustomerController : Controller
  {
    [HttpGet]
    [Route("customers")]
    public List<Customer> Get()
    {
      return new List<Customer>();
    }

    [HttpGet]
    [Route("customers/{id}")]
    public List<Customer> GetById(Guid id)
    {
      return null;
    }


    [HttpGet]
    [Route("customers/{id}/orders")]
    public List<Order> GetOrders(Guid id)
    {
      return null;
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