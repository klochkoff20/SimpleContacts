using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class AddedResponsibleUsersToVacancies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesAttachments_Candidates_CandidateId",
                table: "CandidatesAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesAttachments_FileAttachments_FileId",
                table: "CandidatesAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesVacancies_Candidates_CandidateId",
                table: "CandidatesVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesVacancies_Vacancies_VacancyId",
                table: "CandidatesVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsAttachments_Departments_DepartmentId",
                table: "DepartmentsAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsAttachments_FileAttachments_FileId",
                table: "DepartmentsAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_AspNetUsers_ResponsibleBy",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_VacanciesAttachments_FileAttachments_FileId",
                table: "VacanciesAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_VacanciesAttachments_Vacancies_VacancyId",
                table: "VacanciesAttachments");

            migrationBuilder.DropTable(
                name: "DepartmentsContacts");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_ResponsibleBy",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "ResponsibleBy",
                table: "Vacancies");

            migrationBuilder.CreateTable(
                name: "VacanciesUsers",
                columns: table => new
                {
                    VacancyId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacanciesUsers", x => new { x.VacancyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_VacanciesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacanciesUsers_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacanciesUsers_UserId",
                table: "VacanciesUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesAttachments_Candidates_CandidateId",
                table: "CandidatesAttachments",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesAttachments_FileAttachments_FileId",
                table: "CandidatesAttachments",
                column: "FileId",
                principalTable: "FileAttachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesVacancies_Candidates_CandidateId",
                table: "CandidatesVacancies",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesVacancies_Vacancies_VacancyId",
                table: "CandidatesVacancies",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsAttachments_Departments_DepartmentId",
                table: "DepartmentsAttachments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsAttachments_FileAttachments_FileId",
                table: "DepartmentsAttachments",
                column: "FileId",
                principalTable: "FileAttachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacanciesAttachments_FileAttachments_FileId",
                table: "VacanciesAttachments",
                column: "FileId",
                principalTable: "FileAttachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacanciesAttachments_Vacancies_VacancyId",
                table: "VacanciesAttachments",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesAttachments_Candidates_CandidateId",
                table: "CandidatesAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesAttachments_FileAttachments_FileId",
                table: "CandidatesAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesVacancies_Candidates_CandidateId",
                table: "CandidatesVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesVacancies_Vacancies_VacancyId",
                table: "CandidatesVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsAttachments_Departments_DepartmentId",
                table: "DepartmentsAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsAttachments_FileAttachments_FileId",
                table: "DepartmentsAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_VacanciesAttachments_FileAttachments_FileId",
                table: "VacanciesAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_VacanciesAttachments_Vacancies_VacancyId",
                table: "VacanciesAttachments");

            migrationBuilder.DropTable(
                name: "VacanciesUsers");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleBy",
                table: "Vacancies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentsContacts",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsContacts", x => new { x.DepartmentId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_DepartmentsContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentsContacts_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ResponsibleBy",
                table: "Vacancies",
                column: "ResponsibleBy");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsContacts_ContactId",
                table: "DepartmentsContacts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesAttachments_Candidates_CandidateId",
                table: "CandidatesAttachments",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesAttachments_FileAttachments_FileId",
                table: "CandidatesAttachments",
                column: "FileId",
                principalTable: "FileAttachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesVacancies_Candidates_CandidateId",
                table: "CandidatesVacancies",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesVacancies_Vacancies_VacancyId",
                table: "CandidatesVacancies",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsAttachments_Departments_DepartmentId",
                table: "DepartmentsAttachments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsAttachments_FileAttachments_FileId",
                table: "DepartmentsAttachments",
                column: "FileId",
                principalTable: "FileAttachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_AspNetUsers_ResponsibleBy",
                table: "Vacancies",
                column: "ResponsibleBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VacanciesAttachments_FileAttachments_FileId",
                table: "VacanciesAttachments",
                column: "FileId",
                principalTable: "FileAttachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VacanciesAttachments_Vacancies_VacancyId",
                table: "VacanciesAttachments",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }
    }
}
