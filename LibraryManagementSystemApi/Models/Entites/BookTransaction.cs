namespace LibraryManagementSystemApi.Models.Entites
{
    public class BookTransaction
    {
        public int BookTransactionId { get; set; }

        public int BookId { get; set; }
        public int MemberId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public decimal FineAmount { get; set; }

        public string? IssueRemark { get; set; } 
        public string? ReturnRemark { get; set; } 

        public string Status { get; set; } = null!;

        public DateTime UpdatedDate { get; set; } 

        public Book Book { get; set; } = null!;
        public Member Member { get; set; } = null!;
    }



}
