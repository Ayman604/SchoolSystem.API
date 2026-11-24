using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePostsAndMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Student");
            migrationBuilder.DropTable(name: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
