using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Order.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedingBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 15.0, 5, "How to get a good grade in DOS in 40 minutes a day" },
                    { 2, 20.0, 3, "RPCs for Noobs" },
                    { 3, 15.0, 5, "Xen and the Art of Surviving Undergraduate School." },
                    { 4, 15.0, 5, "Cooking for the Impatient Undergrad." }
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
        }
    }
}
