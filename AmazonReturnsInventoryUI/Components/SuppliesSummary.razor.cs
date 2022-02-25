using System;
using System.Collections.Generic;
using System.Linq;
using AmazonReturnsInventoryLibrary.SupplyItems;
using Microsoft.AspNetCore.Components;

namespace AmazonReturnsInventoryUI.Components
{
    public partial class SuppliesSummary
    {
        [Parameter]
        public List<SupplyItem> Supplies { get; set; }

        public List<SupplyItem> LowItems { get; set; } = new List<SupplyItem>();

        private double totalAssets = 0.00;
        protected override void OnParametersSet()
        {
            SumAssets();
            FindLowItems();
            StateHasChanged();
        }

        private void SumAssets()
        {
            foreach (var item in Supplies)
            {
                totalAssets += item.Price;
            }
        }

        private void FindLowItems()
        {
            LowItems = Supplies.FindAll(s => s.Quantity <= 2).ToList();
        }
    }
}
