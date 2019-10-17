using Microsoft.EntityFrameworkCore.Migrations;

namespace SubitonAPI.Migrations
{
    public partial class extendPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "set_user_nrid",
                table: "Photos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "set_user_nrid",
                table: "Photos");
        }
    }
}
