using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class _10_06_2022_10H39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");
        }
    }
}
