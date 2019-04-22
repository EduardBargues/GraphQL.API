using GraphQL.Types;

namespace GraphQl.Api
{
	public class OrderInputType : InputObjectGraphType
{
		public OrderInputType()
		{
			Name = "OrderInput";
			Field<NonNullGraphType<StringGraphType>>("tag");
			Field<NonNullGraphType<StringGraphType>>("customerId");
		}
	}
}
