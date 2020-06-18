using Microsoft.EntityFrameworkCore.Migrations;

namespace AcebookApi.Migrations
{
    public partial class UserNameAddedPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNamePostedBy",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNamePostedBy",
                table: "Posts");
        }
    }
}
