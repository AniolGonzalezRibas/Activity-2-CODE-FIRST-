using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity_2__CODE_FIRST_.Migrations
{
    public partial class prova1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_OfficeCode1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OfficeCode1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OfficeCode1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportedEmployeeEmployeeNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees",
                column: "OfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_OfficeCode",
                table: "Employees",
                column: "OfficeCode",
                principalTable: "Offices",
                principalColumn: "OfficeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_OfficeCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportsTo",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "Employees",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "OfficeCode1",
                table: "Employees",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReportedEmployeeEmployeeNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode1",
                table: "Employees",
                column: "OfficeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees",
                column: "ReportedEmployeeEmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_OfficeCode1",
                table: "Employees",
                column: "OfficeCode1",
                principalTable: "Offices",
                principalColumn: "OfficeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees",
                column: "ReportedEmployeeEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
