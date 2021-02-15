using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class _29thmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gloomies_AspNetUsers_GloomyUserId",
                table: "Gloomies");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_GloomyUserId",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Gloomies_GloomyUserId",
                table: "Gloomies");

            migrationBuilder.DropColumn(
                name: "GloomyUserId",
                table: "Gloomies");

            migrationBuilder.DropColumn(
                name: "GloomyUserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "GloomyUserId",
                table: "WishLists",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                columns: new[] { "UserId", "GloomyId", "GloomyUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_GloomyUserId",
                table: "WishLists",
                column: "GloomyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_GloomyUserId",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.AlterColumn<string>(
                name: "GloomyUserId",
                table: "WishLists",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "GloomyUserId",
                table: "Gloomies",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GloomyUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                columns: new[] { "UserId", "GloomyId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_GloomyUserId",
                table: "WishLists",
                column: "GloomyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
