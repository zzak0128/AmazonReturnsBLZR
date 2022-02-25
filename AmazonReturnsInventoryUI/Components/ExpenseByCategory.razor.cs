using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryLibrary.Items;
using AmazonReturnsInventoryUI.Model.Items;
using Microsoft.AspNetCore.Components;

namespace AmazonReturnsInventoryUI.Components
{
    public partial class ExpenseByCategory
    {
        [Parameter]
        public List<Item> Items { get; set; }


        public List<Category> categoryList = new List<Category>();
        private int totalItems = 0;

        protected override void OnParametersSet()
        {
            totalItems = Items.Count();
        }

        private int getCountPerCategory(Category category)
        {
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

        private Category AsCategory(string stringCategory)
        {
            Category output;

            Enum.TryParse(stringCategory, true, out output);

            return output;
        }
    }
}
