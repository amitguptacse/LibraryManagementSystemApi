using LibraryManagementSystemApi.Repositories.Interfaces;
using LibraryManagementSystemApi.Services.Interfaces;

namespace LibraryManagementSystemApi.Services.Implementation
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IBookTransactionRepository _transactionRepository;

        private const decimal FinePerDay = 10; // configurable

        public LibraryService(
            IBookRepository bookRepository,
            IMemberRepository memberRepository,
            IBookTransactionRepository transactionRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task IssueBookAsync(IssueBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(dto.BookId)
                       ?? throw new Exception(ErrorMessages.BookNotFound);

            var member = await _memberRepository.GetByIdAsync(dto.MemberId)
                         ?? throw new Exception(ErrorMessages.MemberNotFound);

            if (!member.IsActive)
                throw new Exception(ErrorMessages.InactiveMember);

            if (book.AvailableCopies <= 0)
                throw new Exception(ErrorMessages.BookNotAvailable);

            if (dto.DueDate.Date < DateTime.UtcNow.Date)
                throw new Exception(ErrorMessages.InvalidDueDate);
         

            book.AvailableCopies--;
            book.IssuedCopies++;
            book.UpdatedDate = DateTime.UtcNow;
            var transaction = new BookTransaction
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                IssueDate = DateTime.UtcNow,
                DueDate = dto.DueDate,
                IssueRemark = dto.IssueRemark,
                Status = "Issued",
                FineAmount = 0,
                UpdatedDate = DateTime.UtcNow
            };

            await _bookRepository.UpdateAsync(book);
            await _transactionRepository.AddAsync(transaction);
        }

        public async Task ReturnBookAsync(ReturnBookDto dto)
        {
            var transaction = await _transactionRepository.GetByIdAsync(dto.TransactionId)
                              ?? throw new Exception(ErrorMessages.TransactionNotFound);

            if (transaction.Status != "Issued")
                throw new Exception("Book already returned");

            transaction.ReturnDate = DateTime.UtcNow;
            transaction.Status = "Returned";
            transaction.ReturnRemark = dto.ReturnRemark;
            transaction.UpdatedDate = DateTime.UtcNow;
            if (transaction.ReturnDate > transaction.DueDate)
            {
                var lateDays = (transaction.ReturnDate.Value - transaction.DueDate).Days;
                transaction.FineAmount = lateDays * FinePerDay;
            }

            var book = await _bookRepository.GetByIdAsync(transaction.BookId)!;
          
            book.AvailableCopies++;
            book.IssuedCopies--;
            book.UpdatedDate = DateTime.UtcNow;


            await _transactionRepository.UpdateAsync(transaction);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();

            return transactions.Select(t => new TransactionResponseDto
            {
                TransactionId = t.BookTransactionId,
                BookTitle = t.Book.Title,
                MemberName = t.Member.Name,
                IssueDate = t.IssueDate,
                DueDate = t.DueDate,
                ReturnDate = t.ReturnDate,
                FineAmount = t.FineAmount,
                IssueRemark = t.IssueRemark,
                ReturnRemark = t.ReturnRemark,
                Status = t.Status
            });
        }
    }

}
