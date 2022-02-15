using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryLibrary.Transactions
{
    public class TransactionService
    {
        private readonly ApplicationDbContext dbContext;

        public TransactionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Retrieve
        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await dbContext.Transactions.ToListAsync();
        }


        //Create
        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            try
            {

                var transactionExist = dbContext.Transactions.FirstOrDefault(p => p.TransactionID == transaction.TransactionID);
                if (transactionExist != null)
                {
                    dbContext.Update(transaction);
                }
                else
                {
                    dbContext.Transactions.Add(transaction);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return transaction;
        }

        public Transaction GetTransactionById(int id)
        {
            Transaction output = dbContext.Transactions.FirstOrDefault(t => t.TransactionID == id);
            return output;
        }

        //Update
        public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
        {
            try
            {
                var transactionExist = dbContext.Transactions.FirstOrDefault(p => p.TransactionID == transaction.TransactionID);
                if (transactionExist != null)
                {
                    dbContext.Update(transaction);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return transaction;
        }

        //Delete
        public async Task DeleteTransactionAsync(Transaction transaction)
        {
            try
            {
                var transactionExist = dbContext.Transactions.FirstOrDefault(p => p.TransactionID == transaction.TransactionID);
                if (transactionExist != null)
                {
                    dbContext.Transactions.Remove(transaction);
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
