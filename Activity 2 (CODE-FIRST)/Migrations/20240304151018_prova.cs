using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity_2__CODE_FIRST_.Migrations
{
    public partial class prova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    AdressLine1 = table.Column<string>(nullable: false),
                    AdressLine2 = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Territory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductLiness",
                columns: table => new
                {
                    ProductLine = table.Column<string>(nullable: false),
                    TextDescription = table.Column<string>(nullable: false),
                    HtmlDescription = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLiness", x => x.ProductLine);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Extension = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    OfficeCode = table.Column<string>(nullable: false),
                    OfficeCode1 = table.Column<string>(nullable: false),
                    ReportsTo = table.Column<int>(nullable: true),
                    ReportedEmployeeEmployeeNumber = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeCode1",
                        column: x => x.OfficeCode1,
                        principalTable: "Offices",
                        principalColumn: "OfficeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportedEmployeeEmployeeNumber",
                        column: x => x.ReportedEmployeeEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductLine = table.Column<string>(nullable: false),
                    ProductLinesProductLine = table.Column<string>(nullable: false),
                    ProductScale = table.Column<string>(nullable: false),
                    ProductVendor = table.Column<string>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: false),
                    QuantityStock = table.Column<short>(nullable: false),
                    BuyPrice = table.Column<double>(nullable: false),
                    MSRP = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Products_ProductLiness_ProductLinesProductLine",
                        column: x => x.ProductLinesProductLine,
                        principalTable: "ProductLiness",
                        principalColumn: "ProductLine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: false),
                    ContactLastName = table.Column<string>(nullable: false),
                    ContactFirstName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    AdressLine1 = table.Column<string>(nullable: false),
                    AdressLine2 = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    SalesRepEmployeeNumber = table.Column<int>(nullable: false),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    CreditLimit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: false),
                    CustomerNumber = table.Column<int>(nullable: false),
                    CustomerNumber1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerNumber1",
                        column: x => x.CustomerNumber1,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(nullable: false),
                    CheckNumber = table.Column<string>(nullable: false),
                    PaymentDate = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => new { x.CustomerNumber, x.CheckNumber });
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    QuantityOrdered = table.Column<int>(nullable: false),
                    PriceEach = table.Column<double>(nullable: false),
                    OrderLineNumber = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderNumber, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmployeeNumber",
                table: "Customers",
                column: "EmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode1",
                table: "Employees",
                column: "OfficeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportedEmployeeEmployeeNumber",
                table: "Employees",
                column: "ReportedEmployeeEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductCode",
                table: "OrderDetails",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerNumber1",
                table: "Orders",
                column: "CustomerNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLinesProductLine",
                table: "Products",
                column: "ProductLinesProductLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductLiness");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
