namespace LibraryManagementSystemApi.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberResponseDto>> GetAllAsync();
        Task<MemberResponseDto?> GetByIdAsync(int memberId);
        Task AddAsync(MemberCreateDto dto);
    }

}
