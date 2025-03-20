using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleFromApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "2c2ff62f-6052-4f57-82ab-8307f3a440c1", "AQAAAAIAAYagAAAAEGlPbBcznoIHEZsEIWZ2bZFMKrcBSKF1n4QR5Ir9V4dSJWGSPwbF68kBs2O1Ca+QQg==", "Teacher", "b88b1d76-44b1-4a5f-8805-571059f292d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "411c49a2-bc17-4f11-9c90-773fc420b067", "AQAAAAIAAYagAAAAEDIzfKUMwmI2X0u+Jc67LkCaTi6OTDQQrcLVPGG8ba/gZBH/dtUC1s1FYGEMrrCz1Q==", "Teacher", "bb06cbac-cc7f-47d3-8480-d6e3e121e361" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "deae0714-564a-44a8-a2af-8a8d276c1565", "AQAAAAIAAYagAAAAEDWOvTiIA+Jjvy6umDmddZzOuMKSK5gNps5GwgYQHHqW2rqm6q0jgAlBIcwZykQZPQ==", "Staff", "b3f33663-c741-46f3-8a9e-f2e8f60c4611" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "875831ad-a1d9-4c01-8392-f67961d81e67", "AQAAAAIAAYagAAAAEFIlFNBtX8RIIqSjjzhPfvJNGx+m/UuA3xN5Csv33lQOc45nx6RUcxObzMVc0hyPmA==", "Staff", "d370433f-677d-4d7b-99a5-7367c8795828" });
        }
    }
}
