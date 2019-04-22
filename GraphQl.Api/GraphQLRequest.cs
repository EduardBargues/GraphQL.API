using Newtonsoft.Json.Linq;

namespace GraphQl.Api
{
	internal class GraphQLRequest
	{
		public string Query { get; set; }
		public JObject Variables { get; set; }
	}
}