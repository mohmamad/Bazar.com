using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seeding_books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookTopic",
                columns: new[] { "BookTopicId", "Topic" },
                values: new object[,]
                {
                    { 1, "distributed systems" },
                    { 2, "undergraduate school" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookTopicId", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 15.0, 5, "How to get a good grade in DOS in 40 minutes a day" },
                    { 2, 1, 20.0, 3, "RPCs for Noobs" },
                    { 3, 2, 15.0, 5, "Xen and the Art of Surviving Undergraduate School." },
                    { 4, 2, 15.0, 5, "Cooking for the Impatient Undergrad." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookTopic",
                keyColumn: "BookTopicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookTopic",
                keyColumn: "BookTopicId",
                keyValue: 2);
        }
    }
}
