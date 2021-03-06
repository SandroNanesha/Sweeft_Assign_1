using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class updatedSecMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarTable",
                columns: table => new
                {
                    vinCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ownerID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNum = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "Int", nullable: false),
                    Price = table.Column<double>(type: "Float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ForSale = table.Column<bool>(type: "Bit", nullable: false),
                    IsActive = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTable", x => x.vinCode);
                });

            migrationBuilder.CreateTable(
                name: "ClientTable",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarTable");

            migrationBuilder.DropTable(
                name: "ClientTable");
        }
    }
}
