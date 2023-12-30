using IMS.Domain.Contents;
using IMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Seedings;

public static class SeedingDataSemester
{
    public static void SeedSemester(this ModelBuilder builder)
    {
        builder.Entity<Setting>().HasData(
            new Setting
            {
                Id = 1,
                Type = SettingType.Semester,
                Name = "FAll23",
                Description = "ki mua dong 2023"
            },
            new Setting
            {
                Id = 2,
                Type = SettingType.Semester,
                Name = "SP24",
                Description = "ki mua xuan 2024"
            },
            new Setting
            {
                Id = 3,
                Type = SettingType.Domain,
                Name = "@gmail.com",
                Description = "normal email"
            }, new Setting
            {
                Id = 4,
                Type = SettingType.Domain,
                Name = "@fpt.edu.vn",
                Description = "fpt education"
            });
    }
}
