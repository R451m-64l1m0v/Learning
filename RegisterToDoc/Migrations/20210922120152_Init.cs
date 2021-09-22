using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterToDoc.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", nullable: true),
                    Education = table.Column<string>(type: "TEXT", nullable: true),
                    Experience = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartHour = table.Column<int>(type: "INTEGER", nullable: false),
                    EndHour = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTime_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimeGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimeGraphics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTimeGraphics_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intervals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartHour = table.Column<int>(type: "INTEGER", nullable: false),
                    EndHour = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkTimeGraphicId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intervals_WorkTimeGraphics_WorkTimeGraphicId",
                        column: x => x.WorkTimeGraphicId,
                        principalTable: "WorkTimeGraphics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervals_WorkTimeGraphicId",
                table: "Intervals",
                column: "WorkTimeGraphicId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTime_DoctorId",
                table: "WorkTime",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeGraphics_DoctorId",
                table: "WorkTimeGraphics",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intervals");

            migrationBuilder.DropTable(
                name: "WorkTime");

            migrationBuilder.DropTable(
                name: "WorkTimeGraphics");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
