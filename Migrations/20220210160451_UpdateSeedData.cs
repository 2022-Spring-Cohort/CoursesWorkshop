using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursesWorkshop.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Building", "DepartmentCode", "Instructor", "Name", "RoomNumber" },
                values: new object[] { 1, "Museum", "BIOC", "Carlos Lopez", "Biochemistry", 1234 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Building", "DepartmentCode", "Instructor", "Name", "RoomNumber" },
                values: new object[] { 2, "Empire State Building", "PSYC", "Gavin Hensley", "Psychology", 205 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
