using LibraryManagementSystemApi.Repositories.Interfaces;
using LibraryManagementSystemApi.Services.Interfaces;

namespace LibraryManagementSystemApi.Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberResponseDto>> GetAllAsync()
        {
            var members = await _memberRepository.GetAllAsync();

            return members.Select(m => new MemberResponseDto
            {
                MemberId = m.MemberId,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                IsActive = m.IsActive
            });
        }

        public async Task<MemberResponseDto?> GetByIdAsync(int memberId)
        {
            var member = await _memberRepository.GetByIdAsync(memberId);
            if (member == null) return null;

            return new MemberResponseDto
            {
                MemberId = member.MemberId,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                IsActive = member.IsActive
            };
        }

        public async Task AddAsync(MemberCreateDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                IsActive = true
            };

            await _memberRepository.AddAsync(member);
        }
    }

}
