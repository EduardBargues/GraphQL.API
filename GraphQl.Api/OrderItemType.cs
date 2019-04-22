using GraphQL.Types;

namespace GraphQl.Api
{
	public class OrderItemType : ObjectGraphType<OrderItem>
	{
		public OrderItemType(IDataStore dateStore)
		{
			Field(i => i.ItemId);
			Field<ItemType, Item>()
				.Name("Item")
				.ResolveAsync(ctx => dateStore.GetItemByIdAsync(ctx.Source.ItemId));
			Field(i => i.Quantity);
			Field(i => i.OrderId);
			Field<OrderType, Order>()
				.Name("Order")
				.ResolveAsync(ctx => dateStore.GetOrderByIdAsync(ctx.Source.OrderId));
		}
	}
}