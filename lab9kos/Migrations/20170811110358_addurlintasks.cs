using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab9kos.Migrations
{
    public partial class addurlintasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaakGebruiker_Gebruiker_GebruikerId",
                table: "TaakGebruiker");

            migrationBuilder.DropForeignKey(
                name: "FK_TaakGebruiker_Taak_TaakId",
                table: "TaakGebruiker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaakGebruiker",
                table: "TaakGebruiker");

            migrationBuilder.RenameTable(
                name: "TaakGebruiker",
                newName: "TaakGebruikers");

            migrationBuilder.RenameIndex(
                name: "IX_TaakGebruiker_TaakId",
                table: "TaakGebruikers",
                newName: "IX_TaakGebruikers_TaakId");

            migrationBuilder.AddColumn<int>(
                name: "Dinsdag",
                table: "WerkWeek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Donderdag",
                table: "WerkWeek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Maandag",
                table: "WerkWeek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vrijdag",
                table: "WerkWeek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Woensdag",
                table: "WerkWeek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaakRealisatieNiveau",
                table: "Taak",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Taak",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaakGebruikers",
                table: "TaakGebruikers",
                columns: new[] { "GebruikerId", "TaakId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaakGebruikers_Gebruiker_GebruikerId",
                table: "TaakGebruikers",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaakGebruikers_Taak_TaakId",
                table: "TaakGebruikers",
                column: "TaakId",
                principalTable: "Taak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaakGebruikers_Gebruiker_GebruikerId",
                table: "TaakGebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaakGebruikers_Taak_TaakId",
                table: "TaakGebruikers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaakGebruikers",
                table: "TaakGebruikers");

            migrationBuilder.DropColumn(
                name: "Dinsdag",
                table: "WerkWeek");

            migrationBuilder.DropColumn(
                name: "Donderdag",
                table: "WerkWeek");

            migrationBuilder.DropColumn(
                name: "Maandag",
                table: "WerkWeek");

            migrationBuilder.DropColumn(
                name: "Vrijdag",
                table: "WerkWeek");

            migrationBuilder.DropColumn(
                name: "Woensdag",
                table: "WerkWeek");

            migrationBuilder.DropColumn(
                name: "TaakRealisatieNiveau",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Taak");

            migrationBuilder.RenameTable(
                name: "TaakGebruikers",
                newName: "TaakGebruiker");

            migrationBuilder.RenameIndex(
                name: "IX_TaakGebruikers_TaakId",
                table: "TaakGebruiker",
                newName: "IX_TaakGebruiker_TaakId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaakGebruiker",
                table: "TaakGebruiker",
                columns: new[] { "GebruikerId", "TaakId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaakGebruiker_Gebruiker_GebruikerId",
                table: "TaakGebruiker",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaakGebruiker_Taak_TaakId",
                table: "TaakGebruiker",
                column: "TaakId",
                principalTable: "Taak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
