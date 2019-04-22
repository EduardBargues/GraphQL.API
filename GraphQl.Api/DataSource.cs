using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GraphQl.Api
{
	public class DataStore : IDataStore
	{
		ConcurrentDictionary<string, Item> itemsById;

		public Item GetItemByBarcode(string barcode) 
			=> itemsById[barcode];

		public IEnumerable<Item> GetItems() 
			=> itemsById.Values;
	}
}
