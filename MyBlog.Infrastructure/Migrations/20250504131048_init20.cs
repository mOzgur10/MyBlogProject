using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class init20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "9d7ee1ae-89a0-4da2-b4f8-e58b91f4f5c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "09b03822-ad4c-4d57-9fdc-36db47840e4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "b050637e-a52a-4e8c-9269-1db49b3b7cf9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4259cbf1-ee87-44f3-b7eb-e7ebad7d2bf7", new DateTime(2025, 5, 4, 16, 10, 48, 321, DateTimeKind.Local).AddTicks(2747), "AQAAAAEAACcQAAAAEPyvQ4tIxeTM2+xqnKIBhMSQCVjvGY7vdlM8Fh/LcqF8W2RuismAGUWKjTWx/1AfzQ==", "1899e56b-ef47-4a3d-a1ae-ec693d47a4a0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "92ec5c94-51ef-418a-b394-7d81ee61f5bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "3821e648-b679-492e-83e0-de893313ac9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "0dd9bbab-0cd1-4497-93ef-3e6c7dc61268");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39625141-da67-43ad-a14f-139791d86f6d", new DateTime(2025, 5, 2, 19, 53, 39, 139, DateTimeKind.Local).AddTicks(3539), "AQAAAAEAACcQAAAAEGrsa/8Gx1dHS+1SOTupIDuDhhhdkdZwnPOxFz32B++FEHDZP2BQCNEpknBx9FUgwA==", "2a122573-8fd7-4a44-ad1a-f7d9d301feb8" });
        }
    }
}
