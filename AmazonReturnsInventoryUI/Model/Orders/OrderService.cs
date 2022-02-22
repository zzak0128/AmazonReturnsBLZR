using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryLibrary.Items;
using AmazonReturnsInventoryLibrary.Orders;
using AmazonReturnsInventoryLibrary.Transactions;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryUI.Model.Orders
{
    public class OrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Retrieve
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }


        //Create
        public async Task<Order> AddOrderAsync(Order Order)
        {
            try
            {
                var OrderExist = dbContext.Orders.FirstOrDefault(p => p.OrderID == Order.OrderID);
                if (OrderExist != null)
                {
                    dbContext.Update(Order);
                    
                }
                else
                {
                    dbContext.Orders.Add(Order);
                    foreach (var item in Order.Items)
                    {
                        item.Quantity -= 1;
                    }
                }

                double orderTotal = 0.00;
                foreach (var item in Order.Items)
                {
                    orderTotal += item.Price;
                }
                Order.OrderTotal = orderTotal;

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Order;
        }

        public Order GetOrderById(int id)
        {
            Order output = dbContext.Orders.FirstOrDefault(t => t.OrderID == id);
            return output;
        }

        //Delete
        public async Task DeleteOrderAsync(Order Order)
        {
            try
            {
                var OrderExist = dbContext.Orders.FirstOrDefault(p => p.OrderID == Order.OrderID);
                if (OrderExist != null)
                {
                    dbContext.Orders.Remove(Order);
                    foreach (var item in Order.Items)
                    {
                        item.Quantity += 1;
                    }

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
