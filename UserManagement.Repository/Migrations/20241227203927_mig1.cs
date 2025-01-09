using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Repository.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Create_on",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create_on",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Create_on", "is_active" },
                values: new object[] { "997359ec-270e-4a4e-a3ba-cc38895c9439", new DateTime(2024, 12, 28, 1, 39, 26, 8, DateTimeKind.Local).AddTicks(307), true });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Create_on", "is_active" },
                values: new object[] { "a7667cfd-8b67-4225-a4d3-2742a3e5aea8", new DateTime(2024, 12, 28, 1, 39, 26, 9, DateTimeKind.Local).AddTicks(7904), true });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Create_on", "is_active" },
                values: new object[] { "ecf5090a-6bcb-48b6-a89c-6dae4ec0142e", new DateTime(2024, 12, 28, 1, 39, 26, 9, DateTimeKind.Local).AddTicks(8060), true });

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "Discriminator",
                value: "AppUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "Discriminator",
                value: "AppUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "Discriminator",
                value: "AppUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Create_on", "PasswordHash", "SecurityStamp", "is_active" },
                values: new object[] { "4b095070-eca3-4778-aa68-041dab3b6d3d", new DateTime(2024, 12, 28, 1, 39, 26, 14, DateTimeKind.Local).AddTicks(1059), "AQAAAAEAACcQAAAAEJNhvVpE15Su2O/v9yecWy3Q/7B2QbLNt7NNhmwLLE1QRj1LQYJjHn4SgSkMAMuJpQ==", "8fbb6069-15cd-4dce-866c-4c259e3909c2", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Create_on", "PasswordHash", "SecurityStamp", "is_active" },
                values: new object[] { "3bc3585d-dc38-4bfd-8c3d-088c67804cc7", new DateTime(2024, 12, 28, 1, 39, 26, 15, DateTimeKind.Local).AddTicks(4578), "AQAAAAEAACcQAAAAED3hvI/CL2TtARR+DV9NUJr92Q9rK7Avep5N60bxDVHkblR0lImyk27IIOL8Y2mlpw==", "8e7fab2d-724b-4ce3-9263-7d2989aeb399", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Create_on", "PasswordHash", "SecurityStamp", "is_active" },
                values: new object[] { "ea8e6e0d-34fd-43b4-96b3-17dfa8eacc0f", new DateTime(2024, 12, 28, 1, 39, 26, 15, DateTimeKind.Local).AddTicks(4851), "AQAAAAEAACcQAAAAEIrqI4+NnvLTZvWXtBwVSsXsd8+viBusW2mBbHrJClNdcRUHe2IvrxTlkEqyuS+8WQ==", "615d6f2a-45a7-4763-9cd4-d841d2a7c0f0", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create_on",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Create_on",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8d96a7eb-d781-4b23-95c5-281da76db342");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6ace49a7-caab-4365-98fc-bc17a35e0a6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "17816d0a-925f-4b0a-8998-e80441e98316");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "Discriminator",
                value: "AppUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "Discriminator",
                value: "AppUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "Discriminator",
                value: "AppUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57bb6d50-5255-4d4c-8a5e-01640c3352a6", "AQAAAAEAACcQAAAAEA5xuA+js5xukZbnuZPt5eaQtWIjaMTdfVtoCv35dBdOmWrx85s5eHHus4ptBxCILw==", "95143ace-d8dd-43b8-925b-46a838317732" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbbf8d2e-37fd-4116-b9eb-660c3fa4b883", "AQAAAAEAACcQAAAAEJF5vE/kp3P1uSXCNKH+bq4QJDRmG1VDOaWGBkn5GrfIdhJwQ4WnT0qGZWiS7zibgQ==", "3000672c-6000-40be-94ff-c6330481ceb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18032449-d989-4fec-b880-5e6bc914eefe", "AQAAAAEAACcQAAAAEJRiBWaA+A69JGHvlKNq2+z9rDdZDjcN0KSUE3neiVNepwc1vmx6sKLb1hCn4PhfBA==", "3a0f506a-da9f-4d5b-bd19-dfee1218da76" });
        }
    }
}
