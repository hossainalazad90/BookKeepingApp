using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookKeepingApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadType = table.Column<string>(maxLength: 10, nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReconcilationHeadTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Head = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconcilationHeadTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reconcilations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReconcilationHeadTypeId = table.Column<int>(nullable: false),
                    Jan = table.Column<decimal>(nullable: false),
                    Feb = table.Column<decimal>(nullable: false),
                    Mar = table.Column<decimal>(nullable: false),
                    Apr = table.Column<decimal>(nullable: false),
                    May = table.Column<decimal>(nullable: false),
                    Jun = table.Column<decimal>(nullable: false),
                    Jul = table.Column<decimal>(nullable: false),
                    Aug = table.Column<decimal>(nullable: false),
                    Sep = table.Column<decimal>(nullable: false),
                    Oct = table.Column<decimal>(nullable: false),
                    Nov = table.Column<decimal>(nullable: false),
                    Dec = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reconcilations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reconcilations_ReconcilationHeadTypes_ReconcilationHeadTypeId",
                        column: x => x.ReconcilationHeadTypeId,
                        principalTable: "ReconcilationHeadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reconcilations_ReconcilationHeadTypeId",
                table: "Reconcilations",
                column: "ReconcilationHeadTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeExpenses");

            migrationBuilder.DropTable(
                name: "Reconcilations");

            migrationBuilder.DropTable(
                name: "ReconcilationHeadTypes");
        }
    }
}
