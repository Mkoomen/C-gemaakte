using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_School.Migrations
{
    public partial class AddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Woonplaats = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenten");
        }
    }
}
