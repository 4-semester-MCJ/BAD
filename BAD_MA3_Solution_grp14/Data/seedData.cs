using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Create roles
        string[] roleNames = { "Admin", "Manager", "Provider", "Guest" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create admin user
        var adminEmail = "admin@badboys.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(adminUser, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Create test users for other roles
        var testUsers = new[]
        {
            new { Email = "manager@badboys.com", Password = "Manager123!", Role = "Manager" },
            new { Email = "provider@badboys.com", Password = "Provider123!", Role = "Provider" },
            new { Email = "guest@badboys.com", Password = "Guest123!", Role = "Guest" }
        };

        foreach (var testUser in testUsers)
        {
            var user = await userManager.FindByEmailAsync(testUser.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = testUser.Email,
                    Email = testUser.Email,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, testUser.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, testUser.Role);
                }
            }
        }
    }

    public static void Initialize(AppDbContext context)
    {
        if (context.Providers.Any()) return; // DB already seeded

        var providers = new[]
        {
            new Provider { Name = "Area 51 B&B", BuisnessPhysicalAddress = "51 Classified Rd, Nowhereland", PhoneNumber = "555-UFOZ", TouristicOperatorPermitPdf = "PDF1" },
            new Provider { Name = "The Time Travelers Agency", BuisnessPhysicalAddress = "1.21 Gigawatt St, Past & Future", PhoneNumber = "555-WE-WERE", TouristicOperatorPermitPdf = "PDF2" }
        };
        context.Providers.AddRange(providers);

        var guests = new[]
        {
            new Guest { Name = "Florida Man", Age = 37, PhoneNumber = "555-GATOR" },
            new Guest { Name = "Elon Dust", Age = 52, PhoneNumber = "555-SPACEX" },
            new Guest { Name = "Captain Obvious", Age = 69, PhoneNumber = "555-OBVIOUS" },
            new Guest { Name = "The Loch Ness Monster", Age = 1500, PhoneNumber = "555-NEVERSEEN" }
        };
        context.Guests.AddRange(guests);

        context.SaveChanges();

        var experiences = new[]
        {
            new Experience { Name = "Sleepover at Area 51", Description = "Spend a night in the desert. If you disappear, we are nowhere near", ProviderId = providers[0].ProviderId, Price = 300 },
            new Experience { Name = "Time Travel Weekend", Description = "Go back to last Friday to fix your mistakes.", ProviderId = providers[1].ProviderId, Price = 5000 },
            new Experience { Name = "Ghost Hunting Bootcamp", Description = "Learn to communicate with the beyond. Refunds are ghostly figures only.", ProviderId = providers[0].ProviderId, Price = 150 },
            new Experience { Name = "Jetpack Racing", Description = "Strap in and take off. Legal waivers required.", ProviderId = providers[1].ProviderId, Price = 999 }
        };
        context.Experiences.AddRange(experiences);
        context.SaveChanges();

        var sharedExperiences = new[]
        {
            new SharedExperience { Name = "Parallel Universe Trip", Date = new DateTime(2025, 3, 1) },
            new SharedExperience { Name = "Flat Earth Cruise", Date = new DateTime(2025, 4, 10) }
        };
        context.SharedExperiences.AddRange(sharedExperiences);
        context.SaveChanges();

        var sedets = new[]
        {
            new SharedExperienceDetail { SharedExperienceId = sharedExperiences[0].SharedExperienceId, ExperienceId = experiences[0].ExperienceId },
            new SharedExperienceDetail { SharedExperienceId = sharedExperiences[0].SharedExperienceId, ExperienceId = experiences[1].ExperienceId },
            new SharedExperienceDetail { SharedExperienceId = sharedExperiences[1].SharedExperienceId, ExperienceId = experiences[2].ExperienceId },
            new SharedExperienceDetail { SharedExperienceId = sharedExperiences[1].SharedExperienceId, ExperienceId = experiences[3].ExperienceId }
        };
        context.SharedExperienceDetails.AddRange(sedets);

        var seguests = new[]
        {
            new SharedExperienceGuest { SharedExperienceId = sharedExperiences[0].SharedExperienceId, GuestId = guests[0].GuestId },
            new SharedExperienceGuest { SharedExperienceId = sharedExperiences[0].SharedExperienceId, GuestId = guests[1].GuestId },
            new SharedExperienceGuest { SharedExperienceId = sharedExperiences[1].SharedExperienceId, GuestId = guests[2].GuestId },
            new SharedExperienceGuest { SharedExperienceId = sharedExperiences[1].SharedExperienceId, GuestId = guests[3].GuestId }
        };
        context.SharedExperienceGuests.AddRange(seguests);

        context.SaveChanges();
    }
}
