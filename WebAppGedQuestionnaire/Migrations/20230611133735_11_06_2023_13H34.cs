using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class _11_06_2023_13H34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbreChoixRestant",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbreChoixRestant",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");
        }
    }
}
