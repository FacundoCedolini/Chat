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
            optionsBuilder.UseSqlServer("workstation id=CodaChatAppDb.mssql.somee.com;packet size=4096;user id=Firo7_SQLLogin_2;pwd=yk5q5yi9so;data source=CodaChatAppDb.mssql.somee.com;persist security info=False;initial catalog=CodaChatAppDb;TrustServerCertificate=True");
        }
    }
}
