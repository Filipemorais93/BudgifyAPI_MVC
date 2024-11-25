using BudifyAPI.Users.Models.TransactionsModel.DBTransactions;
using BudifyAPI.Users.Services.Transactions.InterfaceTransactions;
using Microsoft.EntityFrameworkCore;

namespace BudifyAPI.Users.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionsContext _transactionsContext;
        public TransactionService(TransactionsContext transactionsContext)
        {
            _transactionsContext = transactionsContext;
        }

        public async Task<bool> AddTransaction(Transaction transaction)
        {
            var transactionExist = await _transactionsContext.Transactions.FirstOrDefaultAsync(x => x.IdTransaction.Equals(transaction.IdTransaction));
            if (transactionExist != null)
                return false;

            await _transactionsContext.AddAsync(transaction);
            await _transactionsContext.SaveChangesAsync();
            return true;            
        }

        public async Task<List<Transaction>> GetTransactionsSevenDays()
        {
            string query = "select * from public.transactions " +
                "where date >= NOW() - INTERVAL '7 days'";
            var result = await _transactionsContext.Transactions.FromSqlRaw(query).ToListAsync();
            return result;
        }

        public Task<List<Transaction>> GetTransactionsByDateSlidingWindow(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction>> GetTransactionsByDate(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTransaction(Guid transactionId)
        {
            var transactionExist = await _transactionsContext.Transactions.FirstOrDefaultAsync(x => x.IdTransaction.Equals(transactionId));
            if (transactionExist != null)
                return false;
            _transactionsContext.Update(transactionId);
            await _transactionsContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTransaction(Guid transactionId)
        {
            var transactionExist = await _transactionsContext.Transactions.FirstOrDefaultAsync(x => x.IdTransaction.Equals(transactionId));
            if (transactionExist != null)
                return false;
            _transactionsContext.Remove(transactionId);
            await _transactionsContext.SaveChangesAsync();
            return true;
        }

        //Categories
        public Task<List<Category>> GetCategopries()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetSubcategopries()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSubategory(Subcategory subcategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubcategory(Guid subcategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubcategory(Guid subcategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reocurring>> GetReocurrings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddReocurring(Reocurring reocurring)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReocurring(Guid reocurringId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReocurring(Guid reocurringId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionGroup>> GetTransactionGroups()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTransactionGroup(TransactionGroup transactionGroup)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTransactionGroup(Guid transactionGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransactionGroup(Guid transactionGroupId)
        {
            throw new NotImplementedException();
        }
    }
}
