using System;
using System.Collections.Generic;
using AmazonReturnsInventoryLibrary.Items;
using Microsoft.AspNetCore.Components;
namespace AmazonReturnsInventoryUI.Components
{
    public partial class TotalUnsold
    {
        [Parameter]
        public List<Item> Items { get; set; }

        private double UnsoldTotal { get; set; } = 0.00;
        private List<Item> unsoldItems = new List<Item>();

        protected override void OnParametersSet()
        {
            GetUnsold();
            CalculateUnsoldTotal();
        }

        private void GetUnsold()
        {
            unsoldItems = Items.FindAll(i => i.SoldPrice == 0.00);
        }

        private void CalculateUnsoldTotal()
        {
            UnsoldTotal = 0.00;
            foreach (var item in unsoldItems)
            {
                UnsoldTotal += item.Price * 0.75;
            }
        }
    }
}
