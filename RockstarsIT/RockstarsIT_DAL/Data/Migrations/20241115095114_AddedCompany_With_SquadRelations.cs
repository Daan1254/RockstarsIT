using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockstarsIT_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompany_With_SquadRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Squads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Squads_CompanyEntityId",
                table: "Squads",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_CompanyEntity_CompanyEntityId",
                table: "Squads",
                column: "CompanyEntityId",
                principalTable: "CompanyEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squads_CompanyEntity_CompanyEntityId",
                table: "Squads");

            migrationBuilder.DropTable(
                name: "CompanyEntity");

            migrationBuilder.DropIndex(
                name: "IX_Squads_CompanyEntityId",
                table: "Squads");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Squads");
        }
    }
}
