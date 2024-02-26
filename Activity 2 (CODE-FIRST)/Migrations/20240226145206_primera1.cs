using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity_2__CODE_FIRST_.Migrations
{
    public partial class primera1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportedEmployeeEmployeeNumber",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees",
                column: "ReportedEmployeeEmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees",
                column: "ReportedEmployeeEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderNumber",
                table: "OrderDetails",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerNumber",
                table: "Payments",
                column: "CustomerNumber",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderNumber",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerNumber",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportedEmployeeEmployeeNumber",
                table: "Employees");
        }
    }
}
