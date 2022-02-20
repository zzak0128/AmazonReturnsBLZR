using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryLibrary.SupplyItems;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryUI.Model.SupplyItems
{
    public class SupplyItemService
    {
        private readonly ApplicationDbContext dbContext;

        public SupplyItemService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Retrieve
        public async Task<List<SupplyItem>> GetSupplyItemsAsync()
        {
            return await dbContext.SupplyItems.ToListAsync();
        }


        //Create
        public async Task<SupplyItem> AddSupplyItemAsync(SupplyItem SupplyItem)
        {
            try
            {

                var SupplyItemExist = dbContext.SupplyItems.FirstOrDefault(p => p.SupplyID == SupplyItem.SupplyID);
                if (SupplyItemExist != null)
                {
                    dbContext.Update(SupplyItem);
                }
                else
                {
                    dbContext.SupplyItems.Add(SupplyItem);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return SupplyItem;
        }

        public SupplyItem GetSupplyItemById(int id)
        {
            SupplyItem output = dbContext.SupplyItems.FirstOrDefault(t => t.SupplyID == id);
            return output;
        }

        //Update
        public async Task<SupplyItem> UpdateSupplyItemAsync(SupplyItem SupplyItem)
        {
            try
            {
                var SupplyItemExist = dbContext.SupplyItems.FirstOrDefault(p => p.SupplyID == SupplyItem.SupplyID);
                if (SupplyItemExist != null)
                {
                    dbContext.Update(SupplyItem);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplyItem;
        }

        //Delete
        public async Task DeleteSupplyItemAsync(SupplyItem SupplyItem)
        {
            try
            {
                var SupplyItemExist = dbContext.SupplyItems.FirstOrDefault(p => p.SupplyID == SupplyItem.SupplyID);
                if (SupplyItemExist != null)
                {
                    dbContext.SupplyItems.Remove(SupplyItem);
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
