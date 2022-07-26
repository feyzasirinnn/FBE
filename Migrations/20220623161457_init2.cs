using Microsoft.EntityFrameworkCore.Migrations;

namespace FBE.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilePrograms",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilesProgramProg_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilePrograms", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FilePrograms_Programs_FilesProgramProg_Id",
                        column: x => x.FilesProgramProg_Id,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagePrograms",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramImageProg_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePrograms", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ImagePrograms_Programs_ProgramImageProg_Id",
                        column: x => x.ProgramImageProg_Id,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilePrograms_FilesProgramProg_Id",
                table: "FilePrograms",
                column: "FilesProgramProg_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePrograms_ProgramImageProg_Id",
                table: "ImagePrograms",
                column: "ProgramImageProg_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilePrograms");

            migrationBuilder.DropTable(
                name: "ImagePrograms");
        }
    }
}
