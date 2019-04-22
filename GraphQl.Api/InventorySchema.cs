using GraphQL.Types;

namespace GraphQl.Api
{
	public class InventorySchema : Schema
	{
		public InventorySchema(InventoryQuery query, InventoryMutation mutation)
		{
			Query = query;
			Mutation = mutation;
		}
	}
}
