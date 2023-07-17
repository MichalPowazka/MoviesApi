using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
    /// <inheritdoc />
    public partial class changes4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 7, 17, 21, 46, 34, 196, DateTimeKind.Local).AddTicks(6248));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 7, 17, 17, 48, 22, 208, DateTimeKind.Local).AddTicks(1570));
        }
    }
}
