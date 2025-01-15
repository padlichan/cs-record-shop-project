using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cs_record_shop_project.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Albums");
        }
    }
}
