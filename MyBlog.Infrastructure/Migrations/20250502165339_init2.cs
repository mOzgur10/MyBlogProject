using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Articles");

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
    }
}
