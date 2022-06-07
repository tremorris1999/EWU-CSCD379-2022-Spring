using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class GuessDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guess_Games_GameId",
                table: "Guess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guess",
                table: "Guess");

            migrationBuilder.RenameTable(
                name: "Guess",
                newName: "Guesses");

            migrationBuilder.RenameIndex(
                name: "IX_Guess_GameId",
                table: "Guesses",
                newName: "IX_Guesses_GameId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ClientDate",
                table: "Guesses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Guesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guesses",
                table: "Guesses",
                column: "GuessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guesses_Games_GameId",
                table: "Guesses",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guesses_Games_GameId",
                table: "Guesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guesses",
                table: "Guesses");

            migrationBuilder.DropColumn(
                name: "ClientDate",
                table: "Guesses");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Guesses");

            migrationBuilder.RenameTable(
                name: "Guesses",
                newName: "Guess");

            migrationBuilder.RenameIndex(
                name: "IX_Guesses_GameId",
                table: "Guess",
                newName: "IX_Guess_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guess",
                table: "Guess",
                column: "GuessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guess_Games_GameId",
                table: "Guess",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
