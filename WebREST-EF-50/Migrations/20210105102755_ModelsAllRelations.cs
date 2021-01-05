using Microsoft.EntityFrameworkCore.Migrations;

namespace WebREST_EF_50.Migrations
{
    public partial class ModelsAllRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_ResponsibleUserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_ResponsibleUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Objectives_Users_ResponsibleUserId",
                table: "Objectives");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ResponsibleUserId",
                table: "Projects");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Projects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Objectives",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Employees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Company",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_ResponsibleUserId",
                table: "Company",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_ResponsibleUserId",
                table: "Employees",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Objectives_Users_ResponsibleUserId",
                table: "Objectives",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ResponsibleUserId",
                table: "Projects",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_ResponsibleUserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_ResponsibleUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Objectives_Users_ResponsibleUserId",
                table: "Objectives");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ResponsibleUserId",
                table: "Projects");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Objectives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResponsibleUserId",
                table: "Company",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_ResponsibleUserId",
                table: "Company",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_ResponsibleUserId",
                table: "Employees",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objectives_Users_ResponsibleUserId",
                table: "Objectives",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ResponsibleUserId",
                table: "Projects",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
