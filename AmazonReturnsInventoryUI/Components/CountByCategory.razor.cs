using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryLibrary.Helpers;
using AmazonReturnsInventoryLibrary.Items;
using AmazonReturnsInventoryUI.Model.Items;
using Microsoft.AspNetCore.Components;

namespace AmazonReturnsInventoryUI.Components
{
    public partial class CountByCategory
    {
        [Parameter]
        public List<Item> Items { get; set; }

        private int totalItems = 0;

        protected override void OnParametersSet()
        {
            totalItems = Items.Count();
        }

        private int getCountPerCategory(string stringCategory)
        {
            Category category;

            Enum.TryParse(stringCategory, true, out category);

            int itemCount = 0;
            foreach (var item in Items)
            {
                if(item.Category == category)
                {
                    itemCount += 1;
                }
            }
            return itemCount;
        }

        private string CalculatePercentage(int categoryCount)
        {
            string output = "";

            double percentage = ((double)categoryCount / (double)totalItems) * 100;
            output = $"{Format.AsPercentage(percentage)}";
            return output;
        }
    }
}
