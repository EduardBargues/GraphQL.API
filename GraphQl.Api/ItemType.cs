using GraphQL.Types;

namespace GraphQl.Api
{
	public class ItemType : ObjectGraphType<Item>
	{
		public ItemType()
		{
			Field(i => i.Barcode, type: typeof(IdGraphType));
			Field(i => i.Title);
			Field(i => i.SellingPrice);
		}
	}
}
