using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
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
        // Composite key for SEDets
        modelBuilder.Entity<SharedExperienceDetail>()
            .HasKey(sed => new { sed.SEId, sed.EId });

        modelBuilder.Entity<SharedExperienceDetail>()
            .HasOne(sed => sed.SharedExperience)
            .WithMany(se => se.SharedExperienceDetails)
            .HasForeignKey(sed => sed.SEId);

        modelBuilder.Entity<SharedExperienceDetail>()
            .HasOne(sed => sed.Experience)
            .WithMany(e => e.SharedExperienceDetails)
            .HasForeignKey(sed => sed.EId);

        // Composite key for SEGuests
        modelBuilder.Entity<SharedExperienceGuest>()
            .HasKey(seg => new { seg.SEId, seg.GId });

        modelBuilder.Entity<SharedExperienceGuest>()
            .HasOne(seg => seg.SharedExperience)
            .WithMany(se => se.SharedExperienceGuests)
            .HasForeignKey(seg => seg.SEId);

        modelBuilder.Entity<SharedExperienceGuest>()
            .HasOne(seg => seg.Guest)
            .WithMany(g => g.SharedExperienceGuests)
            .HasForeignKey(seg => seg.GId);
    }
}