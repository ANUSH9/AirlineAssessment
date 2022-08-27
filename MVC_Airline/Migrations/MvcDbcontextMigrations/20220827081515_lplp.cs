using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Airline.Migrations.MvcDbcontextMigrations
{
    public partial class lplp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "adminModel");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_Email",
                table: "adminModel",
                newName: "IX_adminModel_Email");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "adminModel",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AddColumn<string>(
                name: "IsApproved",
                table: "adminModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adminModel",
                table: "adminModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_adminModel",
                table: "adminModel");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "adminModel");

            migrationBuilder.RenameTable(
                name: "adminModel",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_adminModel_Email",
                table: "Admins",
                newName: "IX_Admins_Email");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Admins",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");
        }
    }
}
