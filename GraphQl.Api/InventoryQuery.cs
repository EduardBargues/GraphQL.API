using GraphQL.Types;
using System;
using System.Collections.Generic;

namespace GraphQl.Api
{
	public class InventoryQuery : ObjectGraphType
	{
		public InventoryQuery(IDataStore dataStore)
		{
			Field<ItemType>(
				"item",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "barcode" }),
				resolve: context => dataStore.GetItemByBarcode(context.GetArgument<string>("barcode")));
			Field<ListGraphType<OrderType>>(
				"customerOrders",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "customerId" }),
				resolve: context => dataStore.GetOrdersByCustomerIdAsync(context.GetArgument<string>("customerId")));
			Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
				.Name("OrderItems")
				.ResolveAsync(ctx => dataStore.GetOrderItemsAsync());
			Field<CustomerType>(
				"customer",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "customerId" }),
				resolve: context => dataStore.GetCustomerByIdAsync(context.GetArgument<string>("customerId")));

			Field<ListGraphType<ItemType>>(
				"items",
				resolve: context => dataStore.GetItems());
			Field<ListGraphType<OrderType>, IEnumerable<Order>>()
				.Name("orders")
				.ResolveAsync(ctx => dataStore.GetOrdersAsync());
			Field<ListGraphType<CustomerType>, IEnumerable<Customer>>()
				.Name("customers")
				.ResolveAsync(ctx => dataStore.GetCustomersAsync());
		}
	}
}
