using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
    /// <inheritdoc />
    public partial class changes6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 7, 17, 21, 53, 32, 651, DateTimeKind.Local).AddTicks(5655));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 7, 17, 21, 51, 13, 869, DateTimeKind.Local).AddTicks(711));
        }
    }
}
