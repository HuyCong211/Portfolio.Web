using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Profession { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        public string? University { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Bio { get; set; } = string.Empty; // Mục tiêu, mô tả ngắn gọn

        [StringLength(200)]
        public string? CvFileName { get; set; } = string.Empty; // file CV (pdf)
    }
}
