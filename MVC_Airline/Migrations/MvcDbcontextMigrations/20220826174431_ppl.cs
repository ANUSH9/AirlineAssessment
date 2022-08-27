using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Airline.Migrations.MvcDbcontextMigrations
{
    public partial class ppl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PANNO = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    RoleName = table.Column<string>(type: "VARCHAR", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
