using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class cocherTampon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_COCHER_TAMPON",
                schema: "dbo",
                columns: table => new
                {
                    CocherTamponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Cocher = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 20, nullable: true),
                    ChoixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_COCHER_TAMPON", x => x.CocherTamponId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_COCHER_TAMPON",
                schema: "dbo");
        }
    }
}
