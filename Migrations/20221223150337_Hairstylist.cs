using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_.NET_Hair_salon.Migrations
{
    public partial class Hairstylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hairstylist",
                table: "Serviciu");

            migrationBuilder.AddColumn<int>(
                name: "HairstylistID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hairstylist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairstylist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_HairstylistID",
                table: "Serviciu",
                column: "HairstylistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Hairstylist_HairstylistID",
                table: "Serviciu",
                column: "HairstylistID",
                principalTable: "Hairstylist",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Hairstylist_HairstylistID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Hairstylist");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_HairstylistID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "HairstylistID",
                table: "Serviciu");

            migrationBuilder.AddColumn<string>(
                name: "Hairstylist",
                table: "Serviciu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
