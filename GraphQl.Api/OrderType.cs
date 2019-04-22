using GraphQL.Types;

using System.Collections.Generic;

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
			Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
				.Name("OrderItems")
				.ResolveAsync(ctx => dataStore.GetOrderItemsAsync(ctx.Source.OrderId));
		}
	}
}
