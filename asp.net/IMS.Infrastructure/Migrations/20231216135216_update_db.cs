using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_AspNetUsers_UserId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AssigneeId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Milestones_MilestoneId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ClassStudents",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudents_UserId",
                table: "ClassStudents",
                newName: "IX_ClassStudents_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MilestoneId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_AspNetUsers_StudentId",
                table: "ClassStudents",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AssigneeId",
                table: "Issues",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Milestones_MilestoneId",
                table: "Issues",
                column: "MilestoneId",
                principalTable: "Milestones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_AspNetUsers_StudentId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AssigneeId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Milestones_MilestoneId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ClassStudents",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                newName: "IX_ClassStudents_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MilestoneId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "407d2e60-410c-438e-b3a1-ff14ef2dec90", "AQAAAAIAAYagAAAAEM6WyTmmmhV9SWZnCPqtCgLqDMf7ST+tRVIknmNI7SmD4k+LZdu19wZP4OGYt49Nkw==", "bba12435-928f-4926-90d0-0ff3009a5149" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8534f8fc-eb77-4667-812c-f7a711718c92", "AQAAAAIAAYagAAAAEIQt1Gp/F+pLbHho9f/kTKLf6U/PuvZ1NX/8QdRzklqJ2bo/ZsC4cG2phI3KTTi7Cg==", "2e257193-654d-46b6-b10c-2986c18797f2" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_AspNetUsers_UserId",
                table: "ClassStudents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AssigneeId",
                table: "Issues",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Milestones_MilestoneId",
                table: "Issues",
                column: "MilestoneId",
                principalTable: "Milestones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
