using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editmilestonetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("13fc1ce7-de4e-4d36-addc-606457d4c2c9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("19c9bb82-146b-45e7-a6b3-1a6c08a45325") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("b3b745a5-8ddc-4a2c-8be0-d6c4a81381e4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("c9b3a09b-11bc-4d40-96dc-4f6363a72d65") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("e08f9a9f-971f-436a-8fd4-68c46a3af06d") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("13fc1ce7-de4e-4d36-addc-606457d4c2c9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19c9bb82-146b-45e7-a6b3-1a6c08a45325"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3b745a5-8ddc-4a2c-8be0-d6c4a81381e4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c9b3a09b-11bc-4d40-96dc-4f6363a72d65"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e08f9a9f-971f-436a-8fd4-68c46a3af06d"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Milestones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Milestones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82a68e4c-71d2-48a1-8503-f1cfe57089b3", "AQAAAAIAAYagAAAAEHEtUMBlNlkCQ0axEuguPOTTGlhIlr/D83wiJjYWc3Kdd8zxFRuQFuxyylpeHO3Xbg==", "b891e2d4-24a7-46c5-aef0-9c46bc54e942" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea3cd68a-d2d4-49ae-ad48-54c6f9e7e7c6", "AQAAAAIAAYagAAAAEJTSXn0ViOTw7ujL1Plp76hQseJi6qqS6utEPrqKQLTUvcfAseMR4wmbk4hzxmd78A==", "d0a95f31-7881-458e-a503-61ecc7fac4f0" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "BirthDay", "ConcurrencyStamp", "CreationTime", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("182f940a-fd2b-4b07-bd00-cc0348e75c0f"), 0, null, null, null, "fba4595b-2d39-487a-9736-25a17f77b9fd", null, "sarah@hotmail.com", true, "Sarah Williams", false, null, "SARAH@HOTMAIL.COM", "SARAH@HOTMAIL.COM", "AQAAAAIAAYagAAAAEFNMYqWtwCMGvbQS9/fVkInWVCntSqEY2f+8BEiyd2JeMQtAsFlCToCHFHfxLXGgZg==", null, false, "c5d4ff8c-b3e0-449d-98e0-e34e922eb912", false, "sarah@hotmail.com" },
                    { new Guid("5c139483-5a0c-4110-91e5-38c44888f5e0"), 0, null, null, null, "d9043b41-447e-4ff7-9510-b0b0e70dd647", null, "brett@gmail.com", true, "Brett Bergnaum", false, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEI98Gco/avUCa7a+4W5lqGivDFp8DDj+Cg2T407FeXLxnD76LFAaKPPBaUSfHcoe8w==", null, false, "86eb7266-6eb6-44e9-ad8a-f701ca7b0b92", false, "brett@gmail.com" },
                    { new Guid("79750d24-ebf9-4f32-b72a-4f82a0905815"), 0, null, null, null, "7cc8c4fe-1317-4ed4-ae50-a36fa683bc3f", null, "james@yahoo.com", true, "James Johnson", false, null, "JAMES@YAHOO.COM", "JAMES@YAHOO.COM", "AQAAAAIAAYagAAAAEOutVPpIItaFcNsGyAlCvW6o6ohAVnf2hJYqGU9MwfyC6z1DCHK4sqL7KYbaQYAVAA==", null, false, "a9d361ba-8a0a-427c-a790-9b1689794caf", false, "james@yahoo.com" },
                    { new Guid("7c3f5cb7-036c-4515-b86f-e87c305f2104"), 0, null, null, null, "52277ee6-f820-40ad-b159-60ba1984797b", null, "emma@gmail.com", true, "Emma Smith", false, null, "EMMA@GMAIL.COM", "EMMA@GMAIL.COM", "AQAAAAIAAYagAAAAEP6ir56Ji4G3jatERdkc3PdDTjAjC3+Uq3xlOMcQkoO6Sh0dmszPtTvvVrdNbYthtA==", null, false, "cd554b71-ae8b-488c-97e9-f4c640eaa321", false, "emma@gmail.com" },
                    { new Guid("8e6d8c0a-0244-4ce0-a7d8-461e551d5d72"), 0, null, null, null, "c8acc195-aeaa-4740-b5a1-efb9cf9c9453", null, "david@outlook.com", true, "David Brown", false, null, "DAVID@OUTLOOK.COM", "DAVID@OUTLOOK.COM", "AQAAAAIAAYagAAAAEHIA+V/gXmvCOtfj+SPrH2IiF5YyFx/6PxOf0/c4yOvN0UEm0B8CDnWOUyb5pM7QCQ==", null, false, "4d15e37c-85aa-48be-8ddd-c5264b881521", false, "david@outlook.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("182f940a-fd2b-4b07-bd00-cc0348e75c0f") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("5c139483-5a0c-4110-91e5-38c44888f5e0") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("79750d24-ebf9-4f32-b72a-4f82a0905815") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("7c3f5cb7-036c-4515-b86f-e87c305f2104") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("8e6d8c0a-0244-4ce0-a7d8-461e551d5d72") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("182f940a-fd2b-4b07-bd00-cc0348e75c0f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("5c139483-5a0c-4110-91e5-38c44888f5e0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("79750d24-ebf9-4f32-b72a-4f82a0905815") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("7c3f5cb7-036c-4515-b86f-e87c305f2104") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("8e6d8c0a-0244-4ce0-a7d8-461e551d5d72") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("182f940a-fd2b-4b07-bd00-cc0348e75c0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c139483-5a0c-4110-91e5-38c44888f5e0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("79750d24-ebf9-4f32-b72a-4f82a0905815"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c3f5cb7-036c-4515-b86f-e87c305f2104"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e6d8c0a-0244-4ce0-a7d8-461e551d5d72"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Milestones");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fab894a8-f218-45a3-800c-1daf8339399d", "AQAAAAIAAYagAAAAEMtGxszBrLSD6/aPzee/GhDbWKC3vkG7n7TcSqvmtwYPw3j6lrPqu+gpcH1HKVIL+w==", "f409dc85-d918-418b-88ff-a36aee12a8a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f33fc516-86c5-42b2-b929-d5eb73d26074", "AQAAAAIAAYagAAAAEPENz+ug2pnvTCytiRiUa0jh4Hwn5Rn2H4JkB9hq3ceyRiAQ8zYodtiCvUevkTQyiA==", "9879e338-335c-4540-bf34-151db6c8af1f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "BirthDay", "ConcurrencyStamp", "CreationTime", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("13fc1ce7-de4e-4d36-addc-606457d4c2c9"), 0, null, null, null, "0e5bf2ed-5439-4ea7-8615-1eb2d3aa74f4", null, "emma@gmail.com", true, "Emma Smith", false, null, "EMMA@GMAIL.COM", "EMMA@GMAIL.COM", "AQAAAAIAAYagAAAAELR2IVkPwG6HZ4geFxwUAwF9bZw31DP+xOh2Jq9eznTkLVcIligYc6Xuc6iWD6nMug==", null, false, "d7236879-886d-43a8-bc3d-f2910cdb55a8", false, "emma@gmail.com" },
                    { new Guid("19c9bb82-146b-45e7-a6b3-1a6c08a45325"), 0, null, null, null, "134dc44e-6722-4f60-83e2-ea2b18aad7c8", null, "james@yahoo.com", true, "James Johnson", false, null, "JAMES@YAHOO.COM", "JAMES@YAHOO.COM", "AQAAAAIAAYagAAAAEHf6DkFbruan1pfA8iIjLgCRzYSuGDRBA35yXLE84iYTizeb5LY+Opm41ciFZZPFbw==", null, false, "b17005cc-75fb-4e1f-b1e9-dd178870b6a5", false, "james@yahoo.com" },
                    { new Guid("b3b745a5-8ddc-4a2c-8be0-d6c4a81381e4"), 0, null, null, null, "f68c31ae-2b85-4e1c-8b3a-2ac115992580", null, "david@outlook.com", true, "David Brown", false, null, "DAVID@OUTLOOK.COM", "DAVID@OUTLOOK.COM", "AQAAAAIAAYagAAAAEKPKhtQ0pJQywKijfs8zv4RdYs80ZHsZRfkniyDnWSUox082bkLpZJyZBGtWr0n1Aw==", null, false, "85be9a73-8729-4831-8298-ef47f2d3b4d4", false, "david@outlook.com" },
                    { new Guid("c9b3a09b-11bc-4d40-96dc-4f6363a72d65"), 0, null, null, null, "878846d8-85b5-4223-bc87-f29351663109", null, "brett@gmail.com", true, "Brett Bergnaum", false, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEPypDalZcMie5VvJBASM8LSw7oa5gXOvMvF9rCZV8NPsCcdRgE2PG/7/Ezd53OHtDw==", null, false, "92624060-0474-4fae-b322-f44ff4e12ac9", false, "brett@gmail.com" },
                    { new Guid("e08f9a9f-971f-436a-8fd4-68c46a3af06d"), 0, null, null, null, "f37fc63c-505d-4027-863f-b3cbe98bce67", null, "sarah@hotmail.com", true, "Sarah Williams", false, null, "SARAH@HOTMAIL.COM", "SARAH@HOTMAIL.COM", "AQAAAAIAAYagAAAAEI21XMI37fNh3J32toS1FuNcKkN4Lc3yhfb6m5kXcgEU46K85Vs7wvqDzqQYudBugw==", null, false, "baa3278b-78ed-4c22-aae0-f70ed3ea226c", false, "sarah@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("13fc1ce7-de4e-4d36-addc-606457d4c2c9") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("19c9bb82-146b-45e7-a6b3-1a6c08a45325") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("b3b745a5-8ddc-4a2c-8be0-d6c4a81381e4") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("c9b3a09b-11bc-4d40-96dc-4f6363a72d65") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("e08f9a9f-971f-436a-8fd4-68c46a3af06d") }
                });
        }
    }
}
