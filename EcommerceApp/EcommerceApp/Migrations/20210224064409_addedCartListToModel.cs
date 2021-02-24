using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class addedCartListToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartGameId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartUserId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CartUserId_CartGameId",
                table: "Cart",
                columns: new[] { "CartUserId", "CartGameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Cart_CartUserId_CartGameId",
                table: "Cart",
                columns: new[] { "CartUserId", "CartGameId" },
                principalTable: "Cart",
                principalColumns: new[] { "UserId", "GameId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Cart_CartUserId_CartGameId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_CartUserId_CartGameId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CartGameId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CartUserId",
                table: "Cart");
        }
    }
}
