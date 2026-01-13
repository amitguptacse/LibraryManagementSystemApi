using LibraryManagementSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemApi.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPost("issue")]
        public async Task<IActionResult> IssueBook(IssueBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _libraryService.IssueBookAsync(dto);
            return Ok(SuccessMessages.BookIssued);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook(ReturnBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _libraryService.ReturnBookAsync(dto);
            return Ok(SuccessMessages.BookReturned);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var result = await _libraryService.GetTransactionsAsync();
            return Ok(result);
        }
    }

}
