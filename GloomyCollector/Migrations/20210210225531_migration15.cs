using Microsoft.EntityFrameworkCore.Migrations;

namespace GloomyCollector.Migrations
{
    public partial class migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GloomyId = table.Column<int>(nullable: false),
                    GloomyUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => new { x.UserId, x.GloomyId });
                    table.ForeignKey(
                        name: "FK_WishLists_Gloomies_GloomyId",
                        column: x => x.GloomyId,
                        principalTable: "Gloomies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_GloomyUserId",
                        column: x => x.GloomyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_GloomyId",
                table: "WishLists",
                column: "GloomyId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_GloomyUserId",
                table: "WishLists",
                column: "GloomyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
