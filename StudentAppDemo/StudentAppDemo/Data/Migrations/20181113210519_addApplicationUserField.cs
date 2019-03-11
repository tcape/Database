using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAppDemo.Data.Migrations
{
    public partial class addApplicationUserField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Surveys",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ApplicationUserId",
                table: "Surveys",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_AspNetUsers_ApplicationUserId",
                table: "Surveys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_AspNetUsers_ApplicationUserId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_ApplicationUserId",
                table: "Surveys");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Surveys",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
