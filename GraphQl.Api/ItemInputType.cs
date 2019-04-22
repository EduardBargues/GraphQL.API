using GraphQL.Types;

namespace GraphQl.Api
{
	public class ItemInputType : InputObjectGraphType
{
		public ItemInputType()
		{
			Name = "ItemInput";
			Field<NonNullGraphType<StringGraphType>>("title");
			Field<NonNullGraphType<DecimalGraphType>>("sellingPrice");
		}
	}
}