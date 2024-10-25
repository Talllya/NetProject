using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable(entity.GetType().Name);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Owner).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired().HasMaxLength(20);
                entity.Property(e => e.ShoppingTime).IsRequired();
            });
        }
    }
}
