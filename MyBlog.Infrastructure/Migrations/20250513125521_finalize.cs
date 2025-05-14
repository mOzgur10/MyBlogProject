using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Infrastructure.Migrations
{
    public partial class finalize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558b5f08-f36d-401f-9908-e472e74c3469",
                column: "ConcurrencyStamp",
                value: "eb57ff75-bddc-4e66-bd17-f9f2fb4bffc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29",
                column: "ConcurrencyStamp",
                value: "117ac9db-fa03-41e0-986d-420f0ce0bef0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc",
                column: "ConcurrencyStamp",
                value: "39ce326f-ae8c-475d-9541-9c29c663c748");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "068be76f-f1c2-44dd-a874-000b534c0009", new DateTime(2025, 5, 13, 15, 55, 21, 327, DateTimeKind.Local).AddTicks(1240), "/images/user/default-profile-photo.jpg", "AQAAAAEAACcQAAAAEJeq3Bcjcv4IKvhTkujJUH/Osr55S0nTF8/9WE4+q68fbKv+OMnjd96PWa2q4axOcg==", "c7abde34-5260-4348-bad1-9c64179233b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
