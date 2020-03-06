using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class Vacancies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Projects_ProjectId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "HardSkills",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "OptionalHardSkills",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Responsibilities",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "SoftSkills",
                table: "Vacancies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vacancies",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TargetDate",
                table: "Vacancies",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Vacancies",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Vacancies",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Languages",
                table: "Vacancies",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Vacancies",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Vacancies",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Vacancies",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Projects_ProjectId",
                table: "Vacancies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Projects_ProjectId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Vacancies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TargetDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Vacancies",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Languages",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Vacancies",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2048);

            migrationBuilder.AddColumn<string>(
                name: "HardSkills",
                table: "Vacancies",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionalHardSkills",
                table: "Vacancies",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsibilities",
                table: "Vacancies",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SoftSkills",
                table: "Vacancies",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Projects_ProjectId",
                table: "Vacancies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
