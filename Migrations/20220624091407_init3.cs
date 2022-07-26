using Microsoft.EntityFrameworkCore.Migrations;

namespace FBE.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prog_Duzey_En",
                table: "Program_Duzey",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prog_Duzey_En",
                table: "Program_Duzey");
        }
    }
}
