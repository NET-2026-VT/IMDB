using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMDB.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Genre", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 3, 7.9f, new DateTime(1997, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic" },
                    { 2, 0, 7.4f, new DateTime(1997, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scream" },
                    { 3, 0, 8.4f, new DateTime(1980, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shining" },
                    { 4, 4, 7.6f, new DateTime(2007, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "300" },
                    { 5, 3, 8.7f, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 6, 4, 9.1f, new DateTime(2008, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
