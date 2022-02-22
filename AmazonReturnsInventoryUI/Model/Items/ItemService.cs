using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryLibrary;
using AmazonReturnsInventoryLibrary.Items;
using AmazonReturnsInventoryLibrary.Transactions;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryUI.Model.Items
{
    public class ItemService
    {
        private readonly ApplicationDbContext dbContext;

        public ItemService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Retrieve
        public async Task<List<Item>> GetItemsAsync()
        {
            return await dbContext.Items.ToListAsync();
        }


        //Create
        public async Task<Item> AddItemAsync(Item item)
        {
            try
            {

                var ItemExist = dbContext.Items.FirstOrDefault(p => p.ItemID == item.ItemID);
                if (ItemExist != null)
                {
                    dbContext.Update(item);
                }
                else
                {
                    dbContext.Items.Add(item);
                }
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public Item GetItemById(int id)
        {
            Item output = dbContext.Items.FirstOrDefault(t => t.ItemID == id);
            return output;
        }

        //Update
        public async Task<Item> UpdateItemAsync(Item Item)
        {
            try
            {
                var ItemExist = dbContext.Items.FirstOrDefault(p => p.ItemID == Item.ItemID);
                if (ItemExist != null)
                {
                    dbContext.Update(Item);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Item;
        }

        //Delete
        public async Task DeleteItemAsync(Item Item)
        {
            try
            {
                var ItemExist = dbContext.Items.FirstOrDefault(p => p.ItemID == Item.ItemID);
                if (ItemExist != null)
                {
                    dbContext.Items.Remove(Item);
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
