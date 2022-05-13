using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class CreateWords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Games");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnded",
                table: "Games",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStarted",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    GamesGameId = table.Column<int>(type: "int", nullable: false),
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => new { x.GamesGameId, x.PlayersPlayerId });
                    table.ForeignKey(
                        name: "FK_GamePlayer_Games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guess",
                columns: table => new
                {
                    GuessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guess", x => x.GuessId);
                    table.ForeignKey(
                        name: "FK_Guess_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 1, "thing" },
                    { 2, "think" },
                    { 3, "thong" },
                    { 4, "throb" },
                    { 5, "thunk" },
                    { 6, "wrong" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DateEnded", "DateStarted", "WordId" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DateEnded", "DateStarted", "WordId" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DateEnded", "DateStarted", "WordId" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayersPlayerId",
                table: "GamePlayer",
                column: "PlayersPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Guess_GameId",
                table: "Guess",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "Guess");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "WordId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DateEnded",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DateStarted",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
