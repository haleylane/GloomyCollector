using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class _16thMigration : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WishLists",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WishLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

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
