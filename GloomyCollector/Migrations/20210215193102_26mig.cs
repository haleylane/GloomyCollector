using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class _26mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GloomyUserId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GloomyUserId",
                table: "AspNetUsers");
        }
    }
}
