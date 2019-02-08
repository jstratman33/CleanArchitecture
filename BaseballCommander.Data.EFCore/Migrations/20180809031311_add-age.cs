using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseballCommander.Data.EFCore.Migrations
{
    public partial class addage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Player",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Player");
        }
    }
}
