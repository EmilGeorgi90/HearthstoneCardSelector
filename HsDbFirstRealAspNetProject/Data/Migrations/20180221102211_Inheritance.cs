using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HsDbFirstRealAspNetProject.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "additionalCardInfo",
                columns: table => new
                {
                    AdditionCardInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artist = table.Column<string>(nullable: true),
                    Collectible = table.Column<bool>(nullable: false),
                    Cost = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additionalCardInfo", x => x.AdditionCardInfoId);
                });

            migrationBuilder.CreateTable(
                name: "CardInfo",
                columns: table => new
                {
                    CardInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionCardInfoId = table.Column<int>(nullable: true),
                    CardId = table.Column<string>(nullable: true),
                    CardSet = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    DbId = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfo", x => x.CardInfoId);
                    table.ForeignKey(
                        name: "FK_CardInfo_additionalCardInfo_AdditionCardInfoId",
                        column: x => x.AdditionCardInfoId,
                        principalTable: "additionalCardInfo",
                        principalColumn: "AdditionCardInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardInfoAdditionCardInfoId = table.Column<int>(nullable: true),
                    Health = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.HeroId);
                    table.ForeignKey(
                        name: "FK_Hero_additionalCardInfo_CardInfoAdditionCardInfoId",
                        column: x => x.CardInfoAdditionCardInfoId,
                        principalTable: "additionalCardInfo",
                        principalColumn: "AdditionCardInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Minion",
                columns: table => new
                {
                    MinionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attack = table.Column<long>(nullable: false),
                    CardInfoAdditionCardInfoId = table.Column<int>(nullable: true),
                    Health = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minion", x => x.MinionId);
                    table.ForeignKey(
                        name: "FK_Minion_additionalCardInfo_CardInfoAdditionCardInfoId",
                        column: x => x.CardInfoAdditionCardInfoId,
                        principalTable: "additionalCardInfo",
                        principalColumn: "AdditionCardInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    SpellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardInfoAdditionCardInfoId = table.Column<int>(nullable: true),
                    Flavor = table.Column<string>(nullable: true),
                    HowToGet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.SpellId);
                    table.ForeignKey(
                        name: "FK_Spell_additionalCardInfo_CardInfoAdditionCardInfoId",
                        column: x => x.CardInfoAdditionCardInfoId,
                        principalTable: "additionalCardInfo",
                        principalColumn: "AdditionCardInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardInfoId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mechanic_CardInfo_CardInfoId",
                        column: x => x.CardInfoId,
                        principalTable: "CardInfo",
                        principalColumn: "CardInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MinionsVsMechanics",
                columns: table => new
                {
                    MinionsVsMechanicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MechanicId = table.Column<int>(nullable: true),
                    MinionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinionsVsMechanics", x => x.MinionsVsMechanicId);
                    table.ForeignKey(
                        name: "FK_MinionsVsMechanics_Mechanic_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MinionsVsMechanics_Minion_MinionId",
                        column: x => x.MinionId,
                        principalTable: "Minion",
                        principalColumn: "MinionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardInfo_AdditionCardInfoId",
                table: "CardInfo",
                column: "AdditionCardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_CardInfoAdditionCardInfoId",
                table: "Hero",
                column: "CardInfoAdditionCardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanic_CardInfoId",
                table: "Mechanic",
                column: "CardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Minion_CardInfoAdditionCardInfoId",
                table: "Minion",
                column: "CardInfoAdditionCardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MinionsVsMechanics_MechanicId",
                table: "MinionsVsMechanics",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MinionsVsMechanics_MinionId",
                table: "MinionsVsMechanics",
                column: "MinionId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_CardInfoAdditionCardInfoId",
                table: "Spell",
                column: "CardInfoAdditionCardInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "MinionsVsMechanics");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Mechanic");

            migrationBuilder.DropTable(
                name: "Minion");

            migrationBuilder.DropTable(
                name: "CardInfo");

            migrationBuilder.DropTable(
                name: "additionalCardInfo");
        }
    }
}
