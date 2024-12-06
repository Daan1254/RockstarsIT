using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockstarsIT_DAL.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Squad_Survey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SquadSurveys_Squads_SquadsId",
                table: "SquadSurveys");

            migrationBuilder.DropForeignKey(
                name: "FK_SquadSurveys_Surveys_SurveysId",
                table: "SquadSurveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SquadSurveys",
                table: "SquadSurveys");

            migrationBuilder.RenameTable(
                name: "SquadSurveys",
                newName: "Squad_Surveys");

            migrationBuilder.RenameIndex(
                name: "IX_SquadSurveys_SurveysId",
                table: "Squad_Surveys",
                newName: "IX_Squad_Surveys_SurveysId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squad_Surveys",
                table: "Squad_Surveys",
                columns: new[] { "SquadsId", "SurveysId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Surveys_Squads_SquadsId",
                table: "Squad_Surveys",
                column: "SquadsId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Surveys_Surveys_SurveysId",
                table: "Squad_Surveys",
                column: "SurveysId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Surveys_Squads_SquadsId",
                table: "Squad_Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Surveys_Surveys_SurveysId",
                table: "Squad_Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squad_Surveys",
                table: "Squad_Surveys");

            migrationBuilder.RenameTable(
                name: "Squad_Surveys",
                newName: "SquadSurveys");

            migrationBuilder.RenameIndex(
                name: "IX_Squad_Surveys_SurveysId",
                table: "SquadSurveys",
                newName: "IX_SquadSurveys_SurveysId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SquadSurveys",
                table: "SquadSurveys",
                columns: new[] { "SquadsId", "SurveysId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SquadSurveys_Squads_SquadsId",
                table: "SquadSurveys",
                column: "SquadsId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SquadSurveys_Surveys_SurveysId",
                table: "SquadSurveys",
                column: "SurveysId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
