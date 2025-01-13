using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockstarsIT_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedSurveyToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompletedSurveyId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CompletedSurveyId",
                table: "Answers",
                column: "CompletedSurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_CompletedSurveys_CompletedSurveyId",
                table: "Answers",
                column: "CompletedSurveyId",
                principalTable: "CompletedSurveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_CompletedSurveys_CompletedSurveyId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_CompletedSurveyId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CompletedSurveyId",
                table: "Answers");
        }
    }
}
