using System;
using System.Collections.Generic;
using AmazonReturnsInventoryLibrary.Items;
using Microsoft.AspNetCore.Components;

namespace AmazonReturnsInventoryUI.Components
{
    public partial class MultiSelect
    {
        [Parameter]
        public List<Item> NoSelected { get; set; } = new List<Item>();
        [Parameter]
        public List<Item> Selected { get; set; } = new List<Item>();

        protected override void OnParametersSet()
        {
            StateHasChanged();
        }

        private void Select(Item item)
        {
            NoSelected.Remove(item);
            Selected.Add(item);
        }

        private void Deselect(Item item)
        {
            Selected.Remove(item);
            NoSelected.Add(item);
        }
    }
}
