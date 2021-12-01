using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class InventoryDataERD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "GameInventory");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Game");

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "APIRetrieval", "BoxArtUrlBack", "BoxArtUrlFront", "BoxArtUrlThumb", "Description", "Developer", "GameIDAPI", "GameSystem", "Genre", "Name", "Publisher", "ReleaseDate", "VideoUrl" },
                values: new object[] { 1, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.thegamesdb.net/images/original/boxart/front/49901-1.jpg", null, "Have you and your friends been experiencing paranormal activity? Grab your Proton Pack and join the Ghostbusters as you explore Manhattan, blasting ghosts, and trapping those runaway ghouls.", null, 49901, null, null, "Ghostbusters", null, new DateTime(2016, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "APIRetrieval", "BoxArtUrlBack", "BoxArtUrlFront", "BoxArtUrlThumb", "Description", "Developer", "GameIDAPI", "GameSystem", "Genre", "Name", "Publisher", "ReleaseDate", "VideoUrl" },
                values: new object[] { 2, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.thegamesdb.net/images/original/boxart/front/12874-1.jpg", null, "Sonic & All-Stars Racing Transformed™ is a thrilling new racing experience featuring Sonic the Hedgehog and a fantastic cast of SEGA All-Stars competing across land, air and water in vehicles that fully transform from cars, to planes to boats.", null, 12874, null, null, "Sonic & All-Stars Racing Transformed", null, new DateTime(2012, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "APIRetrieval", "BoxArtUrlBack", "BoxArtUrlFront", "BoxArtUrlThumb", "Description", "Developer", "GameIDAPI", "GameSystem", "Genre", "Name", "Publisher", "ReleaseDate", "VideoUrl" },
                values: new object[] { 3, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.thegamesdb.net/images/original/boxart/back/10009-1.jpg", "https://cdn.thegamesdb.net/images/original/boxart/front/10009-1.jpg", null, "Zonk is back in Super Air Zonk!!\r\n\r\nNow moving to a rockabilly beat and able to transform into nine different characters, Zonk lets loose through seven action-packed stages in another battle against his arch nemesis, Sandro Vitch. Power up Zonk with the classic Meat item, eventually turning him into the champion of justice, Ultra Zonk, or the fearsome Tyrano Zonk in the latter stages of the game.\r\nRead More>>\r\n\r\nAfter rescuing his friends from enemies, Zonk can also morph with them to combine powers. Fight enemies with killer tunes belted out from a trusty microphone. Hurl freshly made sushi at them. With its variety of wacky attacks, Super Air Zonk has a sense of humor all its own.", null, 10009, null, null, "Super Air Zonk", null, new DateTime(1993, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "Id", "Condition", "GameId", "Price", "Quantity", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, 1, 30f, 2, 2, 1 },
                    { 2, 4, 1, 10f, 3, 5, 1 },
                    { 4, 2, 2, 12.43f, 1, 3, 1 },
                    { 3, 3, 3, 150.25f, 1, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_GameId",
                table: "InventoryItem",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "GameInventory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ItemPrice",
                table: "Game",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "GameInventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "Condition",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GameInventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Condition",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GameInventory",
                keyColumn: "Id",
                keyValue: 3,
                column: "Condition",
                value: 4);
        }
    }
}
