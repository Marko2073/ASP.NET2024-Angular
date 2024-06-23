using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat2024.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Purchasetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCart_Users_UserId",
                table: "UserCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCart",
                table: "UserCart");

            migrationBuilder.RenameTable(
                name: "UserCart",
                newName: "UserCarts");

            migrationBuilder.RenameIndex(
                name: "IX_UserCart_UserId",
                table: "UserCarts",
                newName: "IX_UserCarts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCarts",
                table: "UserCarts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCartId = table.Column<int>(type: "int", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_ModelVersions_ModelVersionId",
                        column: x => x.ModelVersionId,
                        principalTable: "ModelVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_UserCarts_UserCartId",
                        column: x => x.UserCartId,
                        principalTable: "UserCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ModelVersionId",
                table: "Purchases",
                column: "ModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserCartId",
                table: "Purchases",
                column: "UserCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCarts_Users_UserId",
                table: "UserCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCarts_Users_UserId",
                table: "UserCarts");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCarts",
                table: "UserCarts");

            migrationBuilder.RenameTable(
                name: "UserCarts",
                newName: "UserCart");

            migrationBuilder.RenameIndex(
                name: "IX_UserCarts_UserId",
                table: "UserCart",
                newName: "IX_UserCart_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCart",
                table: "UserCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCart_Users_UserId",
                table: "UserCart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
