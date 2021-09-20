using Graduate_work.EfStuff.Model;
using Graduate_work.Model;
using Microsoft.EntityFrameworkCore;

namespace Graduate_work.EfStuff
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.CommentsCreatedByMe)
                .WithOne(x => x.Creater);

            modelBuilder.Entity<User>()
                .HasMany(x => x.PicturesCreatedByMe)
                .WithOne(x => x.Creater);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }

}

