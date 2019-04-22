using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public interface IDataStore
	{
		IEnumerable<Item> GetItems();
		Item GetItemByBarcode(string barcode);
	}
}
