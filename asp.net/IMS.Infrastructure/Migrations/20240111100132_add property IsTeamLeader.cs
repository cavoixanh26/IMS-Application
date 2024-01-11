using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpropertyIsTeamLeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("09f5d524-3f62-45ab-8de4-c377fd946ad2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("1277f2d7-a5f8-48ee-a668-cb876553d93a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("5f9f15b1-2221-4f46-93c5-380e91232681") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("85acd311-b607-4e39-82ba-5d69a12f3449") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("88bc95b8-63a5-4758-8225-49e18901207d") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09f5d524-3f62-45ab-8de4-c377fd946ad2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1277f2d7-a5f8-48ee-a668-cb876553d93a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f9f15b1-2221-4f46-93c5-380e91232681"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85acd311-b607-4e39-82ba-5d69a12f3449"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88bc95b8-63a5-4758-8225-49e18901207d"));

            migrationBuilder.AddColumn<bool>(
                name: "IsTeamleader",
                table: "ProjectMembers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsTeamleader",
                table: "ProjectMembers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa406451-8d89-4bd9-968a-40a12f97a71a", "AQAAAAIAAYagAAAAEENBxAfKIt6fLqdEZtZId7L5hHyZJa+8bJ2wizzN1ZdLJCd4FUcMB4zIUyv5VGdKMA==", "0dbefec4-2930-423c-9685-87927fe2623b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2c16cd2-464d-4558-86f3-bc5375d7e900", "AQAAAAIAAYagAAAAEMKQsAHQAe6G6HgR3RbkCgEWq9MOlhZP3xE8baa+9VMKldsx1Q9VG0jTFH2lxL6Fzg==", "903fea34-2dcb-4b4b-b3ce-3a5a9df882bc" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "BirthDay", "ConcurrencyStamp", "CreationTime", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("09f5d524-3f62-45ab-8de4-c377fd946ad2"), 0, null, null, null, "9955ba9e-94fd-47a5-bcd9-b2b6084fc7aa", null, "brett@gmail.com", true, "Brett Bergnaum", false, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEL0iAlsKoVHvn/dI67i/orAtbIWiFDGL5AxZNn3O03WiiGj/kfPStQJRz3on03JoWA==", null, false, "8e525db7-7f3c-4907-9d5a-2503e3094a01", false, "brett@gmail.com" },
                    { new Guid("1277f2d7-a5f8-48ee-a668-cb876553d93a"), 0, null, null, null, "4caebd14-c5fe-44e7-844f-caed756f9341", null, "david@outlook.com", true, "David Brown", false, null, "DAVID@OUTLOOK.COM", "DAVID@OUTLOOK.COM", "AQAAAAIAAYagAAAAEKUKXurn8IXsuMC7WFVgxVkpIiyxz/+hxw26fVrSWj/0iKXtO1ks1VOCdXm4foDOfQ==", null, false, "5c684e90-f980-4511-9d5c-0f04112f90e8", false, "david@outlook.com" },
                    { new Guid("5f9f15b1-2221-4f46-93c5-380e91232681"), 0, null, null, null, "a5abdf7c-e1fa-49be-9994-47e6c3ecfe21", null, "sarah@hotmail.com", true, "Sarah Williams", false, null, "SARAH@HOTMAIL.COM", "SARAH@HOTMAIL.COM", "AQAAAAIAAYagAAAAEI95sjpBOwJUpdrgBgPc8HtJkwBJ+PPxBPGwWMV/cEG78TJdN6Y46ugS9JCj5L0VfA==", null, false, "027febb6-c08f-4078-9357-95670d64486f", false, "sarah@hotmail.com" },
                    { new Guid("85acd311-b607-4e39-82ba-5d69a12f3449"), 0, null, null, null, "f118d276-13c3-4eab-9b20-d7755fa5d2fc", null, "emma@gmail.com", true, "Emma Smith", false, null, "EMMA@GMAIL.COM", "EMMA@GMAIL.COM", "AQAAAAIAAYagAAAAEBOBrlNEUTXz0WcAOjg42MBwWwSsHmASeZwtGmwczYLT141GOiE9kluKI3iALEAz0w==", null, false, "a5aa5c3c-012f-4121-9fbb-2e06757970bc", false, "emma@gmail.com" },
                    { new Guid("88bc95b8-63a5-4758-8225-49e18901207d"), 0, null, null, null, "adcfe73e-d43d-4913-8c7e-2a6deaa400be", null, "james@yahoo.com", true, "James Johnson", false, null, "JAMES@YAHOO.COM", "JAMES@YAHOO.COM", "AQAAAAIAAYagAAAAECxB0qcqz/pG2Uvg3k0hL8EPQQU7kn1MzL03ZxgC3PTSj/r+m/8HJ6+NxNVi0n8rkg==", null, false, "b2934344-f4cc-4039-b983-2a23111e51dc", false, "james@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("09f5d524-3f62-45ab-8de4-c377fd946ad2") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("1277f2d7-a5f8-48ee-a668-cb876553d93a") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("5f9f15b1-2221-4f46-93c5-380e91232681") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("85acd311-b607-4e39-82ba-5d69a12f3449") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("88bc95b8-63a5-4758-8225-49e18901207d") }
                });
        }
    }
}
