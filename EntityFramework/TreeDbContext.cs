using Microsoft.EntityFrameworkCore;
using Models;

namespace EntityFramework
{
    public class TreeDbContext : DbContext
    {
        public TreeDbContext(DbContextOptions<TreeDbContext> options) : base(options)
        {

        }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<Channel> Channels { get; set; }
    }
}
