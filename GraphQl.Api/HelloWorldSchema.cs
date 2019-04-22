using GraphQL.Types;

namespace GraphQl.Api
{
	public class HelloWorldSchema : Schema
	{
		public HelloWorldSchema(HelloWorldQuery query)
		{
			Query = query;
		}
	}
}
