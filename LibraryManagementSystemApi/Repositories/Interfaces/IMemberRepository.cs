using LibraryManagementSystemApi.Models.Entites;

namespace LibraryManagementSystemApi.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int memberId);

        Task AddAsync(Member member);
        Task UpdateAsync(Member member);
    }

}
