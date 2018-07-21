using Microsoft.EntityFrameworkCore.Migrations;

namespace cedrorestaurantbackend.Migrations
{
    public partial class ChangeDishPrimaryKeyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId1",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RestaurantId1",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "Dishes");

            migrationBuilder.AlterColumn<long>(
                name: "RestaurantId",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "RestaurantId1",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId1",
                table: "Dishes",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId1",
                table: "Dishes",
                column: "RestaurantId1",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
