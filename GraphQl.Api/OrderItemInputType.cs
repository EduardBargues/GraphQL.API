using GraphQL.Types;

namespace GraphQl.Api
{
	public class OrderItemInputType : InputObjectGraphType
{
		public OrderItemInputType()
		{
			Name = "OrderItemInput";
			Field<NonNullGraphType<IntGraphType>>("quantity");
			Field<NonNullGraphType<StringGraphType>>("itemId");
			Field<NonNullGraphType<StringGraphType>>("orderId");
		}
	}
}
