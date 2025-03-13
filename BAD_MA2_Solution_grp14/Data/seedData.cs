using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Providers.Any()) return; // DB already seeded

        var providers = new[]
        {
            new Provider { Name = "Area 51 B&B", BuisnessPhysicalAddress = "51 Classified Rd, Nowhereland", PhoneNumber = "555-UFOZ", CVR = "DKALIEN666" },
            new Provider { Name = "The Time Travelers Agency", BuisnessPhysicalAddress = "1.21 Gigawatt St, Past & Future", PhoneNumber = "555-WE-WERE", CVR = "DK88888888" }
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
            new Experience { Name = "Sleepover at Area 51", Description = "Spend a night in the desert. If you disappear, we are nowhere near", ProviderId = providers[0].ProviderId, Price = 300.00m },
            new Experience { Name = "Time Travel Weekend", Description = "Go back to last Friday to fix your mistakes.", ProviderId = providers[1].ProviderId, Price = 5000.00m },
            new Experience { Name = "Ghost Hunting Bootcamp", Description = "Learn to communicate with the beyond. Refunds are ghostly figures only.", ProviderId = providers[0].ProviderId, Price = 150.00m },
            new Experience { Name = "Jetpack Racing", Description = "Strap in and take off. Legal waivers required.", ProviderId = providers[1].ProviderId, Price = 999.99m }
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
