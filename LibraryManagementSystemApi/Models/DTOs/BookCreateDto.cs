namespace LibraryManagementSystemApi.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class BookCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Total copies must be greater than 0")]
        public int TotalCopies { get; set; }
    }

}
