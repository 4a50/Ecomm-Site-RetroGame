using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class ImageFieldGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_ImageId",
                table: "Game",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_File_ImageId",
                table: "Game",
                column: "ImageId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_File_ImageId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropIndex(
                name: "IX_Game_ImageId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Game");
        }
    }
}
