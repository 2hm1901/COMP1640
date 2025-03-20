using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class createSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Student", "STUDENT" },
                    { "2", null, "Teacher", "TEACHER" },
                    { "3", null, "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1001", 0, "2c2ff62f-6052-4f57-82ab-8307f3a440c1", "teacher@gmail.com", true, "Nhu Vinh", false, null, "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAIAAYagAAAAEGlPbBcznoIHEZsEIWZ2bZFMKrcBSKF1n4QR5Ir9V4dSJWGSPwbF68kBs2O1Ca+QQg==", null, false, "Teacher", "b88b1d76-44b1-4a5f-8805-571059f292d5", false, "teacher@gmail.com" },
                    { "1002", 0, "411c49a2-bc17-4f11-9c90-773fc420b067", "teacher2@gmail.com", true, "Thanh Tra", false, null, "TEACHER2@GMAIL.COM", "TEACHER2@GMAIL.COM", "AQAAAAIAAYagAAAAEDIzfKUMwmI2X0u+Jc67LkCaTi6OTDQQrcLVPGG8ba/gZBH/dtUC1s1FYGEMrrCz1Q==", null, false, "Teacher", "bb06cbac-cc7f-47d3-8480-d6e3e121e361", false, "teacher2@gmail.com" },
                    { "1003", 0, "deae0714-564a-44a8-a2af-8a8d276c1565", "staff@gmail.com", true, "Nathan Json", false, null, "STAFF@GMAIL.COM", "STAFF@GMAIL.COM", "AQAAAAIAAYagAAAAEDWOvTiIA+Jjvy6umDmddZzOuMKSK5gNps5GwgYQHHqW2rqm6q0jgAlBIcwZykQZPQ==", null, false, "Staff", "b3f33663-c741-46f3-8a9e-f2e8f60c4611", false, "staff@gmail.com" },
                    { "1004", 0, "875831ad-a1d9-4c01-8392-f67961d81e67", "staff2@gmail.com", true, "Ly Tieu Long", false, null, "STAFF2@GMAIL.COM", "STAFF2@GMAIL.COM", "AQAAAAIAAYagAAAAEFIlFNBtX8RIIqSjjzhPfvJNGx+m/UuA3xN5Csv33lQOc45nx6RUcxObzMVc0hyPmA==", null, false, "Staff", "d370433f-677d-4d7b-99a5-7367c8795828", false, "staff2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "1001" },
                    { "2", "1002" },
                    { "3", "1003" },
                    { "3", "1004" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "1001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "1002" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "1003" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "1004" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004");
        }
    }
}
