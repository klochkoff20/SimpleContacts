using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class UpdatedCandidateNaming2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expirience",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "Experience",
                table: "Candidates",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Candidates");

            migrationBuilder.AddColumn<byte>(
                name: "Expirience",
                table: "Candidates",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
