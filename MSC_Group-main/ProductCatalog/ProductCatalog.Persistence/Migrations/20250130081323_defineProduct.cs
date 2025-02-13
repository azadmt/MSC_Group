using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalog.Persistence.Migrations
{
    public partial class defineProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductAggregate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color_Red = table.Column<byte>(type: "tinyint", nullable: false),
                    Color_Green = table.Column<byte>(type: "tinyint", nullable: false),
                    Color_Blue = table.Column<byte>(type: "tinyint", nullable: false),
                    Price_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAggregate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAggregate");
        }
    }
}
