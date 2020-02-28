using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class CandidateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateSource",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CandidateStatus",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "AddingSource",
                table: "Candidates",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Candidates",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddingSource",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "CandidateSource",
                table: "Candidates",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "CandidateStatus",
                table: "Candidates",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
