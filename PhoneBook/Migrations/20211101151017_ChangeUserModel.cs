using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Migrations
{
    public partial class ChangeUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");
        }
    }
}
