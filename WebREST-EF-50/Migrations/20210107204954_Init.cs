using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebREST_EF_50.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Access = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FullId = table.Column<long>(type: "INTEGER", nullable: true),
                    ResponsibleUserId = table.Column<long>(type: "INTEGER", nullable: true),
                    HqCompanyId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Company_HqCompanyId",
                        column: x => x.HqCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_User_FullId",
                        column: x => x.FullId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_User_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FullId = table.Column<long>(type: "INTEGER", nullable: true),
                    FullId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    ResponsibleUserId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Company_FullId",
                        column: x => x.FullId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_User_FullId1",
                        column: x => x.FullId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_User_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    UserId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Email_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_Employee_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    UserId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Employee_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsFinished = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FullId = table.Column<long>(type: "INTEGER", nullable: true),
                    FullId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    FullId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    ResponsibleUserId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Company_FullId",
                        column: x => x.FullId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Employee_FullId1",
                        column: x => x.FullId1,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_FullId2",
                        column: x => x.FullId2,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsFinished = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObjectType = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FullId = table.Column<long>(type: "INTEGER", nullable: true),
                    FullId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    FullId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    FullId3 = table.Column<long>(type: "INTEGER", nullable: true),
                    ResponsibleUserId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objective_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_Company_FullId",
                        column: x => x.FullId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_Employee_FullId1",
                        column: x => x.FullId1,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_Project_FullId2",
                        column: x => x.FullId2,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_User_FullId3",
                        column: x => x.FullId3,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_User_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_FullId",
                table: "Company",
                column: "FullId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_HqCompanyId",
                table: "Company",
                column: "HqCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ResponsibleUserId",
                table: "Company",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_CompanyId",
                table: "Email",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_CompanyId1",
                table: "Email",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Email_EmployeeId",
                table: "Email",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_EmployeeId1",
                table: "Email",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Email_UserId",
                table: "Email",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_UserId1",
                table: "Email",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FullId",
                table: "Employee",
                column: "FullId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FullId1",
                table: "Employee",
                column: "FullId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ResponsibleUserId",
                table: "Employee",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_CompanyId",
                table: "Objective",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_EmployeeId",
                table: "Objective",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_FullId",
                table: "Objective",
                column: "FullId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_FullId1",
                table: "Objective",
                column: "FullId1");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_FullId2",
                table: "Objective",
                column: "FullId2");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_FullId3",
                table: "Objective",
                column: "FullId3");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_ProjectId",
                table: "Objective",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_ResponsibleUserId",
                table: "Objective",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CompanyId",
                table: "Phone",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CompanyId1",
                table: "Phone",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_EmployeeId",
                table: "Phone",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_EmployeeId1",
                table: "Phone",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_UserId",
                table: "Phone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_UserId1",
                table: "Phone",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EmployeeId",
                table: "Project",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FullId",
                table: "Project",
                column: "FullId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FullId1",
                table: "Project",
                column: "FullId1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FullId2",
                table: "Project",
                column: "FullId2");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ResponsibleUserId",
                table: "Project",
                column: "ResponsibleUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
