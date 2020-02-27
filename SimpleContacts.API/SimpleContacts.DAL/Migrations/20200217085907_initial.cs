using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleContacts.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Skype = table.Column<string>(maxLength: 128, nullable: true),
                    LinkedIn = table.Column<string>(maxLength: 128, nullable: true),
                    Telegram = table.Column<string>(maxLength: 128, nullable: true),
                    Facebook = table.Column<string>(maxLength: 128, nullable: true),
                    GooglePlus = table.Column<string>(maxLength: 128, nullable: true),
                    PreferableMethod = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Role = table.Column<byte>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    Location = table.Column<string>(maxLength: 256, nullable: true),
                    ContactId = table.Column<Guid>(nullable: false),
                    ReadyToRelocate = table.Column<bool>(nullable: false),
                    ResponsibleBy = table.Column<Guid>(nullable: false),
                    Industry = table.Column<string>(maxLength: 256, nullable: true),
                    Expirience = table.Column<byte>(nullable: false),
                    CurrentWork = table.Column<string>(maxLength: 256, nullable: true),
                    CurrentPosition = table.Column<string>(maxLength: 256, nullable: true),
                    EmploymentType = table.Column<byte>(nullable: false),
                    Education = table.Column<string>(maxLength: 512, nullable: true),
                    DesiredSalary = table.Column<int>(nullable: false),
                    Currency = table.Column<byte>(nullable: false),
                    HomePage = table.Column<string>(maxLength: 256, nullable: true),
                    CandidateStatus = table.Column<byte>(nullable: false),
                    CandidateSource = table.Column<byte>(nullable: false),
                    Skills = table.Column<string>(maxLength: 1024, nullable: true),
                    Description = table.Column<string>(maxLength: 2048, nullable: true),
                    ReminderDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidates_Users_ResponsibleBy",
                        column: x => x.ResponsibleBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Location = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Phone = table.Column<string>(maxLength: 64, nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ResponsibleBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_Users_ResponsibleBy",
                        column: x => x.ResponsibleBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    AddedAt = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAttachments_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatesLanguages",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    LanguageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesLanguages", x => new { x.CandidateId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CandidatesLanguages_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatesLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatesSkills",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesSkills", x => new { x.CandidateId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CandidatesSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatesSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatesTags",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesTags", x => new { x.CandidateId, x.TagId });
                    table.ForeignKey(
                        name: "FK_CandidatesTags_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatesTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsContacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatesAttachments",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesAttachments", x => new { x.CandidateId, x.FileId });
                    table.ForeignKey(
                        name: "FK_CandidatesAttachments_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatesAttachments_FileAttachments_FileId",
                        column: x => x.FileId,
                        principalTable: "FileAttachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsAttachments",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsAttachments", x => new { x.DepartmentId, x.FileId });
                    table.ForeignKey(
                        name: "FK_DepartmentsAttachments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentsAttachments_FileAttachments_FileId",
                        column: x => x.FileId,
                        principalTable: "FileAttachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VacancyName = table.Column<string>(maxLength: 128, nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    VacancyPriority = table.Column<byte>(nullable: false),
                    TargetDate = table.Column<DateTime>(nullable: false),
                    EmploymentType = table.Column<byte>(nullable: false),
                    Location = table.Column<string>(maxLength: 256, nullable: true),
                    SalaryMin = table.Column<int>(nullable: true),
                    SalaryMax = table.Column<int>(nullable: true),
                    RequiredExperience = table.Column<int>(nullable: true),
                    NumberOfPositions = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ResponsibleBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    Responsibilities = table.Column<string>(maxLength: 1024, nullable: false),
                    HardSkills = table.Column<string>(maxLength: 1024, nullable: false),
                    OptionalHardSkills = table.Column<string>(maxLength: 1024, nullable: true),
                    SoftSkills = table.Column<string>(maxLength: 1024, nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vacancies_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vacancies_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vacancies_Users_ResponsibleBy",
                        column: x => x.ResponsibleBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vacancies_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatesVacancies",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false),
                    Stage = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesVacancies", x => new { x.CandidateId, x.VacancyId });
                    table.ForeignKey(
                        name: "FK_CandidatesVacancies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatesVacancies_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(maxLength: 2048, nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VacanciesAttachments",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacanciesAttachments", x => new { x.VacancyId, x.FileId });
                    table.ForeignKey(
                        name: "FK_VacanciesAttachments_FileAttachments_FileId",
                        column: x => x.FileId,
                        principalTable: "FileAttachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacanciesAttachments_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VacanciesLanguages",
                columns: table => new
                {
                    VacancyId = table.Column<Guid>(nullable: false),
                    LanguageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacanciesLanguages", x => new { x.VacancyId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_VacanciesLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacanciesLanguages_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ContactId",
                table: "Candidates",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ResponsibleBy",
                table: "Candidates",
                column: "ResponsibleBy");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesAttachments_FileId",
                table: "CandidatesAttachments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesLanguages_LanguageId",
                table: "CandidatesLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesSkills_SkillId",
                table: "CandidatesSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesTags_TagId",
                table: "CandidatesTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesVacancies_VacancyId",
                table: "CandidatesVacancies",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CandidateId",
                table: "Comments",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VacancyId",
                table: "Comments",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedBy",
                table: "Departments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ResponsibleBy",
                table: "Departments",
                column: "ResponsibleBy");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsAttachments_FileId",
                table: "DepartmentsAttachments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsContacts_ContactId",
                table: "DepartmentsContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_AddedBy",
                table: "FileAttachments",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CreatedBy",
                table: "Vacancies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_DepartmentId",
                table: "Vacancies",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ProjectId",
                table: "Vacancies",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ResponsibleBy",
                table: "Vacancies",
                column: "ResponsibleBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_UpdatedBy",
                table: "Vacancies",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VacanciesAttachments_FileId",
                table: "VacanciesAttachments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_VacanciesLanguages_LanguageId",
                table: "VacanciesLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesAttachments");

            migrationBuilder.DropTable(
                name: "CandidatesLanguages");

            migrationBuilder.DropTable(
                name: "CandidatesSkills");

            migrationBuilder.DropTable(
                name: "CandidatesTags");

            migrationBuilder.DropTable(
                name: "CandidatesVacancies");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DepartmentsAttachments");

            migrationBuilder.DropTable(
                name: "DepartmentsContacts");

            migrationBuilder.DropTable(
                name: "VacanciesAttachments");

            migrationBuilder.DropTable(
                name: "VacanciesLanguages");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
