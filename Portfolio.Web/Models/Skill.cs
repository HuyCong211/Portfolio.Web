using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Category { get; set; } = string.Empty; // "Technical" hoặc "Soft"

        [Range(0, 100)]
        public int Level { get; set; } // % kỹ năng
    }
}
