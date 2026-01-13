namespace LibraryManagementSystemApi.Models.Entites
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ISBN { get; set; } = null!;

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public int IssuedCopies { get; set; }  

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; }

        public ICollection<BookTransaction> BookTransactions { get; set; }
            = new List<BookTransaction>();
    }


}
