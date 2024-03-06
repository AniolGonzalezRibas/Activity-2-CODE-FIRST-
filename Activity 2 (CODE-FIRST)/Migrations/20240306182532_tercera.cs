using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity_2__CODE_FIRST_.Migrations
{
    public partial class tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerNumber",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerNumber",
                table: "Orders",
                column: "CustomerNumber",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerNumber",
                table: "Orders",
                column: "CustomerNumber",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
