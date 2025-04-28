using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAD_MA3_Solution_grp14.Migrations
{
    /// <inheritdoc />
    public partial class Migrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVR",
                table: "Providers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVR",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
