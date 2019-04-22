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
		Task<Item> GetItemByIdAsync(string itemId);
		Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId);
		Task<Customer> GetCustomerByIdAsync(string customerId);
		Task<IEnumerable<Order>> GetOrdersAsync();
		Task<Order> GetOrderByIdAsync(string orderId);
		Task<IEnumerable<Customer>> GetCustomersAsync();
		Task<IEnumerable<OrderItem>> GetOrderItemsAsync(string orderId);
		Task<Order> AddOrderAsync(Order order);
		Task<Customer> AddCustomerAsync(Customer customer);
		Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
		Task<IEnumerable<OrderItem>> GetOrderItemsAsync();
	}
}
