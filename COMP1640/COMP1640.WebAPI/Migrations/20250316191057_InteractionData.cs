using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InteractionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountStatus", "Avatar", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "Password", "Role", "TeacherId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 0, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 0, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 1, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 0, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 1, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 0, null, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Interactions",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "OtherAccountId", "OwnerId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "User A interacted with User B", 2, 1, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "User C liked User D's post", 4, 3, 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
