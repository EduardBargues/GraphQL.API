﻿using GraphQL.Types;

namespace GraphQl.Api
{
	public class InventoryQuery : ObjectGraphType
	{
		public InventoryQuery(IDataStore dataStore)
		{
			Field<ItemType>(
				"item",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "barcode" }),
				resolve: context =>
				{
					var barcode = context.GetArgument<string>("barcode");
					return dataStore.GetItemByBarcode(barcode);
				}
			);
			Field<ListGraphType<ItemType>>(
				"items",
				resolve: context => dataStore.GetItems());

		}
	}
}
