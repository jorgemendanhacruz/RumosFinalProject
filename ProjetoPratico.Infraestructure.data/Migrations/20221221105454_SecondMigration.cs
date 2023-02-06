using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoPratico.Infraestructure.data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_UserId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "RecipesId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipe",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_RecipesId",
                table: "User",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Recipe_RecipesId",
                table: "User",
                column: "RecipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Recipe_RecipesId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RecipesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RecipesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_UserId",
                table: "Recipe",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
