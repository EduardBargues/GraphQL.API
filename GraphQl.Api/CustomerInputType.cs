using GraphQL.Types;

namespace GraphQl.Api
{
	public class CustomerInputType : InputObjectGraphType
{
		public CustomerInputType()
		{
			Name = "CustomerInput";
			Field<NonNullGraphType<StringGraphType>>("name");
			Field<NonNullGraphType<StringGraphType>>("billingAddress");
		}
	}
}
