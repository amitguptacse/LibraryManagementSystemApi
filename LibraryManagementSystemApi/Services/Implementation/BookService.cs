using LibraryManagementSystemApi.Repositories.Interfaces;
using LibraryManagementSystemApi.Services.Interfaces;

namespace LibraryManagementSystemApi.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return books.Select(b => new BookResponseDto
            {
                BookId = b.BookId,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                TotalCopies = b.TotalCopies,
                AvailableCopies = b.AvailableCopies
            });
        }

        public async Task<BookResponseDto?> GetByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null) return null;

            return new BookResponseDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies
            };
        }

        public async Task AddAsync(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                TotalCopies = dto.TotalCopies,
                AvailableCopies = dto.TotalCopies,
                IssuedCopies = 0,
                UpdatedDate = DateTime.UtcNow
            };

            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(int bookId, BookUpdateDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(bookId)
                       ?? throw new Exception("Book not found");

            // ❗ Validation: TotalCopies cannot be less than already issued copies
            if (dto.TotalCopies < book.IssuedCopies)
                throw new Exception("Total copies cannot be less than issued copies");

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.TotalCopies = dto.TotalCopies;


            book.AvailableCopies = book.TotalCopies - book.IssuedCopies;

            book.UpdatedDate = DateTime.UtcNow;

            await _bookRepository.UpdateAsync(book);
        }


        public async Task DeleteAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null) throw new Exception("Book not found");

            await _bookRepository.DeleteAsync(book);
        }
    }

}
