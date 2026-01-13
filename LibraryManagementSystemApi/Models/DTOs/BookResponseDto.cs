namespace LibraryManagementSystemApi.Models.DTOs
{
    public class BookResponseDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }

}
