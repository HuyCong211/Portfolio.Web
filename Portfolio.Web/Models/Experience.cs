using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty; // Chức danh hoặc tên chương trình học

        [Required, StringLength(100)]
        public string CompanyOrSchool { get; set; } = string.Empty; // Tên công ty hoặc trường học

        [Required, StringLength(50)]
        public string Type { get; set; } = string.Empty; // "Work" hoặc "Education"

        [StringLength(50)]
        public string Duration { get; set; } = string.Empty; // Ví dụ: "2022 - 2024"

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
