using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class UpdateDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ResponsibleBy",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ResponsibleBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ResponsibleBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Departments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UserId",
                table: "Departments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_UserId",
                table: "Departments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_UserId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_UserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleBy",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Departments",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ResponsibleBy",
                table: "Departments",
                column: "ResponsibleBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_ResponsibleBy",
                table: "Departments",
                column: "ResponsibleBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
