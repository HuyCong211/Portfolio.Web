using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace Portfolio.Web.Data
{
    public class AppDbContext : DbContext, IDataProtectionKeyContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ⚙️ Bảng lưu key mã hóa cho DataProtection
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }


    }
}
