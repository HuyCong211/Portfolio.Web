using System.ComponentModel.DataAnnotations;


namespace Portfolio.Web.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [StringLength(200)]
        public string ImageUrl { get; set; } = string.Empty; // Ảnh minh họa (từ wwwroot/img/projects)

        [StringLength(200)]
        public string GitHubUrl { get; set; } = string.Empty; // link github

        [StringLength(200)]
        public string LiveDemoUrl { get; set; } = string.Empty; // link youtube hoặc web demo
    }
}
