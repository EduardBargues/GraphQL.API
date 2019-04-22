﻿using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public class InventoryMutation : ObjectGraphType
	{
		public InventoryMutation(IDataStore dataStore)
		{
			Field<ItemType>(
				"createItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }
				),
				resolve: context =>
				{
					Item item = context.GetArgument<Item>("item");
					return dataStore.AddItem(item);
				});
		}
	}
}
