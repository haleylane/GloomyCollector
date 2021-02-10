using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class _7thMigration : Migration
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GloomyUserId",
                table: "Gloomies",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

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
