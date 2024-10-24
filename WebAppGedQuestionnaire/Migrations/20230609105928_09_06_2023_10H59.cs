using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class _09_06_2023_10H59 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SousQuestionId",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SousQuestionId",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");
        }
    }
}
