using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class cocher_tampon_23_04_2023_21H : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Page",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Precedent",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Suivant",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");

            migrationBuilder.DropColumn(
                name: "Precedent",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");

            migrationBuilder.DropColumn(
                name: "Suivant",
                schema: "dbo",
                table: "TBL_COCHER_TAMPON");
        }
    }
}
