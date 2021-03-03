
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}