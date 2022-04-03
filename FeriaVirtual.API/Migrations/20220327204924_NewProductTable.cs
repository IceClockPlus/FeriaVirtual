using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeriaVirtual.API.Migrations
{
    public partial class NewProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "Papas" },
                    { 2, null, "Manzana" },
                    { 3, null, "Zanahoria" },
                    { 4, null, "Zapallo" },
                    { 5, null, "Frutillas" },
                    { 6, null, "Limón de pica" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
