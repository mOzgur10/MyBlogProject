using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class init50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "601b66f6-ad4d-42e1-8352-14a36b823e75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "780fd21d-241f-4f98-8cfc-2fbc8ad6678a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "59631fc4-e11f-42ed-ae00-07c5d18f1891");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da5a458d-0287-480a-a226-b812f6a3947d", new DateTime(2025, 5, 9, 10, 2, 30, 81, DateTimeKind.Local).AddTicks(2357), "AQAAAAEAACcQAAAAEHbtPzzPR2yYmQyDJr/juNB8zlwvGOEiYQ9U6R54nGKpB9zOAq+xSXYT6+nLc1NhHQ==", "77657ce2-46d5-470b-a339-45c9745ae919" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AspNetUsers");

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
    }
}
