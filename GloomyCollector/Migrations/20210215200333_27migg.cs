using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class _27migg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GloomyUserId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GloomyUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
