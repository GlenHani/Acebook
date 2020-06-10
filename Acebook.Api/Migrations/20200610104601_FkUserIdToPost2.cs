using Microsoft.EntityFrameworkCore.Migrations;

namespace AcebookApi.Migrations
{
    public partial class FkUserIdToPost2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Posts",
                newName: "UserId");
        }
    }
}
