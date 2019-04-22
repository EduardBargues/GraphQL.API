using GraphQL;
using GraphQL.Http;
using GraphQL.Types;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Api
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IDocumentWriter, DocumentWriter>();
			services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
			services.AddSingleton<IDataStore, DataStore>();

			services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

			services.AddScoped<InventoryQuery>();
			services.AddScoped<InventoryMutation>();
			services.AddScoped<ISchema, InventorySchema>();

			services.AddScoped<ItemType>();
			services.AddScoped<ItemInputType>();

			services.AddScoped<CustomerType>();
			services.AddScoped<CustomerInputType>();

			services.AddScoped<OrderType>();
			services.AddScoped<OrderInputType>();

			services.AddScoped<OrderItemType>();
			services.AddScoped<OrderItemInputType>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseMiddleware<GraphQLMiddleware>();
		}
	}
}
