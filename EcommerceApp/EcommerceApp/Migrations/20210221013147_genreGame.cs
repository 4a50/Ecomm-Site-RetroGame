using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
  public partial class genreGame : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropIndex(
          name: "IX_GenreGame_GameId",
          table: "GenreGame");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateIndex(
          name: "IX_GenreGame_GameId",
          table: "GenreGame",
          column: "GameId",
          unique: true);
    }
  }
}
