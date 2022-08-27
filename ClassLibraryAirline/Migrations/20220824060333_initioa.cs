using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryAirline.Migrations
{
    public partial class initioa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AirlinesFromCity = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    AirlinesToCity = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    AirlinesFare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineModels", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirlineModels_AirlineName",
                table: "AirlineModels",
                column: "AirlineName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineModels");
        }
    }
}
