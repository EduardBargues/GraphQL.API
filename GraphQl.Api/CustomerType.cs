using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQl.Api
{
	public class CustomerType : ObjectGraphType<Customer>
	{
		public CustomerType(IDataStore dataStore)
		{
			Field(c => c.CustomerId, type: typeof(IdGraphType));
			Field(c => c.Name);
			Field(c => c.BillingAddress);
			Field<ListGraphType<OrderType>, IEnumerable<Order>>()
				.Name("Orders")
				.ResolveAsync(ctx => dataStore.GetOrdersByCustomerIdAsync(ctx.Source.CustomerId));
		}
	}

}