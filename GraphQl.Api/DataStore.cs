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
		int orderItemCount;
		readonly ConcurrentDictionary<string, Item> itemsById;
		readonly ConcurrentDictionary<string, Order> ordersById;
		readonly ConcurrentDictionary<string, Customer> customersById;
		readonly ConcurrentDictionary<string, OrderItem> orderItemsById;
		public DataStore()
		{
			locker = new object();
			itemsById = new ConcurrentDictionary<string, Item>();
			ordersById = new ConcurrentDictionary<string, Order>();
			customersById = new ConcurrentDictionary<string, Customer>();
			orderItemsById = new ConcurrentDictionary<string, OrderItem>();
		}

		public Task<IEnumerable<Item>> GetItems()
			=> Task.FromResult(itemsById.Values.Cast<Item>());
		public Task<IEnumerable<Order>> GetOrdersAsync()
			=> Task.FromResult(ordersById.Values.Cast<Order>());
		public Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
			=> Task.FromResult(orderItemsById.Values.Cast<OrderItem>());
		public Task<IEnumerable<OrderItem>> GetOrderItemsAsync(string orderId)
			=> Task.FromResult(orderItemsById.Values
				.Where(oi => oi.OrderId == orderId));

		public Task<IEnumerable<Customer>> GetCustomersAsync()
			=> Task.FromResult(customersById.Values.Cast<Customer>());

		public Task<Item> GetItemByBarcode(string barcode)
			=> Task.FromResult(itemsById[barcode]);
		public async Task<Item> GetItemByIdAsync(string itemId)
			=> await GetItemByBarcode(itemId);
		public Task<Order> GetOrderByIdAsync(string orderId)
			=> Task.FromResult(ordersById[orderId]);
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
		public Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
		{
			lock (locker)
			{
				orderItem.Id = $"orderItem {orderItemCount++}";
			}
			orderItemsById.TryAdd(orderItem.Id, orderItem);
			return Task.FromResult(orderItem);
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
