using Microsoft.EntityFrameworkCore.Migrations;

namespace cedrorestaurantbackend.Migrations
{
    public partial class RenameDishId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Dishes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dishes",
                newName: "DishId");
        }
    }
}
