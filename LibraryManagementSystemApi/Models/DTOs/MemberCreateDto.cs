namespace LibraryManagementSystemApi.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class MemberCreateDto
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;
    }


}
