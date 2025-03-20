using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class sampleStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "MessageCount", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TutorId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2001", 0, "62e16161-89f4-4e8e-9eb8-f693ddecf387", "student1@gmail.com", true, "Bui Quang Minh", false, null, 350, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAIAAYagAAAAEPgpSnKRTgng4y7E/YL+n9GwXKTliEqo4AObL7X85jxFNlKVVNcnEMD9ubEEssj5UQ==", null, false, "aad47b2a-4895-4576-ba96-5b64364ccc79", "1001", false, "student1@gmail.com" },
                    { "2002", 0, "f406cc56-fcc3-489d-97e0-da2ceb515048", "student2@gmail.com", true, "Nguyen Hoang Anh", false, null, 220, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAIAAYagAAAAEDq9uv9QZ3FrSODXC8oc8u7+rk6smzw4nB2Vdr9Nop67BxxxatGRsJuKiGn1BhIRMg==", null, false, "74c34d42-5a44-4fe3-bb7d-d74dc862c2ac", "1002", false, "student2@gmail.com" },
                    { "2003", 0, "5e861f82-f023-422e-ae23-c4832bf1d013", "student3@gmail.com", true, "Tran Bao Ngoc", false, null, 100, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAIAAYagAAAAEFIDvUGU5UPCVzlf0i75ow662XYPs23fnVIj9YcAkJ2mmeqO1vBaI4mGWOwt6tWTNg==", null, false, "0d5439c5-bbbe-48aa-866a-e5271748ffc3", null, false, "student3@gmail.com" },
                    { "2004", 0, "40e7bf05-ca91-4f21-b068-803c33d90c42", "student4@gmail.com", true, "Pham Tuan Kiet", false, null, 75, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAIAAYagAAAAECqVv2t2V5JO1qA1NkHbGEyjn4DTAGJ9SUTb5h7AbwNnj+yFoCQMgoViWxdsRUwdkQ==", null, false, "c787d20e-23bc-4928-9880-dd894aa79901", "1001", false, "student4@gmail.com" },
                    { "2005", 0, "e310e265-1308-495d-bb49-94bb93a06e7f", "student5@gmail.com", true, "Le Hong Phong", false, null, 50, "STUDENT5@GMAIL.COM", "STUDENT5@GMAIL.COM", "AQAAAAIAAYagAAAAEP8l8DcbAT5ZaTua2T5HU/M766w2qXP0L7FzycdPdWB2VSsUwEEa9YdkYwnL91svfw==", null, false, "b720fb8d-5ca6-47ba-9f89-e8b6a783f625", null, false, "student5@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "2001" },
                    { "1", "2002" },
                    { "1", "2003" },
                    { "1", "2004" },
                    { "1", "2005" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2002" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2003" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2004" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2005" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2004");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2005");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cee91477-96dd-4350-b59f-43a92a9e8af4", "AQAAAAIAAYagAAAAEDOAnPJVaDrWuRB04wgvQA+ACKbzz8U9jHI+HxL/miasOjKAAdEV19bUzXTHnbwLUg==", "21e3f9ae-552f-452a-8951-d78b63938c7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31f4d9bb-efb7-4477-bd15-3822006b0eed", "AQAAAAIAAYagAAAAEBI6QYbVTVxrHxta5aiO87NSRa/ZwknmVoUXpj0kgzAT3zvvk8Vug3hf9NwOlrWglg==", "89fc8684-6b56-48eb-b8fd-7eb97991a669" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0786bb38-be4c-4e2e-b8aa-f7069a2efe2f", "AQAAAAIAAYagAAAAEKNMhyZ1xAM4Wf7bOXbn1ZEaBeivuqNIKzO/euNjESBDBRKWQzD9v+yi/Sf+Sj9lfw==", "ec8d934e-345d-486c-b686-236d4276de72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3251f90d-8085-40c4-a7a6-3ddec445c985", "AQAAAAIAAYagAAAAEKeL/GdHRuj4EIXpayTOMJQ+l5Uum5P7luW2tTMIdk5xempn8saXskBpACx4rgr1/Q==", "bdc66680-8387-438f-8673-d5ad5b4835d7" });
        }
    }
}
