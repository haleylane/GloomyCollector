using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class _22mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gloomies_AspNetUsers_GloomyUserId",
                table: "Gloomies");

            migrationBuilder.DropIndex(
                name: "IX_Gloomies_GloomyUserId",
                table: "Gloomies");

            migrationBuilder.DropColumn(
                name: "GloomyUserId",
                table: "Gloomies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GloomyUserId",
                table: "Gloomies",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gloomies_GloomyUserId",
                table: "Gloomies",
                column: "GloomyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gloomies_AspNetUsers_GloomyUserId",
                table: "Gloomies",
                column: "GloomyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
