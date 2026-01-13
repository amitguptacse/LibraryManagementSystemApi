namespace LibraryManagementSystemApi.Models.Entites
{
    public class Member
    {
        
        public int MemberId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<BookTransaction> BookTransactions { get; set; }
            = new List<BookTransaction>();
    }

}
