using BooksSearchSystem.Models;
using Microsoft.EntityFrameworkCore;
using BooksSearchSystem.Models;

namespace BooksSearchSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public  DbSet<User> Users { get; set; } // DbSet 用於存取 Users 表
    }
}
