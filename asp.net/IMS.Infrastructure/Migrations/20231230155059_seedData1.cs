using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Settings",
                columns: new[] { "Id", "CreatedBy", "CreationTime", "Description", "IsActive", "LastModificationTime", "LastModifiedBy", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, null, "ki mua dong 2023", null, null, null, "FAll23", 1 },
                    { 2, null, null, "ki mua xuan 2024", null, null, null, "SP24", 1 },
                    { 3, null, null, "normal email", null, null, null, "@gmail.com", 2 },
                    { 4, null, null, "fpt education", null, null, null, "@fpt.edu.vn", 2 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreationTime", "Description", "IsActive", "LastModificationTime", "LastModifiedBy", "ManagerId", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "SW Architecture and Design", null, null, null, null, "SWD392" },
                    { 2, null, null, "C# Programming and Unity", null, null, null, null, "PRU211m" },
                    { 3, null, null, "Mobile Programming", null, null, null, null, "PRM392" },
                    { 4, null, null, "Experiential Entrepreneurship 1", null, null, null, null, "EXE101" },
                    { 5, null, null, "Advanced Cross-Platform Application Programming With .NET", null, null, null, null, "PRN221" }
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

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "AssigneeId", "CreatedBy", "CreationTime", "Description", "IsActive", "LastModificationTime", "LastModifiedBy", "Name", "SettingId", "SubjectId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, "Se1644-DotNet", 1, 1 },
                    { 2, null, null, null, null, null, null, null, "Se1644-DotNet", 1, 2 },
                    { 3, null, null, null, null, null, null, null, "Se1644-DotNet", 1, 3 },
                    { 4, null, null, null, null, null, null, null, "Se1644-DotNet", 1, 4 },
                    { 5, null, null, null, null, null, null, null, "Se1644-DotNet", 1, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12f44fdb-48aa-4520-ac04-ae2139e97c0f", "AQAAAAIAAYagAAAAEJnQGeDMkPwFmUAzcM7roVs2r0Ju3PaTdNV/rl5dUltRdtiZqW0UINOixWUOPOs0kg==", "5790a16e-4e33-4e7c-bca6-4f2397d75b6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26255f4-5151-4435-93e7-9e0db4b11c1f", "AQAAAAIAAYagAAAAEByq/tN1HKOVYnt16613LqU32fi1FVjxtSGdg7T4TzPrL/WP5YXuzKRrhSHH4OydZg==", "6d14873e-efcf-478b-8d2d-f683abba7edf" });
        }
    }
}
