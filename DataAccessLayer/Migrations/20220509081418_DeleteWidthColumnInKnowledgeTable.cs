using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class DeleteWidthColumnInKnowledgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Width",
                table: "OtherKnowledges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "OtherKnowledges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
