using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Seedings;

public static class SeedingDataClass
{
    public static void SeedClass(this ModelBuilder builder)
    {
        builder.Entity<IMS.Domain.Contents.Class>().HasData(
            new Domain.Contents.Class
            {
                Id = 1,
                Name = "Se1644-DotNet",
                SubjectId = 1,
                SettingId = 1,
            },
            new Domain.Contents.Class
            {
                Id = 2,
                Name = "Se1644-DotNet",
                SubjectId = 2,
                SettingId = 1,
            },
            new Domain.Contents.Class
            {
                Id = 3,
                Name = "Se1644-DotNet",
                SubjectId = 3,
                SettingId = 1,
            }, new Domain.Contents.Class
            {
                Id = 4,
                Name = "Se1644-DotNet",
                SubjectId = 4,
                SettingId = 1,
            }, new Domain.Contents.Class
            {
                Id = 5,
                Name = "Se1644-DotNet",
                SubjectId = 5,
                SettingId = 1,
            });
    }
}
