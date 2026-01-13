namespace LibraryManagementSystemApi.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class IssueBookDto
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [StringLength(500)]
        public string? IssueRemark { get; set; }

    }


}
