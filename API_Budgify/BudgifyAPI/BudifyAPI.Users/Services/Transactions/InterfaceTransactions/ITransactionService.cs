using BudifyAPI.Users.Models.TransactionsModel.DBTransactions;

namespace BudifyAPI.Users.Services.Transactions.InterfaceTransactions

{
    public interface ITransactionService
    {
        //Transactions
        Task<bool> AddTransaction(Transaction transaction);
        Task<List<Transaction>> GetTransactionsSevenDays();
        Task<List<Transaction>> GetTransactionsByDateSlidingWindow(Transaction transaction);
        Task<List<Transaction>> GetTransactionsByDate(Transaction transaction);
        Task<bool> UpdateTransaction(Guid transactionId);
        Task<bool> DeleteTransaction(Guid transactionId);

        //Categories
        Task<List<Category>> GetCategopries();
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(Guid categoryId);
        Task<bool> DeleteCategory(Guid categoryId);

        //SubCategories
        Task<List<Category>> GetSubcategopries();
        Task<bool> AddSubategory(Subcategory subcategory);
        Task<bool> UpdateSubcategory(Guid subcategoryId);
        Task<bool> DeleteSubcategory(Guid subcategoryId);

        //Reocurring
        Task <List<Reocurring>> GetReocurrings();
        Task<bool> AddReocurring(Reocurring reocurring);
        Task<bool> UpdateReocurring(Guid reocurringId);
        Task<bool> DeleteReocurring(Guid reocurringId);

        //TransacationGroups
        Task<List<TransactionGroup>> GetTransactionGroups();
        Task<bool> AddTransactionGroup(TransactionGroup transactionGroup);
        Task<bool> UpdateTransactionGroup(Guid transactionGroupId);
        Task<bool> DeleteTransactionGroup(Guid transactionGroupId);
        

    }
}
