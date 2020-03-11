using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class UpdatedCandidateNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddingSource",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Candidates");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Source",
                table: "Candidates",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "AddingSource",
                table: "Candidates",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Candidates",
                type: "datetime2",
                nullable: true);
        }
    }
}
