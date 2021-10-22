using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterToDoc.Migrations.ApplicationDB
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Busy",
                table: "Intervals",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Busy",
                table: "Intervals");
        }
    }
}
