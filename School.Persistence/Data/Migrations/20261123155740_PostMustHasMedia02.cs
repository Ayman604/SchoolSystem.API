using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostMustHasMedia02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_PostMedia_OwnerPostMediaId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_OwnerPostMediaId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "OwnerPostMediaId",
                table: "Media");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerPostMediaId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_OwnerPostMediaId",
                table: "Media",
                column: "OwnerPostMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_PostMedia_OwnerPostMediaId",
                table: "Media",
                column: "OwnerPostMediaId",
                principalTable: "PostMedia",
                principalColumn: "MediaId");
        }
    }
}
