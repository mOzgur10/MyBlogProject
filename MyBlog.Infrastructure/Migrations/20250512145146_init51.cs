using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class init51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70218d40-50e0-48c9-87b9-5bcd6a8978f7", new DateTime(2025, 5, 12, 17, 51, 46, 129, DateTimeKind.Local).AddTicks(2587), "AQAAAAEAACcQAAAAEPUYDsL995oXqr1wRiS8MV5GbHNZiCWnBzqRRut3m3L5uwzOA/+kagKclslfpmAnwA==", "6b884073-ac2c-4422-b1f9-8bb9c6660682" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
