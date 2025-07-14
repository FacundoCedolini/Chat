using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupIdToMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Messages",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Messages");
        }
    }
}
