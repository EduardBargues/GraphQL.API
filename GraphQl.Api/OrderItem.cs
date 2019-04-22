using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public class OrderItem
	{
		public string Id { get; set; }
		public string ItemId { get; set; }
		public Item Item { get; set; }
		public int Quantity { get; set; }
		public string OrderId { get; set; }
		public Order Order { get; set; }
	}
}
