﻿using GraphQL.Types;

namespace GraphQl.Api
{
	public class HelloWorldQuery : ObjectGraphType
	{
		public HelloWorldQuery(IDataStore dataStore)
		{
			Field<StringGraphType>(
				name: "hello",
				resolve: context => "world"
			);
			Field<StringGraphType>(
				name: "howdy",
				resolve: context => "universe"
			);
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
