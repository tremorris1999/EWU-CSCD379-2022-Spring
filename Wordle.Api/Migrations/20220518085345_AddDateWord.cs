using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class AddDateWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Players",
            //     columns: table => new
            //     {
            //         PlayerId = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         GameCount = table.Column<int>(type: "int", nullable: false),
            //         AverageGuesses = table.Column<double>(type: "float", nullable: false),
            //         AverageSecondsPerGame = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Players", x => x.PlayerId);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Words",
            //     columns: table => new
            //     {
            //         WordId = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Words", x => x.WordId);
            //     });

            migrationBuilder.CreateTable(
                name: "DateWords",
                columns: table => new
                {
                    DateWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWords", x => x.DateWordId);
                    table.ForeignKey(
                        name: "FK_DateWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateWords_WordId",
                table: "DateWords",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateWords");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
