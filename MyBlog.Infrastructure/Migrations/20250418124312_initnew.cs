using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class initnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "ef6482cd-103f-484b-b38f-2ab5c5f5ef31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "cbad10e9-ab60-4c46-a487-ebe776f60854");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "7375e6f7-ccee-43f5-baed-021c7077183f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fea1f774-2342-4a66-b54b-1df514031747", new DateTime(2025, 4, 18, 15, 43, 12, 352, DateTimeKind.Local).AddTicks(505), "AQAAAAEAACcQAAAAEHDLxS7uUbmgI0+R/2UylFh/kcSpA6JoJ3fylZA7r8jtSB4xCOT8y5b9A0mBN8uuvA==", "e76915e5-94e5-4060-9a18-88e2a0a1a252" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "60f83a0e-0023-4350-adab-add1f4f584ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "f8bd5fc3-48ca-462f-834d-33df17c51ae1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "c983c46a-2676-4b2b-8761-2982e61d43a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed5265d9-c684-4d43-b2e0-38f2609451f4", new DateTime(2025, 4, 9, 21, 16, 38, 968, DateTimeKind.Local).AddTicks(5729), "AQAAAAEAACcQAAAAEAJapzrFq7N8rOyTpjkYi06UKU3xUwWPveJO5gIWD/r8jzFq4yNIWx3n3n3Wexyu1A==", "11829c69-222a-445e-82e5-cdbd86d2d536" });
        }
    }
}
