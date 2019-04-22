using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public interface IDataStore
	{
		Task<IEnumerable<Item>> GetItems();
		Task<Item> GetItemByBarcode(string barcode);
		Task<Item> AddItemAsync(Item item);
		Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId);
		Task<Customer> GetCustomerByIdAsync(string customerId);
		Task<IEnumerable<Order>> GetOrdersAsync();
		Task<IEnumerable<Customer>> GetCustomersAsync();
		Task<Order> AddOrderAsync(Order order);
		Task<Customer> AddCustomerAsync(Customer customer);
	}
}
