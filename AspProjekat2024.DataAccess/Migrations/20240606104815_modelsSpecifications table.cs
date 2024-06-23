using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat2024.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modelsSpecificationstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelSpecification_Models_ModelId",
                table: "ModelSpecification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelSpecification",
                table: "ModelSpecification");

            migrationBuilder.RenameTable(
                name: "ModelSpecification",
                newName: "ModelSpecifications");

            migrationBuilder.RenameIndex(
                name: "IX_ModelSpecification_ModelId",
                table: "ModelSpecifications",
                newName: "IX_ModelSpecifications_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelSpecifications",
                table: "ModelSpecifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelSpecifications_Models_ModelId",
                table: "ModelSpecifications",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelSpecifications_Models_ModelId",
                table: "ModelSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelSpecifications",
                table: "ModelSpecifications");

            migrationBuilder.RenameTable(
                name: "ModelSpecifications",
                newName: "ModelSpecification");

            migrationBuilder.RenameIndex(
                name: "IX_ModelSpecifications_ModelId",
                table: "ModelSpecification",
                newName: "IX_ModelSpecification_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelSpecification",
                table: "ModelSpecification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelSpecification_Models_ModelId",
                table: "ModelSpecification",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
