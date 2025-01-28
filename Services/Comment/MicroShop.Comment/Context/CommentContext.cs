using MicroShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1444;initial Catalog=MicroShopCommentDb;User=sa; Password=123456aA*");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
