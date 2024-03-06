using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity_2__CODE_FIRST_.Migrations
{
    public partial class tercera2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialPriceLists",
                table: "SpecialPriceLists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SpecialPriceLists");

            migrationBuilder.AddColumn<int>(
                name: "SpecialPriceListId",
                table: "SpecialPriceLists",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialPriceLists",
                table: "SpecialPriceLists",
                column: "SpecialPriceListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialPriceLists",
                table: "SpecialPriceLists");

            migrationBuilder.DropColumn(
                name: "SpecialPriceListId",
                table: "SpecialPriceLists");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SpecialPriceLists",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialPriceLists",
                table: "SpecialPriceLists",
                column: "Id");
        }
    }
}
