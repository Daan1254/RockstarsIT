using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockstarsIT.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    SurveyModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionModel_Surveys_SurveyModelId",
                        column: x => x.SurveyModelId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_SurveyModelId",
                table: "QuestionModel",
                column: "SurveyModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionModel");
        }
    }
}
