using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity_2__CODE_FIRST_.Migrations
{
    public partial class segona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductProducCode",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductProducCode",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProducCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductProducCode",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippedDate",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequiredDate",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Offices",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ReportsTo",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductCode",
                table: "OrderDetails",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductCode",
                table: "OrderDetails",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductCode",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductCode",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "ProducCode",
                table: "Products",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ShippedDate",
                table: "Orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredDate",
                table: "Orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDate",
                table: "Orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "ProductProducCode",
                table: "OrderDetails",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ReportsTo",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProducCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductProducCode",
                table: "OrderDetails",
                column: "ProductProducCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductProducCode",
                table: "OrderDetails",
                column: "ProductProducCode",
                principalTable: "Products",
                principalColumn: "ProducCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
