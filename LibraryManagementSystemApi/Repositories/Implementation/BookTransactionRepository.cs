using LibraryManagementSystemApi.Repositories.Interfaces;

namespace LibraryManagementSystemApi.Repositories.Implementation
{
    public class BookTransactionRepository : IBookTransactionRepository
    {
        private readonly LibraryDbContext _context;

        public BookTransactionRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<BookTransaction?> GetByIdAsync(int transactionId)
        {
            return await _context.BookTransactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .FirstOrDefaultAsync(t => t.BookTransactionId == transactionId);
        }

        public async Task<BookTransaction?> GetActiveTransactionAsync(int bookId, int memberId)
        {
            return await _context.BookTransactions
                .FirstOrDefaultAsync(t =>
                    t.BookId == bookId &&
                    t.MemberId == memberId &&
                    t.Status == "Issued");
        }

        public async Task<IEnumerable<BookTransaction>> GetAllAsync()
        {
            return await _context.BookTransactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .ToListAsync();
        }

        public async Task AddAsync(BookTransaction transaction)
        {
            await _context.BookTransactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookTransaction transaction)
        {
            _context.BookTransactions.Update(transaction);
            await _context.SaveChangesAsync();
        }
    }

}
