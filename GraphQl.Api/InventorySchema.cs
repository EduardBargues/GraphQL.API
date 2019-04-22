﻿using GraphQL;
using GraphQL.Types;

namespace GraphQl.Api
{
	public class InventorySchema : Schema
	{
		public InventorySchema(IDependencyResolver resolver) : base(resolver)
		{
			Query = resolver.Resolve<InventoryQuery>();
			Mutation = resolver.Resolve<InventoryMutation>();
		}
	}
}
