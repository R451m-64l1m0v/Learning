using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterToDoc.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTime_Doctors_DoctorId",
                table: "WorkTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime");

            migrationBuilder.RenameTable(
                name: "WorkTime",
                newName: "WorkTimeFull");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTime_DoctorId",
                table: "WorkTimeFull",
                newName: "IX_WorkTimeFull_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTimeFull",
                table: "WorkTimeFull",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimeFull_Doctors_DoctorId",
                table: "WorkTimeFull",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimeFull_Doctors_DoctorId",
                table: "WorkTimeFull");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTimeFull",
                table: "WorkTimeFull");

            migrationBuilder.RenameTable(
                name: "WorkTimeFull",
                newName: "WorkTime");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTimeFull_DoctorId",
                table: "WorkTime",
                newName: "IX_WorkTime_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTime_Doctors_DoctorId",
                table: "WorkTime",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
