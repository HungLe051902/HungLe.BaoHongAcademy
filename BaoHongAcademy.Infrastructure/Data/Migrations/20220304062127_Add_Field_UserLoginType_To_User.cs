using Microsoft.EntityFrameworkCore.Migrations;

namespace BaoHongAcademy.Infrastructure.Data.Migrations
{
    public partial class Add_Field_UserLoginType_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLoginType",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLoginType",
                table: "User");
        }
    }
}
