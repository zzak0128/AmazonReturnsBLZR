using System;
using System.Collections.Generic;
using System.Linq;
using AmazonReturnsInventoryLibrary.Orders;
using AmazonReturnsInventoryLibrary.Transactions;
using Microsoft.AspNetCore.Components;

namespace AmazonReturnsInventoryUI.Components
{
    public partial class TotalPlusPending
    {
        [Parameter]
        public List<Order> Orders { get; set; }
        [Parameter]
        public List<Transaction> Transactions { get; set; }

        private List<Order> pendingOrders = new List<Order>();
        private double pendingTotal = 0.00;
        private double totalExpense = 0.00;
        private double totalIncome = 0.00;
        private double totalShipping = 0.00;
        protected override void OnParametersSet()
        {
            GetPendingOrders();
            pendingTotal = GetOrderTotal(pendingOrders);
            totalShipping = GetOrderShippingTotal(Orders);
            GetTransactionTotals(Transactions);
        }

        private void GetPendingOrders()
        {
            pendingOrders = Orders.FindAll(o => o.Status != OrderStatus.Delivered).ToList();
        }

        private double GetOrderTotal(List<Order> orders)
        {
            double output = 0.00;
            foreach (var order in orders)
            {
                output += order.OrderTotal;
            }
            return output;
        }

        private double GetOrderShippingTotal(List<Order> orders)
        {
            double output = 0.00;
            foreach (var order in orders)
            {
                output += order.ShippingCost;
            }
            return output;
        }

        private void GetTransactionTotals(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Type == TransactionType.Expense)
                {
                    totalExpense += transaction.Cost;
                }
                else
                {
                    totalIncome += transaction.Cost;
                }
            }
        }
    }
}
