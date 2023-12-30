using IMS.Domain.Systems;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Seedings
{
	public static class SeedingDataIdentity
	{
		public static void SeedData(this ModelBuilder builder)
		{
			var roleUserId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf");
			var roleAdminId = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf");
			builder.Entity<AppRole>().HasData(
				new AppRole
				{
					Id = roleUserId,
					Description = "User role",
					Name = "User",
					NormalizedName = "USER",
					
				},
				new AppRole
				{
					Id = roleAdminId,
					Description = "Admin role",
					Name = "Admin",
					NormalizedName = "ADMIN",
					
				}
			);

			var hasher = new PasswordHasher<AppUser>();
			var adminId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9");
			var userId = new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9");
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            var userId4 = Guid.NewGuid();
            var userId5 = Guid.NewGuid();

            builder.Entity<AppUser>().HasData(
				 new AppUser
				 {
					 Id = adminId,
					 Email = "admin@gmail.com",
					 NormalizedEmail = "ADMIN@GMAIL.COM",
					 FullName = "System",
					 UserName = "admin@gmail.com",
					 NormalizedUserName = "ADMIN@GMAIL.COM",
					 PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
					 EmailConfirmed = true,
					 SecurityStamp = Guid.NewGuid().ToString(),
				 },
				 new AppUser
				 {
					 Id = userId,
					 Email = "user@gmail.com",
					 NormalizedEmail = "USER@GMAIL.COM",
					 FullName = "User",
					 UserName = "user@gmail.com",
					 NormalizedUserName = "USER@GMAIL.COM",
					 PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
					 EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                 },
                 new AppUser
                 {
                     Id = userId1,
                     Email = "brett@gmail.com",
                     NormalizedEmail = "BRETT@GMAIL.COM",
                     FullName = "Brett Bergnaum",
                     UserName = "brett@gmail.com",
                     NormalizedUserName = "BRETT@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                 },
                 new AppUser
                 {
                     Id = userId2,
                     Email = "emma@gmail.com",
                     NormalizedEmail = "EMMA@GMAIL.COM",
                     FullName = "Emma Smith",
                     UserName = "emma@gmail.com",
                     NormalizedUserName = "EMMA@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                 },
                 new AppUser
                 {
                     Id = userId3,
                     Email = "james@yahoo.com",
                     NormalizedEmail = "JAMES@YAHOO.COM",
                     FullName = "James Johnson",
                     UserName = "james@yahoo.com",
                     NormalizedUserName = "JAMES@YAHOO.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                 },
                 new AppUser
                 {
                     Id = userId4,
                     Email = "sarah@hotmail.com",
                     NormalizedEmail = "SARAH@HOTMAIL.COM",
                     FullName = "Sarah Williams",
                     UserName = "sarah@hotmail.com",
                     NormalizedUserName = "SARAH@HOTMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                 },
                 new AppUser
                 {
                     Id = userId5,
                     Email = "david@outlook.com",
                     NormalizedEmail = "DAVID@OUTLOOK.COM",
                     FullName = "David Brown",
                     UserName = "david@outlook.com",
                     NormalizedUserName = "DAVID@OUTLOOK.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                 }
            );

			builder.Entity<IdentityUserRole<Guid>>().HasData(
				new IdentityUserRole<Guid>
				{
					RoleId = roleAdminId,
					UserId = adminId
				},
				new IdentityUserRole<Guid>
				{
					RoleId = roleUserId,
					UserId = userId
				},
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId1
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId2
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId3
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId4
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId5
                }
                );
		}
	}
}
