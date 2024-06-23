using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat2024.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modelversionspecification3table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_Models_ModelId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ModelVersionSpecifications_ModelId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "ModelVersionSpecifications");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications",
                column: "ModelVersionId",
                principalTable: "ModelVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "ModelVersionSpecifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelVersionSpecifications_ModelId",
                table: "ModelVersionSpecifications",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications",
                column: "ModelVersionId",
                principalTable: "ModelVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_Models_ModelId",
                table: "ModelVersionSpecifications",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
