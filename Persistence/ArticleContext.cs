using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ArticleContext : IdentityDbContext<User>
    {
        public ArticleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<UserArticle> UserArticles { get; set; }

          protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserArticle>(
                x=>x.HasKey(a=> new {a.UserId, a.ArticleId})
            );

            builder.Entity<UserArticle>()
            .HasOne(h=>h.User)
            .WithMany(a=>a.UserArticles)
            .HasForeignKey(x=>x.UserId);

            builder.Entity<UserArticle>()
            .HasOne(h=>h.Article)
            .WithMany(a=>a.UserArticles)
            .HasForeignKey(x=>x.ArticleId);

        }


    }
}