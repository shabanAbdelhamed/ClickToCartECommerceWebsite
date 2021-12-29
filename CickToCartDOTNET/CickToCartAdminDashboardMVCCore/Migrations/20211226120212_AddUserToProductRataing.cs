using Microsoft.EntityFrameworkCore.Migrations;

namespace CickToCart.Migrations
{
    public partial class AddUserToProductRataing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Product_Ratings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Ratings_UserId",
                table: "Product_Ratings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ratings_AspNetUsers_UserId",
                table: "Product_Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ratings_AspNetUsers_UserId",
                table: "Product_Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Product_Ratings_UserId",
                table: "Product_Ratings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Product_Ratings");
        }
    }
}
