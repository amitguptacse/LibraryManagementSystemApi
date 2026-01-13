namespace LibraryManagementSystemApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllAsync();
        Task<BookResponseDto?> GetByIdAsync(int bookId);
        Task AddAsync(BookCreateDto dto);
        Task UpdateAsync(int bookId, BookUpdateDto dto);
        Task DeleteAsync(int bookId);
    }

}
