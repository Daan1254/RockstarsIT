using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockstarsIT.Migrations
{
    /// <inheritdoc />
    public partial class RenameQuestionModelToQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "QuestionModel",
                newName: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuestionModel");
        }
    }
}
