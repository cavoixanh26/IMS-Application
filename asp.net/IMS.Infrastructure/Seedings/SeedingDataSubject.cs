using IMS.Domain.Contents;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Seedings;

public static class SeedingDataSubject
{
    public static void SeedSubject(this ModelBuilder builder)
    {
        builder.Entity<Subject>().HasData(
            new Subject
            {
                Id = 1,
                Name = "SWD392",
                Description = "SW Architecture and Design"
            },
            new Subject
            {
                Id = 2,
                Name = "PRU211m",
                Description = "C# Programming and Unity"
            },
            new Subject
            {
                Id = 3,
                Name = "PRM392",
                Description = "Mobile Programming"
            },
            new Subject
            {
                Id = 4,
                Name = "EXE101",
                Description = "Experiential Entrepreneurship 1"
            },
            new Subject
            {
                Id = 5,
                Name = "PRN221",
                Description = "Advanced Cross-Platform Application Programming With .NET"
            });
    }
}
