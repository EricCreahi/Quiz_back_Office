﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppGedQuestionnaire.Migrations
{
    public partial class utilisateur_27_04_2023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_DROITACCES",
                schema: "dbo",
                columns: table => new
                {
                    DroitAccesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(maxLength: 200, nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DROITACCES", x => x.DroitAccesId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_UTILISATEUR",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 20, nullable: false),
                    Nom = table.Column<string>(maxLength: 150, nullable: true),
                    Prenoms = table.Column<string>(maxLength: 200, nullable: true),
                    Mail = table.Column<string>(maxLength: 200, nullable: true),
                    UserEstActif = table.Column<bool>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: true),
                    Usermatricule = table.Column<string>(maxLength: 10, nullable: true),
                    DroitAccesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_UTILISATEUR", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TBL_UTILISATEUR_TBL_DROITACCES_DroitAccesId",
                        column: x => x.DroitAccesId,
                        principalSchema: "dbo",
                        principalTable: "TBL_DROITACCES",
                        principalColumn: "DroitAccesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_AUDIT",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTrace = table.Column<DateTime>(nullable: false),
                    TypeAction = table.Column<string>(nullable: true),
                    DetailAction = table.Column<string>(maxLength: 255, nullable: true),
                    IpSource = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_AUDIT", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_TBL_AUDIT_TBL_UTILISATEUR_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_UTILISATEUR",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_AUDIT_UserId",
                schema: "dbo",
                table: "TBL_AUDIT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_UTILISATEUR_DroitAccesId",
                schema: "dbo",
                table: "TBL_UTILISATEUR",
                column: "DroitAccesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_AUDIT",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_UTILISATEUR",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_DROITACCES",
                schema: "dbo");
        }
    }
}
