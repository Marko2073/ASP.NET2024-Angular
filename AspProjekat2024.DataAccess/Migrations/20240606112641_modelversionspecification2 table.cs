using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat2024.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modelversionspecification2table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications",
                column: "ModelVersionId",
                principalTable: "ModelVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
    }
}
