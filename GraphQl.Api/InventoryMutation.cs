using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public class InventoryMutation : ObjectGraphType
	{
		public InventoryMutation(IDataStore dataStore)
		{
			Field<ItemType>(
				"createItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }
				),
				resolve: context => dataStore.AddItemAsync(context.GetArgument<Item>("item")));
			Field<CustomerType>(
				"createCustomer",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }
				),
				resolve: context => dataStore.AddCustomerAsync(context.GetArgument<Customer>("customer")));
			Field<OrderType>(
				"createOrder",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }
				),
				resolve: context => dataStore.AddOrderAsync(context.GetArgument<Order>("order")));
			Field<OrderItemType, OrderItem>()
				.Name("createOrderItem")
				.Argument<NonNullGraphType<OrderItemInputType>>("orderitem", "orderitem input")
				.ResolveAsync(ctx => dataStore.AddOrderItemAsync(ctx.GetArgument<OrderItem>("orderitem")));
		}
	}
}
