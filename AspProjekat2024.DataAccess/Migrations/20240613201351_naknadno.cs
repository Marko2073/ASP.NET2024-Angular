using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat2024.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class naknadno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUseCase_Users_UserId",
                table: "UserUseCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUseCase",
                table: "UserUseCase");

            migrationBuilder.RenameTable(
                name: "UserUseCase",
                newName: "UserUseCases");

            migrationBuilder.RenameIndex(
                name: "IX_UserUseCase_UserId",
                table: "UserUseCases",
                newName: "IX_UserUseCases_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseCaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseCaseData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserUseCases_Users_UserId",
                table: "UserUseCases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUseCases_Users_UserId",
                table: "UserUseCases");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases");

            migrationBuilder.RenameTable(
                name: "UserUseCases",
                newName: "UserUseCase");

            migrationBuilder.RenameIndex(
                name: "IX_UserUseCases_UserId",
                table: "UserUseCase",
                newName: "IX_UserUseCase_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUseCase",
                table: "UserUseCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUseCase_Users_UserId",
                table: "UserUseCase",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
