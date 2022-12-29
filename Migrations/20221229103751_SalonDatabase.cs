using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektMVC.Migrations
{
    /// <inheritdoc />
    public partial class SalonDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Engine = table.Column<int>(type: "INTEGER", nullable: false),
                    HorsePower = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "CreateCarViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Year = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HorsePower = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CreateSalonListViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    OpenHours = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OpenDays = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CreateTestDriveViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Imie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    NrTel = table.Column<int>(type: "INTEGER", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EditCarViewModel",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Year = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HorsePower = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EditSalonModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    OpenHours = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OpenDays = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EditTestDriveModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Imie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    NrTel = table.Column<int>(type: "INTEGER", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    OpenHours = table.Column<string>(type: "TEXT", nullable: false),
                    OpenDays = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TestDrives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    NrTel = table.Column<int>(type: "INTEGER", nullable: false),
                    CarID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDrives", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CreateCarViewModel");

            migrationBuilder.DropTable(
                name: "CreateSalonListViewModel");

            migrationBuilder.DropTable(
                name: "CreateTestDriveViewModel");

            migrationBuilder.DropTable(
                name: "EditCarViewModel");

            migrationBuilder.DropTable(
                name: "EditSalonModel");

            migrationBuilder.DropTable(
                name: "EditTestDriveModel");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.DropTable(
                name: "TestDrives");
        }
    }
}
