using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class initialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TBL_EMPLOYE",
                schema: "dbo",
                columns: table => new
                {
                    Matricule = table.Column<string>(maxLength: 20, nullable: false),
                    NomPrenoms = table.Column<string>(maxLength: 150, nullable: true),
                    Contact = table.Column<string>(maxLength: 150, nullable: true),
                    Fonction = table.Column<string>(maxLength: 150, nullable: true),
                    Direction = table.Column<string>(maxLength: 150, nullable: true),
                    Service = table.Column<string>(maxLength: 150, nullable: true),
                    Categorie = table.Column<string>(maxLength: 150, nullable: true),
                    Mail = table.Column<string>(maxLength: 150, nullable: true),
                    Equipe = table.Column<string>(maxLength: 150, nullable: true),
                    Statut = table.Column<string>(maxLength: 150, nullable: true),
                    Site = table.Column<string>(maxLength: 100, nullable: true),
                    Date_Sortie = table.Column<string>(maxLength: 6, nullable: true),
                    Anciennete = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_EMPLOYE", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "TBL_QUESTIONNAIRE",
                schema: "dbo",
                columns: table => new
                {
                    QuestionnaireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: true),
                    Date_debut = table.Column<DateTime>(nullable: false),
                    Date_Fin = table.Column<DateTime>(nullable: false),
                    EstActif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_QUESTIONNAIRE", x => x.QuestionnaireId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_QUESTION",
                schema: "dbo",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle_Question = table.Column<string>(nullable: true),
                    Numero_Question = table.Column<int>(nullable: false),
                    EstVisible = table.Column<bool>(nullable: false),
                    QuestionnaireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_QUESTION", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_TBL_QUESTION_TBL_QUESTIONNAIRE_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalSchema: "dbo",
                        principalTable: "TBL_QUESTIONNAIRE",
                        principalColumn: "QuestionnaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_REALISER",
                schema: "dbo",
                columns: table => new
                {
                    RealiserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Realiser = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 20, nullable: true),
                    QuestionnaireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_REALISER", x => x.RealiserId);
                    table.ForeignKey(
                        name: "FK_TBL_REALISER_TBL_EMPLOYE_Matricule",
                        column: x => x.Matricule,
                        principalSchema: "dbo",
                        principalTable: "TBL_EMPLOYE",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_REALISER_TBL_QUESTIONNAIRE_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalSchema: "dbo",
                        principalTable: "TBL_QUESTIONNAIRE",
                        principalColumn: "QuestionnaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CHOIX",
                schema: "dbo",
                columns: table => new
                {
                    ChoixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle_Choix = table.Column<string>(nullable: true),
                    EstVisible = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CHOIX", x => x.ChoixId);
                    table.ForeignKey(
                        name: "FK_TBL_CHOIX_TBL_QUESTION_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "TBL_QUESTION",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_COCHER",
                schema: "dbo",
                columns: table => new
                {
                    CocherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Cocher = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(nullable: true),
                    ChoixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_COCHER", x => x.CocherId);
                    table.ForeignKey(
                        name: "FK_TBL_COCHER_TBL_CHOIX_ChoixId",
                        column: x => x.ChoixId,
                        principalSchema: "dbo",
                        principalTable: "TBL_CHOIX",
                        principalColumn: "ChoixId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_COCHER_TBL_EMPLOYE_Matricule",
                        column: x => x.Matricule,
                        principalSchema: "dbo",
                        principalTable: "TBL_EMPLOYE",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CHOIX_QuestionId",
                schema: "dbo",
                table: "TBL_CHOIX",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_COCHER_ChoixId",
                schema: "dbo",
                table: "TBL_COCHER",
                column: "ChoixId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_COCHER_Matricule",
                schema: "dbo",
                table: "TBL_COCHER",
                column: "Matricule");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_QUESTION_QuestionnaireId",
                schema: "dbo",
                table: "TBL_QUESTION",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_REALISER_Matricule",
                schema: "dbo",
                table: "TBL_REALISER",
                column: "Matricule");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_REALISER_QuestionnaireId",
                schema: "dbo",
                table: "TBL_REALISER",
                column: "QuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_COCHER",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_REALISER",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_CHOIX",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_EMPLOYE",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_QUESTION",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_QUESTIONNAIRE",
                schema: "dbo");
        }
    }
}
