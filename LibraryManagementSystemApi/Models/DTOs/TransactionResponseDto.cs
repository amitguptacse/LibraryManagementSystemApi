namespace LibraryManagementSystemApi.Models.DTOs
{
    public class TransactionResponseDto
    {
        public int TransactionId { get; set; }

        public string BookTitle { get; set; } = null!;
        public string MemberName { get; set; } = null!;

        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }      
        public DateTime? ReturnDate { get; set; }

        public decimal FineAmount { get; set; }    
        public string? IssueRemark { get; set; }   
        public string? ReturnRemark { get; set; }

        public string Status { get; set; } = null!;
    }

}
