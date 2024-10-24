using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class _07_06_2023_16H08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_CHOIX_TBL_QUESTION_QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX");

            migrationBuilder.DropIndex(
                name: "IX_TBL_CHOIX_QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX");

            migrationBuilder.AddColumn<int>(
                name: "SousQuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TBL_SOUS_QUESTION",
                schema: "dbo",
                columns: table => new
                {
                    SousQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle_Sous_Question = table.Column<string>(nullable: true),
                    Numero_Sous_Question = table.Column<int>(nullable: false),
                    EstVisible = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SOUS_QUESTION", x => x.SousQuestionId);
                    table.ForeignKey(
                        name: "FK_TBL_SOUS_QUESTION_TBL_QUESTION_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "TBL_QUESTION",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CHOIX_SousQuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                column: "SousQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SOUS_QUESTION_QuestionId",
                schema: "dbo",
                table: "TBL_SOUS_QUESTION",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_CHOIX_TBL_SOUS_QUESTION_SousQuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                column: "SousQuestionId",
                principalSchema: "dbo",
                principalTable: "TBL_SOUS_QUESTION",
                principalColumn: "SousQuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_CHOIX_TBL_SOUS_QUESTION_SousQuestionId",
                schema: "dbo",
                table: "TBL_CHOIX");

            migrationBuilder.DropTable(
                name: "TBL_SOUS_QUESTION",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_TBL_CHOIX_SousQuestionId",
                schema: "dbo",
                table: "TBL_CHOIX");

            migrationBuilder.DropColumn(
                name: "SousQuestionId",
                schema: "dbo",
                table: "TBL_CHOIX");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CHOIX_QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_CHOIX_TBL_QUESTION_QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                column: "QuestionId",
                principalSchema: "dbo",
                principalTable: "TBL_QUESTION",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
