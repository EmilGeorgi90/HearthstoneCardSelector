using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HsDbFirstRealAspNetProject.Migrations
{
    public partial class Hs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardInfo_Deck_DeckId",
                table: "CardInfo");

            migrationBuilder.DropIndex(
                name: "IX_CardInfo_DeckId",
                table: "CardInfo");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "CardInfo");

            migrationBuilder.AddColumn<string>(
                name: "Rarity",
                table: "additionalCardInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "additionalCardInfo");

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "CardInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardInfo_DeckId",
                table: "CardInfo",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardInfo_Deck_DeckId",
                table: "CardInfo",
                column: "DeckId",
                principalTable: "Deck",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
