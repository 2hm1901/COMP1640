using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class addInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TutorId = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interactions_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactions_AspNetUsers_TutorId",
                        column: x => x.TutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b742c3fe-74b8-4a52-bd01-1785eb88ede0", "AQAAAAIAAYagAAAAECWuooRe6WUQq8zityyotPgVMxGsHg2wMhq9l6BkfWCzTU4HC1At2unMBGn/owf40A==", "5282096f-0271-48db-b437-0708db8ab577" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83edc306-3199-4b4b-880a-94a39647303c", "AQAAAAIAAYagAAAAEGLSs/VWx9LLwJkMhOPbgmj357iMwVAFe22pd2Wzg0Mj/Oj62USF5fxoT6TUoqkQDA==", "a75cfc6f-b34c-47f8-a4e8-23714bdb939b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9797d0b-d20a-45c6-8155-25e03872356c", "AQAAAAIAAYagAAAAEECVnvTYkiV+khJO+eSY7fpTasz30bgzgjkmZoR5euaXML7IuFujLop8QDKdyDqF5g==", "766f87fe-a587-47d6-bd7f-b70b43c10c45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bee82a22-7977-430e-ab5a-a11180776c1a", "AQAAAAIAAYagAAAAEKS/iuwPMzIcq6q66S6v9q5T/Z6VsGWx+9nOxEWOZkjqwNB66PbFGwkZYHYKcsZ2XA==", "a7530f3c-cf55-42eb-97c8-cdf21120d67b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95551c19-cdb0-44ef-91b0-8613366ff382", "AQAAAAIAAYagAAAAEP+/y2a9ecI2QgN8h2V71ToPHg1RO3yiL7TzUz2ZO8dSIQ+RPV4N3NDWCULfYgOrSA==", "104b8f42-1905-4dc4-9e31-8e6aae89e80c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c412d730-613e-4cde-868b-79e584cebfc8", "AQAAAAIAAYagAAAAEAnW2RzupGQsiSsX8qLCFhQgeGJVPP4c+oniTW6hv7xtlI4Ybvbr5gPJ6WDTxkgLhg==", "ec300780-084f-4f97-b3f4-fab595c9ee17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdf8b7f8-0d8d-4fed-8b70-86b6580dfa68", "AQAAAAIAAYagAAAAEPi6TQZpFxjiE530dQLkuIP84millwahsNiqVRKI+El6QgASJy3OBUvGbIanuEthAg==", "b2fbd59f-75ea-407a-8f99-71bcaf70ece5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cd25d51-5e94-451f-a243-5a919623ace7", "AQAAAAIAAYagAAAAEOmJ+zdgxcAalKGhsOqV43cgifHJZZlexK0ffrC5JL/AtPsAwYc83AulWghlK5mH3w==", "c929f5e0-cf6c-44d2-99fa-102d8e4f80ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "805802f8-33c1-480a-ab88-a7a5558339a8", "AQAAAAIAAYagAAAAECJ2LK6+Vh1ltuL2pIA0pJ22+mssdqC9e3NX/jgkoPmW8OI6C2YGCaaFSReMafs5yQ==", "67e10387-cb2c-48cf-b91c-384e7a671689" });

            migrationBuilder.InsertData(
                table: "Interactions",
                columns: new[] { "Id", "StudentId", "Timestamp", "TutorId", "Type" },
                values: new object[,]
                {
                    { 1, "1e64a03d-37b5-4c8c-9985-64383c47a696", new DateTime(2025, 3, 20, 2, 36, 20, 152, DateTimeKind.Utc).AddTicks(1731), "1002", "Uploaded a document" },
                    { 2, "1e64a03d-37b5-4c8c-9985-64383c47a696", new DateTime(2025, 3, 20, 2, 28, 20, 152, DateTimeKind.Utc).AddTicks(1738), "1002", "Sent you a message" },
                    { 3, "1e64a03d-37b5-4c8c-9985-64383c47a696", new DateTime(2025, 3, 20, 2, 13, 20, 152, DateTimeKind.Utc).AddTicks(1740), "1001", "Commented on your document" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_StudentId",
                table: "Interactions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_TutorId",
                table: "Interactions",
                column: "TutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6108ca94-655c-4565-8753-7e959446a1c3", "AQAAAAIAAYagAAAAEH4nFFWpwtjyTcEO/lesr1YvQUUz2wET2+Wom9VOA5uz5MNa1LsccI1PaSqmgOjmkQ==", "cb28367f-69ed-46ca-a461-74693aee29cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ee0aa6b-5525-49ff-a3c3-16c3733bb936", "AQAAAAIAAYagAAAAEPJ7VtmBg381eD5i4bVzQYBBiLLR2f/jpX6Voy+Eg7dXH8Zil48pQ7NnoE4Z0o5ifA==", "051226ce-819a-47a0-9bf1-ca40900d1913" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e17baa9-a3e2-44d9-9fd2-aa1577c2c7f2", "AQAAAAIAAYagAAAAECQRJHJZZUKYUJYuKO3NhKQOHP9MKlhxZsxKRws5ZGNAI0PInhuSBpd/tDpbLmqwAw==", "22668827-3fe6-4be1-9b1c-640c0cb4c15a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bc05003-be36-42d8-85e5-22ec83aef7b6", "AQAAAAIAAYagAAAAEL2KNE4ZTUbLm2Cv50P1RAeEa7fcYF5WlROZrTqpQut4jBajk22k1kWfDGNhPeneHg==", "2fa8fd81-0a7a-4eb6-ba14-42c39736b83f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "309a0ef7-1009-4b11-bb7d-671f386da566", "AQAAAAIAAYagAAAAEO4RHYvpDvNrgtkUE/912TLHrMyX6x4jgN0XZrtdu5PrqNnEe+Sj0pDkYT9B7E7fLA==", "2bbc7d4c-7afc-49e6-88e9-2df0856b088b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c70b2ac0-15c4-43af-8521-61e051f176ba", "AQAAAAIAAYagAAAAEFll+nKqe18rzjXvb5uJWZIl4c9J86MmZrGaqR1dPVyjv0+H/JbmHbwvHvheNPmwVA==", "3198fe29-1b9d-4b96-89e3-72c220954341" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d80f32a8-a90b-484e-81b0-b5487ef9db14", "AQAAAAIAAYagAAAAEOs56VdfKOnqEWKan4Ac4N9s0LrKVStSrwGYUjhbChACUNDwRbtRzVJ4lALB/aFqtA==", "5b0eaa34-f172-45ca-b137-025db6d04eb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "955bff7f-80d0-4c64-b17b-5246fae31d45", "AQAAAAIAAYagAAAAEHDi/3XQ0TqdcFPMcLPrytXjldegXy0SUfXjgx/pyO5a9jPaTXws6vwTkqYkuzlhlQ==", "43704249-68c6-4802-b4a0-9b6a3324fb72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ca565c-3fa4-4cef-896f-4a8f1afaeccb", "AQAAAAIAAYagAAAAEBbIeQDot8LSMmf0bn+KZaowSO+ahrFO6pQyyuPCiGG1CRwbws9YUOb5v7X+5UXYcw==", "7987406d-c2f7-40e7-a1bd-6bff76d23412" });
        }
    }
}
