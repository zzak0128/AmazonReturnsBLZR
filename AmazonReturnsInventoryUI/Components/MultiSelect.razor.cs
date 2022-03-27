using System;
using System.Collections.Generic;
using System.Linq;
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

        public string searchText = "";
        public List<Item> FilteredItems => NoSelected.FindAll(i => i.Title.ToLower().Contains(searchText.ToLower())).ToList();

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

        private void ClearSearchText()
        {
            searchText = "";
        }
    }
}
