using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
    /// <inheritdoc />
    public partial class changes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 7, 17, 15, 6, 55, 981, DateTimeKind.Local).AddTicks(1046));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 7, 17, 2, 36, 31, 761, DateTimeKind.Local).AddTicks(8921));
        }
    }
}
