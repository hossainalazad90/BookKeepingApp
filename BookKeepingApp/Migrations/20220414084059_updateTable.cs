using Microsoft.EntityFrameworkCore.Migrations;

namespace BookKeepingApp.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadType",
                table: "IncomeExpenses");

            migrationBuilder.AddColumn<int>(
                name: "IncomeExpenseHeadId",
                table: "IncomeExpenses",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeExpenses_IncomeExpenseHeadId",
                table: "IncomeExpenses",
                column: "IncomeExpenseHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeExpenses_IncomeExpenseHeads_IncomeExpenseHeadId",
                table: "IncomeExpenses",
                column: "IncomeExpenseHeadId",
                principalTable: "IncomeExpenseHeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeExpenses_IncomeExpenseHeads_IncomeExpenseHeadId",
                table: "IncomeExpenses");

            migrationBuilder.DropIndex(
                name: "IX_IncomeExpenses_IncomeExpenseHeadId",
                table: "IncomeExpenses");

            migrationBuilder.DropColumn(
                name: "IncomeExpenseHeadId",
                table: "IncomeExpenses");

            migrationBuilder.AddColumn<string>(
                name: "HeadType",
                table: "IncomeExpenses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
