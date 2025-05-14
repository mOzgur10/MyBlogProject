using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "39796661-fa24-40e8-9a94-f30d0f4e57ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "c3025819-7522-47ce-98ef-f7527b5b800a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "6fa78329-c034-41dc-a171-b6ee307c30fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9738adba-636a-4297-b323-1507854e9ae0", new DateTime(2025, 5, 13, 15, 40, 47, 556, DateTimeKind.Local).AddTicks(4187), "/images/default-profile-photo.jpg", "AQAAAAEAACcQAAAAEG12FuyH2JT7LZFIFtyi74VWmAFWzyzn7AduwrSlMkGlYBj6/Zhcj8oiNyIXule5AQ==", "082e9921-a67a-494b-a68d-c16b71898693" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "dea864e0-e2cc-4f99-8f02-5e91bbbd38ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "eb37b716-79ed-488e-b83c-ef93b700b518");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "7c06e9b9-ae52-4e59-b51f-b732dc998729");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70218d40-50e0-48c9-87b9-5bcd6a8978f7", new DateTime(2025, 5, 12, 17, 51, 46, 129, DateTimeKind.Local).AddTicks(2587), null, "AQAAAAEAACcQAAAAEPUYDsL995oXqr1wRiS8MV5GbHNZiCWnBzqRRut3m3L5uwzOA/+kagKclslfpmAnwA==", "6b884073-ac2c-4422-b1f9-8bb9c6660682" });
        }
    }
}
