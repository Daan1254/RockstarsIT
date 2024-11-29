using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockstarsIT_DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squads_Companies_CompanyEntityId",
                table: "Squads");

            migrationBuilder.RenameColumn(
                name: "CompanyEntityId",
                table: "Squads",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Squads_CompanyEntityId",
                table: "Squads",
                newName: "IX_Squads_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_Companies_CompanyId",
                table: "Squads",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squads_Companies_CompanyId",
                table: "Squads");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Squads",
                newName: "CompanyEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Squads_CompanyId",
                table: "Squads",
                newName: "IX_Squads_CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_Companies_CompanyEntityId",
                table: "Squads",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
