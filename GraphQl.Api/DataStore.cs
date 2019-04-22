using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api
{
	public class DataStore : IDataStore
	{
		readonly object locker;
		int itemCount;
		int orderCount;
		int customerCount;
		readonly ConcurrentDictionary<string, Item> itemsById;
		readonly ConcurrentDictionary<string, Order> ordersById;
		readonly ConcurrentDictionary<string, Customer> customersById;
		public DataStore()
		{
			locker = new object();
			itemsById = new ConcurrentDictionary<string, Item>();
			ordersById = new ConcurrentDictionary<string, Order>();
			customersById = new ConcurrentDictionary<string, Customer>();
		}

		public Task<IEnumerable<Item>> GetItems()
			=> Task.FromResult(itemsById.Values.Cast<Item>());
		public Task<IEnumerable<Order>> GetOrdersAsync()
			=> Task.FromResult(ordersById.Values.Cast<Order>());
		public Task<IEnumerable<Customer>> GetCustomersAsync()
			=> Task.FromResult(customersById.Values.Cast<Customer>());

		public Task<Item> GetItemByBarcode(string barcode)
			=> Task.FromResult(itemsById[barcode]);
		public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId)
			=> Task.FromResult(ordersById.Values
					.Where(o => o.CustomerId == customerId));
		public async Task<Customer> GetCustomerByIdAsync(string customerId)
		{
			Customer customer = customersById[customerId];
			customer.Orders = (await GetOrdersByCustomerIdAsync(customerId)).ToList();
			return customer;
		}

		public Task<Item> AddItemAsync(Item item)
		{
			lock (locker)
			{
				item.Barcode = $"item {itemCount++}";
			}
			itemsById.TryAdd(item.Barcode, item);
			return Task.FromResult(item);
		}
		public Task<Order> AddOrderAsync(Order order)
		{
			lock (locker)
			{
				order.OrderId = $"order {orderCount++}";
				order.CreatedAt = DateTime.Now;
			}
			ordersById.TryAdd(order.OrderId, order);
			return Task.FromResult(order);
		}
		public Task<Customer> AddCustomerAsync(Customer customer)
		{
			lock (locker)
			{
				customer.CustomerId = $"customer {customerCount++}";
			}
			customersById.TryAdd(customer.CustomerId, customer);
			return Task.FromResult(customer);
		}
	}
}
