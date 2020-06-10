using Microsoft.EntityFrameworkCore.Migrations;

namespace AcebookApi.Migrations
{
    public partial class FkUserIdToPost3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Posts_UsersId",
                table: "Posts",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UsersId",
                table: "Posts",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UsersId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UsersId",
                table: "Posts");
        }
    }
}
