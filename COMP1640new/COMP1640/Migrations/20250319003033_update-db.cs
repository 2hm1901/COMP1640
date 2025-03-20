using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageCount",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TutorId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "MessageCount", "PasswordHash", "SecurityStamp", "TutorId" },
                values: new object[] { "cee91477-96dd-4350-b59f-43a92a9e8af4", 0, "AQAAAAIAAYagAAAAEDOAnPJVaDrWuRB04wgvQA+ACKbzz8U9jHI+HxL/miasOjKAAdEV19bUzXTHnbwLUg==", "21e3f9ae-552f-452a-8951-d78b63938c7a", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "MessageCount", "PasswordHash", "SecurityStamp", "TutorId" },
                values: new object[] { "31f4d9bb-efb7-4477-bd15-3822006b0eed", 0, "AQAAAAIAAYagAAAAEBI6QYbVTVxrHxta5aiO87NSRa/ZwknmVoUXpj0kgzAT3zvvk8Vug3hf9NwOlrWglg==", "89fc8684-6b56-48eb-b8fd-7eb97991a669", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "MessageCount", "PasswordHash", "SecurityStamp", "TutorId" },
                values: new object[] { "0786bb38-be4c-4e2e-b8aa-f7069a2efe2f", 0, "AQAAAAIAAYagAAAAEKNMhyZ1xAM4Wf7bOXbn1ZEaBeivuqNIKzO/euNjESBDBRKWQzD9v+yi/Sf+Sj9lfw==", "ec8d934e-345d-486c-b686-236d4276de72", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "MessageCount", "PasswordHash", "SecurityStamp", "TutorId" },
                values: new object[] { "3251f90d-8085-40c4-a7a6-3ddec445c985", 0, "AQAAAAIAAYagAAAAEKeL/GdHRuj4EIXpayTOMJQ+l5Uum5P7luW2tTMIdk5xempn8saXskBpACx4rgr1/Q==", "bdc66680-8387-438f-8673-d5ad5b4835d7", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TutorId",
                table: "AspNetUsers",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TutorId",
                table: "AspNetUsers",
                column: "TutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TutorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TutorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MessageCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "529932cd-9e1e-4473-ae89-165de68c730d", "AQAAAAIAAYagAAAAEFLIJ3RwSwCxolJtf+BTAgIc4PBqoMdob+XzOxG3aFxQpkLvFKFqXgK84zL3mq3hBw==", "06b2158b-3507-4a3d-88a9-2efee58e10df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05cc3453-ad0a-4f59-a563-ef5f64c13581", "AQAAAAIAAYagAAAAEGobFIafcS3Q43wwWpqIrWNTVrUQCi4BTw7LTfkPsSW2+iiVetQXfQgfu3hxouWZzA==", "4d8c0ad3-a28d-4474-9f5c-77a66d4bc002" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca6271b1-5dbf-493e-a8ce-d2a5aa274edd", "AQAAAAIAAYagAAAAEABuGyBRdxAmsNB3SCGH3uR6FiqG/FXK5PujUH3LEFAjfoSJAytAQv0UFcjwx9PP2w==", "f86cfdf3-bedd-41f6-b947-18cad4796788" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f893d2d2-f5ce-40a5-a301-156d6916d70f", "AQAAAAIAAYagAAAAEMhsGZSzvFoTT1uvOOlBqO7ep4hRuI0Ge+VIJFSs+cM25JRVK4WOhIBlhTvH7AMrBA==", "eed05ddb-1fad-4e80-a88f-0650a4623c40" });
        }
    }
}
