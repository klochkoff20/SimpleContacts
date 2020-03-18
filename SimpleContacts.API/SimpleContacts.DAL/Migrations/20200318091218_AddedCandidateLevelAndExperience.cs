using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class AddedCandidateLevelAndExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "Level",
                table: "Candidates",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedPractice",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "StartedPractice",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "Experience",
                table: "Candidates",
                type: "tinyint",
                nullable: true);
        }
    }
}
