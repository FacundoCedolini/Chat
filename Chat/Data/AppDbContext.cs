// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using Chat.Models;

namespace Chat.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Models.Message> Messages => Set<Models.Message>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NB700\\SQLEXPRESS;Database=ChatAppDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
