using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class addChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<string>(type: "text", nullable: false),
                    ReceiverId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e12d776-c1da-4310-87ff-6ef1acbeea0b", "AQAAAAIAAYagAAAAEPUo8cDI3mQBAfG4Blc9f2FI6FNSx8HsUUiuf/VytNc2HoHCmVv86oKGtq4pIwk6/Q==", "673a991b-d11a-4f16-acf8-46342b0f0116" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eec8de25-3b0e-4df6-8671-afcf58c7c540", "AQAAAAIAAYagAAAAEN6XIwLDP2UOJjBuqCi6qYLNFOjULlzV56PHPVSJOGXOZnaRA3a9GYe5BbzYQmx9ug==", "08b88a12-482c-4351-9656-39a1222c338b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b9b0220-844c-4a8a-8724-9eed7447cc1b", "AQAAAAIAAYagAAAAEFSVWn5pzW4c5fndcZR08XNMSndR+zpDDeorpZ61swosuKzZJ9PDZ/ApXTXQwlHyHA==", "feb55e50-7270-4e26-a618-fbf1e9764e4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19d71403-6437-4155-b2fa-386224ebccac", "AQAAAAIAAYagAAAAEH0KAnFZlUfWj7xI5c/YNgRN0eoulT98g1EH/AyQqbNGwHjj8jL0eBsrgb1Y5Tf3bA==", "35f92952-12d4-40ac-8c6c-ac028538f845" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62e16161-89f4-4e8e-9eb8-f693ddecf387", "AQAAAAIAAYagAAAAEPgpSnKRTgng4y7E/YL+n9GwXKTliEqo4AObL7X85jxFNlKVVNcnEMD9ubEEssj5UQ==", "aad47b2a-4895-4576-ba96-5b64364ccc79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f406cc56-fcc3-489d-97e0-da2ceb515048", "AQAAAAIAAYagAAAAEDq9uv9QZ3FrSODXC8oc8u7+rk6smzw4nB2Vdr9Nop67BxxxatGRsJuKiGn1BhIRMg==", "74c34d42-5a44-4fe3-bb7d-d74dc862c2ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e861f82-f023-422e-ae23-c4832bf1d013", "AQAAAAIAAYagAAAAEFIDvUGU5UPCVzlf0i75ow662XYPs23fnVIj9YcAkJ2mmeqO1vBaI4mGWOwt6tWTNg==", "0d5439c5-bbbe-48aa-866a-e5271748ffc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40e7bf05-ca91-4f21-b068-803c33d90c42", "AQAAAAIAAYagAAAAECqVv2t2V5JO1qA1NkHbGEyjn4DTAGJ9SUTb5h7AbwNnj+yFoCQMgoViWxdsRUwdkQ==", "c787d20e-23bc-4928-9880-dd894aa79901" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e310e265-1308-495d-bb49-94bb93a06e7f", "AQAAAAIAAYagAAAAEP8l8DcbAT5ZaTua2T5HU/M766w2qXP0L7FzycdPdWB2VSsUwEEa9YdkYwnL91svfw==", "b720fb8d-5ca6-47ba-9f89-e8b6a783f625" });
        }
    }
}
