using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public class DataStore : IDataStore
	{
		ConcurrentDictionary<string, Item> itemsById;

		public DataStore()
		{
			itemsById = new ConcurrentDictionary<string, Item>();
		}

		public Item GetItemByBarcode(string barcode)
			=> itemsById[barcode];
		public IEnumerable<Item> GetItems()
			=> itemsById.Values;
		public Item AddItem(Item item)
		{
			itemsById.TryAdd(item.Barcode, item);
			return item;
		}
	}
}
