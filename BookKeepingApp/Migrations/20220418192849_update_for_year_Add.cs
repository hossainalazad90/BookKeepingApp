using Microsoft.EntityFrameworkCore.Migrations;

namespace BookKeepingApp.Migrations
{
    public partial class update_for_year_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Reconcilations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Reconcilations");
        }
    }
}
