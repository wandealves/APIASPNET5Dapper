using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.StoreContext.DataContexts;
using Store.Infra.StoreContext.Repositories;
using Store.Infra.StoreContext.Services;

namespace Store.Api
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddScoped<StoreDataContext, StoreDataContext>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IEmailService, EmailService>();
      services.AddTransient<CustomerHandler, CustomerHandler>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseEndpoints(endpoints =>
       {
         endpoints.MapControllers();
       });
    }
  }
}
