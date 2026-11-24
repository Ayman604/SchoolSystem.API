using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostMustHasMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Media_MediaId",
                table: "PostMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Posts_PostId",
                table: "PostMedia");

            migrationBuilder.DropIndex(
                name: "IX_Post_DisplayOrder",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Post_PublishedCreated",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "UX_Post_Slug",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Media_CreatedAt",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_TypeCategory",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PublishedAtUtc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "MediaRole",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "FileSizeBytes",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Media");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "OwnerPostMediaId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_CategoryType",
                table: "Media",
                columns: new[] { "Category", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Media_CreatedAt",
                table: "Media",
                column: "CreatedAtUtc",
                descending: new bool[0]);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Media_MediaId",
                table: "PostMedia",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Posts_PostId",
                table: "PostMedia",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_PostMedia_OwnerPostMediaId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Media_MediaId",
                table: "PostMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Posts_PostId",
                table: "PostMedia");

            migrationBuilder.DropIndex(
                name: "IX_Media_CategoryType",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_CreatedAt",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_OwnerPostMediaId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "OwnerPostMediaId",
                table: "Media");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "Posts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAtUtc",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Posts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "PostMedia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediaRole",
                table: "PostMedia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Media",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<long>(
                name: "FileSizeBytes",
                table: "Media",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Media",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Post_DisplayOrder",
                table: "Posts",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PublishedCreated",
                table: "Posts",
                columns: new[] { "IsPublished", "CreatedAtUtc" });

            migrationBuilder.CreateIndex(
                name: "UX_Post_Slug",
                table: "Posts",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_CreatedAt",
                table: "Media",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Media_TypeCategory",
                table: "Media",
                columns: new[] { "Type", "Category" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Media_MediaId",
                table: "PostMedia",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Posts_PostId",
                table: "PostMedia",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
