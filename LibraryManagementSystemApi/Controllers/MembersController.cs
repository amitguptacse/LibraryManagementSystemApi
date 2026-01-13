using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemApi.Services.Interfaces;

namespace LibraryManagementSystemApi.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _memberService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _memberService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _memberService.AddAsync(dto);
            return Ok("Member added successfully");
        }
    }

}
