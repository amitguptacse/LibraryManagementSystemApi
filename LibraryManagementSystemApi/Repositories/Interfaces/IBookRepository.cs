using LibraryManagementSystemApi.Models.Entites;

namespace LibraryManagementSystemApi.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int bookId);
        Task<Book?> GetByIsbnAsync(string isbn);

        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }

}
