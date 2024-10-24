using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class _27_12_2023_16h49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Note",
                schema: "dbo",
                table: "TBL_CHOIX",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                schema: "dbo",
                table: "TBL_CHOIX");
        }
    }
}
