using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAppDemo.Data.Migrations
{
    public partial class AddCollectionToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SurveyId",
                table: "AspNetUsers",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Surveys_SurveyId",
                table: "AspNetUsers",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Surveys_SurveyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SurveyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "AspNetUsers");

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
    }
}
