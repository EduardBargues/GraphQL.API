using GraphQL.Types;
using System.Xml.Linq;

namespace GraphQl.Api
{
	public class ItemInputType : InputObjectGraphType
{
		public ItemInputType()
		{
			Name = "ItemInput";
			Field<NonNullGraphType<StringGraphType>>("barcode");
			Field<NonNullGraphType<StringGraphType>>("title");
			Field<NonNullGraphType<DecimalGraphType>>("sellingPrice");
		}
	}

}