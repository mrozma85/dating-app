using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<UserLike> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserLike>()
            .HasKey(k => new {k.SourceUserId, k.TargetUserId});
        
        builder.Entity<UserLike>()
            .HasOne(s => s.SourceUser) // daje like it
            .WithMany(l => l.LikedUsers) // otrzymuje like it
            .HasForeignKey(s => s.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
            .HasOne(s => s.TargetUser) // otrzrymuje like it
            .WithMany(l => l.LikedByUsers) // ma wielu zanjomych
            .HasForeignKey(s => s.TargetUserId) 
            .OnDelete(DeleteBehavior.Cascade); // in sql .NoAction
    }
}