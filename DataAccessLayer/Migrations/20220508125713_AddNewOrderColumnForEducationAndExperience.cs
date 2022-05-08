using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddNewOrderColumnForEducationAndExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Educations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Educations");
        }
    }
}
