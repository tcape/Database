using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAppDemo.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_AspNetUsers_ApplicationUserId1",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_ApplicationUserId1",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Surveys");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Surveys",
                nullable: true,
                oldClrType: typeof(int));

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_AspNetUsers_ApplicationUserId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_ApplicationUserId",
                table: "Surveys");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Surveys",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Surveys",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ApplicationUserId1",
                table: "Surveys",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_AspNetUsers_ApplicationUserId1",
                table: "Surveys",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
