// SeedData.cs
using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Providers.Any()) return; // DB already seeded

        var providers = new[]
        {
            new Provider { Name = "Area 51 B&B", BPA = "51 Classified Rd, Nowhereland", PhoneNum = "555-UFOZ", CVR = "DKALIEN666" },
            new Provider { Name = "The Time Travelers Agency", BPA = "1.21 Gigawatt St, Past & Future", PhoneNum = "555-WE-WERE", CVR = "DK88888888" }
        };
        context.Providers.AddRange(providers);

        var guests = new[]
        {
            new Guest { Name = "Florida Man", Age = 37, PhoneNum = "555-GATOR" },
            new Guest { Name = "Elon Dust", Age = 52, PhoneNum = "555-SPACEX" },
            new Guest { Name = "Captain Obvious", Age = 69, PhoneNum = "555-OBVIOUS" },
            new Guest { Name = "The Loch Ness Monster", Age = 1500, PhoneNum = "555-NEVERSEEN" }
        };
        context.Guests.AddRange(guests);

        context.SaveChanges();

        var experiences = new[]
        {
            new Experience { Name = "Sleepover at Area 51", Description = "Spend a night in the desert. If you disappear, we are nowhere near", ProvId = providers[0].ProvId, Price = 300.00m },
            new Experience { Name = "Time Travel Weekend", Description = "Go back to last Friday to fix your mistakes.", ProvId = providers[1].ProvId, Price = 5000.00m },
            new Experience { Name = "Ghost Hunting Bootcamp", Description = "Learn to communicate with the beyond. Refunds are ghostly figures only.", ProvId = providers[0].ProvId, Price = 150.00m },
            new Experience { Name = "Jetpack Racing", Description = "Strap in and take off. Legal waivers required.", ProvId = providers[1].ProvId, Price = 999.99m }
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
            new SharedExperienceDetail { SEId = sharedExperiences[0].SEId, EId = experiences[0].EId },
            new SharedExperienceDetail { SEId = sharedExperiences[0].SEId, EId = experiences[1].EId },
            new SharedExperienceDetail { SEId = sharedExperiences[1].SEId, EId = experiences[2].EId },
            new SharedExperienceDetail { SEId = sharedExperiences[1].SEId, EId = experiences[3].EId }
        };
        context.SharedExperienceDetails.AddRange(sedets);

        var seguests = new[]
        {
            new SharedExperienceGuest { SEId = sharedExperiences[0].SEId, GId = guests[0].GId },
            new SharedExperienceGuest { SEId = sharedExperiences[0].SEId, GId = guests[1].GId },
            new SharedExperienceGuest { SEId = sharedExperiences[1].SEId, GId = guests[2].GId },
            new SharedExperienceGuest { SEId = sharedExperiences[1].SEId, GId = guests[3].GId }
        };
        context.SharedExperienceGuests.AddRange(seguests);

        context.SaveChanges();
    }
}
