namespace LibraryManagementSystemApi.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ReturnBookDto
    {
        [Required]
        public int TransactionId { get; set; }

        [StringLength(500)]
        public string? ReturnRemark { get; set; }
    }

}
