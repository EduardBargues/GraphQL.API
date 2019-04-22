using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public class OrderType : ObjectGraphType<Order>
	{
		public OrderType(IDataStore dataStore)
		{
			Field(o => o.OrderId, type: typeof(IdGraphType));
			Field(o => o.Tag);
			Field(o => o.CreatedAt);
			Field<CustomerType, Customer>()
				.Name("Customer")
				.ResolveAsync(ctx => dataStore.GetCustomerByIdAsync(ctx.Source.CustomerId));
		}
	}
}
