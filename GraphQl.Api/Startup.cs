﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Api
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			var schema = new Schema { Query = new HelloWorldQuery() };

			app.Run(async (context) =>
			{
				ExecutionResult result = await new DocumentExecuter().ExecuteAsync(doc =>
				{
					doc.Schema = schema;
					doc.Query = @"
						query {
							hello
							howdy
                        }
                    ";
				}).ConfigureAwait(false);

				string json = new DocumentWriter(indent: true).Write(result);
				await context.Response.WriteAsync(json);
			});
		}
	}
}
