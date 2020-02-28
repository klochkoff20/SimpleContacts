using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class DepartmentComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Comments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DepartmentId",
                table: "Comments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Departments_DepartmentId",
                table: "Comments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Departments_DepartmentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DepartmentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Comments");
        }
    }
}
