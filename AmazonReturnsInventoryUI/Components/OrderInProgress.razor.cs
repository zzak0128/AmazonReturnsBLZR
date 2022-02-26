using System;
using System.Collections.Generic;
using AmazonReturnsInventoryLibrary.Orders;
using Microsoft.AspNetCore.Components;

namespace AmazonReturnsInventoryUI.Components
{
    public partial class OrderInProgress
    {
        [Parameter]
        public List<Order> Orders { get; set; }

        List<Order> inProcessOrders = new List<Order>();

        protected override void OnParametersSet()
        {
            GetOrdersInProgress();
        }

        private void GetOrdersInProgress()
        {
            inProcessOrders = Orders.FindAll(o => o.Status == OrderStatus.InProcess);
            StateHasChanged();
        }
    }
}
