using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryLibrary.SupplyItems;

namespace AmazonReturnsInventoryUI.Pages.SupplyItems
{
    public partial class AllSupplyItems
    {
        public SupplyItem SelectedItem { get; set; } = new SupplyItem();

        List<SupplyItem> SupplyItems = new List<SupplyItem>();
        protected override async Task OnInitializedAsync()
        {
            await RefreshSupplyItems();
        }

        private async Task RefreshSupplyItems()
        {
            List<SupplyItem> AllItems = await service.GetSupplyItemsAsync();
            SupplyItems = AllItems.OrderBy(i => i.Title).ToList();
        }

        private void NavigateToDetail(int id)
        {
            navManager.NavigateTo($"/allsupplyitems/detail/{id}");
        }

        private void NavigateToCreate()
        {
            navManager.NavigateTo("/allsupplyitems/new");
        }

        private void NavigateToEdit(int id)
        {
            navManager.NavigateTo($"/allsupplyitems/edit/{id}");
        }

        private async Task DeleteSupplyItem(SupplyItem SupplyItem)
        {
            await service.DeleteSupplyItemAsync(SupplyItem);
            await RefreshSupplyItems();
        }
    }
}
