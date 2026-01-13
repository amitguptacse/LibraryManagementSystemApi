using LibraryManagementSystemApi.Models.Entites;

namespace LibraryManagementSystemApi.Repositories.Interfaces
{
    public interface IBookTransactionRepository
    {
        Task<BookTransaction?> GetByIdAsync(int transactionId);

        Task<BookTransaction?> GetActiveTransactionAsync(int bookId, int memberId);

        Task<IEnumerable<BookTransaction>> GetAllAsync();

        Task AddAsync(BookTransaction transaction);
        Task UpdateAsync(BookTransaction transaction);
    }

}
