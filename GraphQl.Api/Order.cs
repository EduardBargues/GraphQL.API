﻿using System;
using System.Collections.Generic;

namespace GraphQl.Api
{
	public class Order
	{
		public string OrderId { get; set; }
		public string Tag { get; set; }
		public DateTime CreatedAt { get; set; }
		public Customer Customer { get; set; }
		public string CustomerId { get; set; }
		public IEnumerable<OrderItem> OrderItems { get; set; }
	}
}