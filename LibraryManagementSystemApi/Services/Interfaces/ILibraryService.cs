namespace LibraryManagementSystemApi.Services.Interfaces
{
    public interface ILibraryService
    {
        Task IssueBookAsync(IssueBookDto dto);
        Task ReturnBookAsync(ReturnBookDto dto);
        Task<IEnumerable<TransactionResponseDto>> GetTransactionsAsync();
    }

}
