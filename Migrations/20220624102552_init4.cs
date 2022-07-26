using Microsoft.EntityFrameworkCore.Migrations;

namespace FBE.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "slidersId",
                table: "SliderImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SliderImages_slidersId",
                table: "SliderImages",
                column: "slidersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SliderImages_Slider_slidersId",
                table: "SliderImages",
                column: "slidersId",
                principalTable: "Slider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderImages_Slider_slidersId",
                table: "SliderImages");

            migrationBuilder.DropIndex(
                name: "IX_SliderImages_slidersId",
                table: "SliderImages");

            migrationBuilder.DropColumn(
                name: "slidersId",
                table: "SliderImages");
        }
    }
}
