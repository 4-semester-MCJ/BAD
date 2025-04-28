using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
}

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Provider> Providers { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<SharedExperience> SharedExperiences { get; set; }
    public DbSet<SharedExperienceDetail> SharedExperienceDetails { get; set; }
    public DbSet<SharedExperienceGuest> SharedExperienceGuests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Identity tables
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.UserId, r.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        // Composite key for SharedExperienceDetails
        modelBuilder.Entity<SharedExperienceDetail>()
            .HasKey(sed => new { sed.SharedExperienceId, sed.ExperienceId });

        modelBuilder.Entity<SharedExperienceDetail>()
            .HasOne(sed => sed.SharedExperience)
            .WithMany(se => se.SharedExperienceDetails)
            .HasForeignKey(sed => sed.SharedExperienceId);

        modelBuilder.Entity<SharedExperienceDetail>()
            .HasOne(sed => sed.Experience)
            .WithMany(e => e.SharedExperienceDetails)
            .HasForeignKey(sed => sed.ExperienceId);

        // Composite key for SharedExperienceGuests
        modelBuilder.Entity<SharedExperienceGuest>()
            .HasKey(seg => new { seg.SharedExperienceId, seg.GuestId });

        modelBuilder.Entity<SharedExperienceGuest>()
            .HasOne(seg => seg.SharedExperience)
            .WithMany(se => se.SharedExperienceGuests)
            .HasForeignKey(seg => seg.SharedExperienceId);

        modelBuilder.Entity<SharedExperienceGuest>()
            .HasOne(seg => seg.Guest)
            .WithMany(g => g.SharedExperienceGuests)
            .HasForeignKey(seg => seg.GuestId);

        modelBuilder.Entity<Experience>()
            .Property(e => e.Price)
            .HasColumnType("int");
    }
}
