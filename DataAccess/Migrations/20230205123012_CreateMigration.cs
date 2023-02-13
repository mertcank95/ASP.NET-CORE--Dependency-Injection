using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDepartment", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TblEmloyee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeSurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeSalary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmloyee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_TblEmloyee_TblDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblEmloyee_DepartmentId",
                table: "TblEmloyee",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblEmloyee");

            migrationBuilder.DropTable(
                name: "TblDepartment");
        }
    }
}
